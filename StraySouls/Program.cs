using System;

namespace StraySouls
{
    public class Program
    {
        public static bool VOLATILE_ENABLED { get; private set; } = false;
        
        private static void Main(string[] args)
        {
            Console.WriteLine($"Version: {System.Reflection.Assembly.GetExecutingAssembly().GetName().Version}");
            Console.WriteLine("Map data folder found: {0}", DSPath.GetDS3MapStudioPath());
            Console.WriteLine("CAUTION: Type \"volatile\" to enable volatile randomization, don't use it unless you don't mind glitches");
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
            Console.WriteLine("\t-u: Unlimited mode, change enemies individually rather than simply change their positions");
            Console.WriteLine("Just type random like:\nInput>>random\nOr use arguments like:\nInput>>random -m -o -2");
            
            string command;

            while(true)
            {
                Console.Write("\nInput>>");

                command = Console.ReadLine();

                if (command == "volatile")
                {
                    VOLATILE_ENABLED ^= true;
                    Console.WriteLine($"Volatile random {(VOLATILE_ENABLED ? "enabled" : "disabled")}");
                    continue;
                }

                Console.WriteLine("Processing, DONT QUIT");
                if (CommandInput.Command(command))
                    Console.Write("Operation finished!");
                else
                    Console.Write("Check out the input, something is wrong");
                Console.Write(" Press \'r\' to do other operations\n");
                Console.WriteLine("Press other keys to exit, and remember to use UXM to patch if any changes have taken place");

                if (Console.ReadKey().Key != ConsoleKey.R)
                    break;
            }
        }
    }
}