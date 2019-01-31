using SoulsFormats;

namespace StraySouls
{
    public static partial class CommandInput
    {
        private class EnemyRandomCommand : ICommand
        {
            private const char MODE_NONE = 'e';
            private const char MODE_MAIN_BOSS = 'm';
            private const char MODE_OPTIONAL_BOSS = 'o';
            private const char MODE_FRIENDLY_NPC = 'f';
            private const char MODE_AGGRESIVE_NPC = 'a';

            private const EnemyRandomizerAddMode MODE_DEFAULT = EnemyRandomizerAddMode.None;

            private EnemyRandomizer _randomizer = new EnemyRandomizer();

            public void Command(string msbName, char[] args)
            {
                EnemyRandomizerAddMode mode = EnemyRandomizerAddMode.None;
                for (int i = 0; i < args.Length; i++)
                    mode |= CharToMode(args[i]);
                _randomizer.SetAdditionMode(mode);

                string filePath = _mapstudioPath + msbName;
                MSB3 msb = MSB3.Read(filePath);

                _randomizer.Randomize(ref msb.Parts.Enemies);
                msb.Write(filePath);
            }

            private EnemyRandomizerAddMode CharToMode(char arg)
            {
                switch (arg)
                {
                    case MODE_NONE:
                        return EnemyRandomizerAddMode.None;
                    case MODE_MAIN_BOSS:
                        return EnemyRandomizerAddMode.MainBoss;
                    case MODE_OPTIONAL_BOSS:
                        return EnemyRandomizerAddMode.OptionalBoss;
                    case MODE_FRIENDLY_NPC:
                        return EnemyRandomizerAddMode.FriendlyNPC;
                    case MODE_AGGRESIVE_NPC:
                        return EnemyRandomizerAddMode.AggressiveNPC;
                }
                return MODE_DEFAULT;
            }
        }
    }
}
