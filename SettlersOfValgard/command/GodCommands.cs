using System;
using SettlersOfValgard.settler;

namespace SettlersOfValgard.command
{
    public static class GodCommands
    {
        public static void GodMode(Command command)
        {
            if (Settings.GodMode)
            {
                Settings.GodMode = false;
                Console.WriteLine("GodMode disabled.");
            }
            else
            {
                string input;
                Console.WriteLine("Enter GodMode? (y/n)");
                input = Console.ReadLine();

                while (input != "y" && input != "n")
                {
                    Console.Clear();
                    Console.WriteLine(Console.Color("Invalid input!", ConsoleColor.Red));
                    Console.WriteLine("Enter GodMode? (y/n)");
                    input = Console.ReadLine();
                }

                if (input == "y")
                {
                    Settings.GodMode = true;
                    Console.WriteLine("GodMode enabled.");
                }
            }
        }
        
        public static void Generate(Command command)
        {
            if (Settings.GodMode)
            {
                Console.WriteLine(SettlerFactory.Get().ToString());
            }
            else
            {
                Console.WriteLine(Console.Color("The command \"gen\" requires GodMode!", ConsoleColor.Red));
                Console.WriteLine("(Use \"god\" to enable GodMode)");
            }
        }
    }
}