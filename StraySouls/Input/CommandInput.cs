using System.Collections.Generic;

namespace StraySouls
{
    public static partial class CommandInput
    {
        private static readonly Dictionary<string, ICommand> TABLE_COMMANDS = new Dictionary<string, ICommand>()
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
            "m41_00_00_00.msb.dcx", //Firelink Shrine, Soul of Cinder
            "m45_00_00_00.msb.dcx",
            "m50_00_00_00.msb.dcx",
            "m51_00_00_00.msb.dcx",
            "m51_01_00_00.msb.dcx", //Filianore's Rest
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

            if (TABLE_COMMANDS.TryGetValue(command, out ICommand commandEntry))
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
