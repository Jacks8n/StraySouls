using static System.Console;

namespace StraySouls.Output
{
    public static class CommandHelper
    {
        public static void InputHelp()
        {
            WriteLine("Enter \"backup\" to start creating backups");
            WriteLine("Enter \"restore\" to start restoring");
            WriteLine("Enter \"random\" to start randomizing");
            WriteLine("Available \"random\" arguments:");
            WriteLine("\t-m\t: Randomize \"incremental\" main boss");
            WriteLine("\t-f\t: Randomize friendly NPCs additionally (TODO)");
            WriteLine("\t-2 ~ -9\t: Multiply enemies by the number given, for example, -3 means multiplying enemies by three times");
            WriteLine("Just type random like:\nInput>>random\nOr use arguments like:\nInput>>random -m -o -2");
            switch (TargetGame.Game)
            {
                case Game.DS3:

                    WriteLine("\t-o\t: Randomize \"incremental\" optional boss");
                    WriteLine("\t-a\t: Randomize aggressive NPCs additionally (TODO)");
                    WriteLine("Just type random like:\nInput>>random\nOr use arguments like:\nInput>>random -m -o -2");

                    break;
                case Game.Sekiro:


                    break;
            }
        }


    }
}
