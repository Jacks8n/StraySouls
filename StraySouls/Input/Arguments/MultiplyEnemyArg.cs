using System.Collections.Generic;
using StraySouls.Wrapper;

using Enemy_DS3 = SoulsFormats.MSB3.Part.Enemy;
using Enemy_Sekiro = SoulsFormats.MSBS.Part.Enemy;

namespace StraySouls.Input.Arguments
{
    public class MultiplyEnemyArg : ICommandArgument<EnemyRandomCommand_DS3>, ICommandArgument<EnemyRandomCommand_Sekiro>
    {
        public const int MULTIPLY_MINIMUM = 2;
        public const int MULTIPLY_MAXIMUM = 9;

        private int _multiplier = MULTIPLY_MINIMUM;

        public bool IsValidArgString(string argString)
        {
            return int.TryParse(argString, out _multiplier)
                && _multiplier >= MULTIPLY_MINIMUM && _multiplier <= MULTIPLY_MAXIMUM;
        }

        public void ModifyCommand(EnemyRandomCommand_DS3 command, bool enabled)
        {
            if (enabled)
                command.Randomizer.OnAfterSelectRandomizableBeforeRandomize += Multiply_DS3;
        }

        public void ModifyCommand(EnemyRandomCommand_Sekiro command, bool enabled)
        {
            if (enabled)
                command.Randomizer.OnAfterSelectRandomizableBeforeRandomize += Multiply_Sekiro;
        }

        private void Multiply_DS3(List<Enemy_DS3> originalEntries, List<Enemy_DS3> randomizableEntries, List<EnemyWrapper_DS3> associatedWrappers)
        {
            for (int i = randomizableEntries.Count - 1; i > -1; i--)
                for (int j = 1; j < _multiplier; j++)
                {
                    Enemy_DS3 clone = randomizableEntries[i].Clone();
                    originalEntries.Add(clone);
                    randomizableEntries.Add(clone);
                    associatedWrappers.Add(clone.GetWrapper<EnemyWrapper_DS3, Enemy_DS3>());
                }
        }

        private void Multiply_Sekiro(List<Enemy_Sekiro> originalEntries, List<Enemy_Sekiro> randomizableEntries, List<EnemyWrapper_Sekiro> associatedWrappers)
        {
            for (int i = randomizableEntries.Count - 1; i > -1; i--)
                for (int j = 1; j < _multiplier; j++)
                {
                    Enemy_Sekiro clone = randomizableEntries[i].Clone();
                    originalEntries.Add(clone);
                    randomizableEntries.Add(clone);
                    associatedWrappers.Add(clone.GetWrapper<EnemyWrapper_Sekiro, Enemy_Sekiro>());
                }
        }
    }
}