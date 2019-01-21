using System.Collections.Generic;
using System.IO;
using SoulsFormats;

namespace StraySouls
{
    public static class CommandInput
    {
        private abstract class CommandBase
        {
            public abstract void Command(string msbName, char[] args);
        }

        private class EnemyRandomCommand : CommandBase
        {
            private const char MODE_NONE = 'e';
            private const char MODE_MAIN_BOSS = 'm';
            private const char MODE_OPTIONAL_BOSS = 'o';
            private const char MODE_FRIENDLY_NPC = 'f';
            private const char MODE_AGGRESIVE_NPC = 'a';

            private const EnemyRandomizerAddMode MODE_DEFAULT = EnemyRandomizerAddMode.None;

            private EnemyRandomizer _randomizer = new EnemyRandomizer();

            public override void Command(string msbName, char[] args)
            {
                EnemyRandomizerAddMode mode = EnemyRandomizerAddMode.None;
                for (int i = 0; i < args.Length; i++)
                    mode |= CharToMode(args[i]);
                _randomizer.SetAdditionMode(mode);

                string filePath = _mapstudioPath + msbName;
                MSB3 msb = MSB3.Read(filePath);
                _randomizer.Randomize(msb.Parts.Enemies);
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

        private class BackupCommand : CommandBase
        {
            public override void Command(string msbName, char[] args)
            {
                Directory.CreateDirectory(_backupFolderPath);

                string backupFilePath = _backupFolderPath + msbName;

                if (!File.Exists(backupFilePath))
                    File.Copy(_mapstudioPath + msbName, backupFilePath);
            }
        }

        private class RestoreCommand : CommandBase
        {
            public override void Command(string msbName, char[] args)
            {
                File.Copy(_backupFolderPath + msbName, _mapstudioPath + msbName, overwrite: true);
            }
        }

        private static readonly Dictionary<string, CommandBase> TABLE_COMMANDS = new Dictionary<string, CommandBase>()
        {
            { "random", new EnemyRandomCommand() },
            { "backup", new BackupCommand() },
            { "restore", new RestoreCommand() }
        };

        private static readonly string[] LIST_FILE_RANDOM = new string[]
        {
            "m30_00_00_00.msb.dcx",
            "m30_01_00_00.msb.dcx",
            "m31_00_00_00.msb.dcx",
            "m32_00_00_00.msb.dcx",
            "m33_00_00_00.msb.dcx",
            "m34_01_00_00.msb.dcx",
            "m35_00_00_00.msb.dcx",
            "m37_00_00_00.msb.dcx",
            "m38_00_00_00.msb.dcx",
            "m39_00_00_00.msb.dcx",
            "m40_00_00_00.msb.dcx",
            "m41_00_00_00.msb.dcx", //Firelink Shrine
            "m45_00_00_00.msb.dcx",
            "m50_00_00_00.msb.dcx",
            "m51_00_00_00.msb.dcx",
            "m51_01_00_00.msb.dcx",
        };

        private static string _mapstudioPath;

        private static string _backupFolderPath;
        
        /// <summary> Returns whether the input is valid </summary>
        public static bool Command(string input)
        {
            _mapstudioPath = DSPath.GetDS3MapStudioPath();
            _backupFolderPath = _mapstudioPath + @"StraySouls_Backup\";

            string[] commandSplits = input.Split(' ');
            string command = commandSplits[0];

            if (TABLE_COMMANDS.TryGetValue(command, out CommandBase commandEntry))
            {
                List<char> args = new List<char>();
                for (int i = 1; i < commandSplits.Length; i++)
                {
                    string split = commandSplits[i];
                    if (split.Length == 2 && split[0] == '-')
                        args.Add(split[1]);
                }

                for (int i = 0; i < LIST_FILE_RANDOM.Length; i++)
                    commandEntry.Command(LIST_FILE_RANDOM[i], args.ToArray());

                return true;
            }
            return false;
        }
    }
}
