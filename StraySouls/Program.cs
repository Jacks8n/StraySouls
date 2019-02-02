using System;

namespace StraySouls
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Map data folder found: {0}", DSPath.GetDS3MapStudioPath());
            Console.WriteLine();
            Console.WriteLine("Enter \"random\" to start randomizing");
            Console.WriteLine("Enter \"backup\" to start creating backups");
            Console.WriteLine("Enter \"restore\" to start restoring");
            Console.WriteLine("Available \"random\" arguments:");
            Console.WriteLine("\t-m\t: Randomize main boss additionally");
            Console.WriteLine("\t-o\t: Randomize optional boss additionally");
            Console.WriteLine("\t-f\t: Randomize friendly NPCs additionally (TODO)");
            Console.WriteLine("\t-a\t: Randomize aggressive NPCs additionally (TODO)");
            Console.WriteLine("\t-2 ~ -9\t: Multiply enemies by the number given, for example, -3 means multiplying enemies by three times");
            Console.WriteLine("Just type random like:\nInput>>random\nOr use arguments like:\nInput>>random -m -o -2");

            bool ifContinue = false;
            do
            {
                Console.Write("\nInput>>");

                string command = Console.ReadLine();

                Console.WriteLine("Processing, DONT QUIT");
                if (CommandInput.Command(command))
                    Console.Write("Operation finished!");
                else
                    Console.Write("Check out the input, something is wrong.");
                Console.Write(" Press \'r\' to do other operations\n");
                Console.WriteLine("Press other keys to exit, and remember to use UXM to patch if any changes have taken place");

                ifContinue = Console.ReadKey().Key == ConsoleKey.R;
            } while (ifContinue);
        }
    }
}