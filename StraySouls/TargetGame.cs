using static System.Console;

namespace StraySouls
{
    public enum Game { _, DS3, Sekiro }

    public static class TargetGame
    {
        public static Game Game { get => _game == Game._ ? AskUserTargetGame() : _game; }

        private const string FOLDER_PATH_DS3 = @"DARK SOULS III\Game\";
        private const string FOLDER_PATH_SEKIRO = @"Sekiro\";

        private static Game _game = Game._;

        public static Game AskUserTargetGame()
        {
            WriteLine("Press key to choose target game:");
            WriteLine("1: Dark Souls 3");
            WriteLine("2: Sekiro");

            while (true)
                if (int.TryParse(ReadKey(true).KeyChar.ToString(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            WriteLine("Dark Souls 3 selected");
                            _game = Game.DS3;
                            break;
                        case 2:
                            WriteLine("Sekiro selected");
                            _game = Game.Sekiro;
                            break;
                    }
                    break;
                }

            return Game;
        }

        public static string GetGameFolderPath()
        {
            switch (Game)
            {
                case Game.DS3:
                    return FOLDER_PATH_DS3;
                case Game.Sekiro:
                    return FOLDER_PATH_SEKIRO;
                default:
                    return string.Empty;
            }
        }
    }
}
