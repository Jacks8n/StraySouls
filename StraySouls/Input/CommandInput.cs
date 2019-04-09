using System.IO;
using System.Collections.Generic;

namespace StraySouls.Input
{
    public static class CommandInput
    {
        private static readonly Dictionary<string, ICommand> TABLE_COMMANDS = new Dictionary<string, ICommand>()
        {
            { "random", new EnemyRandomCommand() },
            { "backup", new BackupCommand() },
            { "restore", new RestoreCommand() }
        };

        private static readonly string[] LIST_FILE_RANDOM_DS3 = new string[]
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

        private static readonly string[] LIST_FILE_RANDOM_SEKIRO = new string[]
        {
            "m10_00_00_00.msb.dcx",
            "m11_00_00_00.msb.dcx",
            "m11_01_00_00.msb.dcx",
            "m11_02_00_00.msb.dcx",
            "m13_00_00_00.msb.dcx",
            "m15_00_00_00.msb.dcx",
            "m17_00_00_00.msb.dcx",
            "m20_00_00_00.msb.dcx",
            "m25_00_00_00.msb.dcx",
            "m89_00_00_99.msb.dcx",
        };

        /// <summary> Returns whether the input is valid </summary>
        public static bool Command(string input)
        {
            string command = SplitCommand(input, out string[] args);
            string[] fileList = null;
            Game game = TargetGame.Game;
            switch (game)
            {
                case Game.DS3:
                    fileList = LIST_FILE_RANDOM_DS3;
                    break;
                case Game.Sekiro:
                    fileList = LIST_FILE_RANDOM_SEKIRO;
                    break;
            }

            if (TABLE_COMMANDS.TryGetValue(command, out ICommand commandEntry))
            {
                for (int i = 0; i < fileList.Length; i++)
                    if (File.Exists(GamePath.GetMapStudioPath() + fileList[i]))
                        commandEntry.Command(game, fileList[i], args);

                return true;
            }
            return false;
        }

        /// <summary>
        /// Returns command name
        /// </summary>
        /// <param name="arguments">Arguments applied together</param>
        private static string SplitCommand(string input, out string[] arguments)
        {
            string[] commandSplits = input.Split(' ', '-');
            string command = commandSplits[0].Trim();

            List<string> args = new List<string>();
            for (int i = 1; i < commandSplits.Length; i++)
                if (commandSplits[i].Length > 0)
                    args.Add(commandSplits[i]);

            arguments = args.ToArray();
            return command;
        }
    }
}
