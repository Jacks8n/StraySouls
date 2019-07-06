using System;
using System.Reflection;
using StraySouls.Input;
using StraySouls.Output;

namespace StraySouls
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine($"Version: {Assembly.GetExecutingAssembly().GetName().Version}");
            Console.WriteLine("Map data folder found: {0}", GamePath.GetMapStudioPath());
            Console.WriteLine();
            CommandHelper.InputHelp();

            string command;

            while(true)
            {
                Console.Write("\nInput>>");

                command = Console.ReadLine();

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