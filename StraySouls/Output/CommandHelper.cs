using static System.Console;

namespace StraySouls.Output
{
    public static class CommandHelper
    {
        public static void InputHelp()
        {
            WriteLine("Enter \"random\" to start randomizing");
            switch (TargetGame.Game)
            {
                case Game.DS3:

                    WriteLine("Enter \"backup\" to start creating backups");
                    WriteLine("Enter \"restore\" to start restoring");
                    WriteLine("Available \"random\" arguments:");
                    WriteLine("\t-m\t: Randomize main boss additionally");
                    WriteLine("\t-o\t: Randomize optional boss additionally");
                    WriteLine("\t-f\t: Randomize friendly NPCs additionally (TODO)");
                    WriteLine("\t-a\t: Randomize aggressive NPCs additionally (TODO)");
                    WriteLine("\t-2 ~ -9\t: Multiply enemies by the number given, for example, -3 means multiplying enemies by three times");
                    WriteLine("\t-u: Unlimited mode, change enemies individually rather than simply change their positions");
                    WriteLine("Just type random like:\nInput>>random\nOr use arguments like:\nInput>>random -m -o -2");

                    break;
                case Game.Sekiro:

                    WriteLine("It's still under construction");

                    break;
            }
        }


    }
}
