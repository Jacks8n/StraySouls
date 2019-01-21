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
            Console.WriteLine("\t-m: Randomize main boss additionally");
            Console.WriteLine("\t-o: Randomize optional boss additionally");
            Console.WriteLine("\t-f: Randomize friendly NPCs additionally (TODO)");
            Console.WriteLine("\t-a: Randomize aggressive NPCs additionally (TODO)");

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