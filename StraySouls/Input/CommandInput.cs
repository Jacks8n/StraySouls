using System.IO;
using System.Collections.Generic;

namespace StraySouls.Input
{
    public static partial class CommandInput
    {
        /// <summary> Returns whether the input is valid </summary>
        public static bool Command(string input)
        {
            string command = SplitCommand(input, out string[] args);
            Game game = TargetGame.Game;
            SelectFileListAndCommandTable(game, out string[] fileList, out Dictionary<string, ICommand> commandTable);

            if (commandTable.TryGetValue(command, out ICommand commandEntry))
            {
                string filePath;
                for (int i = 0; i < fileList.Length; i++)
                    if (File.Exists(filePath = GamePath.GetMapStudioPath() + fileList[i]))
                        commandEntry.Command(filePath, fileList[i], args);

                return true;
            }
            return false;
        }

        private static void SelectFileListAndCommandTable(Game game, out string[] fileList, out Dictionary<string, ICommand> commandTable)
        {
            switch (game)
            {
                case Game.DS3:
                    fileList = LIST_FILE_RANDOM_DS3;
                    commandTable = COMMAND_TABLE_DS3;
                    break;
                case Game.Sekiro:
                    fileList = LIST_FILE_RANDOM_SEKIRO;
                    commandTable = COMMANDS_TABLE_SEKIRO;
                    break;
                default:
                    commandTable = null;
                    fileList = null;
                    break;
            }
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
