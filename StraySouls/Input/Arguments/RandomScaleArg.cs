using System;
using System.Collections.Generic;
using System.Numerics;
using StraySouls.Wrapper;

using Enemy_DS3 = SoulsFormats.MSB3.Part.Enemy;
using Enemy_Sekiro = SoulsFormats.MSBS.Part.Enemy;

namespace StraySouls.Input.Arguments
{
    public class RandomScaleArg : ICommandArgument<EnemyRandomCommand_DS3>, ICommandArgument<EnemyRandomCommand_Sekiro>
    {
        private const float RANDOM_SCALE_MIN = .2f;

        private const float RANDOM_SCALE_RANGE = 2.3f;

        private const bool RANDOM_PER_AXIS = true;

        public bool IsValidArgString(string arg)
        {
            return arg.Length == 1 && (arg[0] == 's' || arg[0] == 'S');
        }

        public void ModifyCommand(EnemyRandomCommand_DS3 command, bool enabled)
        {
            if (enabled)
                command.Randomizer.OnAfterEverything += RandomizeScale;
        }

        public void ModifyCommand(EnemyRandomCommand_Sekiro command, bool enabled)
        {
            if (enabled)
                command.Randomizer.OnAfterEverything += RandomizeScale;
        }

        private void RandomizeScale(List<Enemy_DS3> originalEntries, List<Enemy_DS3> randomizableEntries, List<EnemyWrapper_DS3> associatedWrappers)
        {
            Random random = new Random();

            if (RANDOM_PER_AXIS)
                for (int i = 0; i < originalEntries.Count; i++)
                {
                    originalEntries[i].Scale.X *= LerpScale((float)random.NextDouble());
                    originalEntries[i].Scale.Y *= LerpScale((float)random.NextDouble());
                    originalEntries[i].Scale.Z *= LerpScale((float)random.NextDouble());
                }
            else
                for (int i = 0; i < originalEntries.Count; i++)
                    originalEntries[i].Scale *= LerpScale((float)random.NextDouble());
        }

        private void RandomizeScale(List<Enemy_Sekiro> originalEntries, List<Enemy_Sekiro> randomizableEntries, List<EnemyWrapper_Sekiro> associatedWrappers)
        {
            Random random = new Random();

            if (RANDOM_PER_AXIS)
                for (int i = 0; i < originalEntries.Count; i++)
                {
                    Vector3 scale = originalEntries[i].Scale;
                    scale.X *= LerpScale((float)random.NextDouble());
                    scale.Y *= LerpScale((float)random.NextDouble());
                    scale.Z *= LerpScale((float)random.NextDouble());
                    originalEntries[i].Scale = scale;
                }
            else
                for (int i = 0; i < originalEntries.Count; i++)
                    originalEntries[i].Scale *= LerpScale((float)random.NextDouble());
        }

        private float LerpScale(float value)
        {
            return RANDOM_SCALE_MIN + value * RANDOM_SCALE_RANGE;
        }
    }
}
