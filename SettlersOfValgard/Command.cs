using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.CompilerServices;
using SettlersOfValgard.time;

namespace SettlersOfValgard
{

    public class Command
    {
        public static void ExecuteCommand(string command, List<string> args, List<string> tags)
        {
            FormatArgs(args);
            WriteInput(command, args, tags);
            
            
            if (command == "s")
            {
                var numbered = tags.Contains("-n");
                Console.ListInConsole(Settlement.Get().Settlers, numbered);
            }

            if (command == "b")
            {
                var numbered = tags.Contains("-n");
                Console.ListInConsole(Settlement.Get().Buildings, numbered);
            }

            if (command == "d")
            {
                if (args.Count == 0)
                {
                    Console.WriteLine(Console.Red + "Format is: d [#number of days]");
                }
                else
                {
                    try
                    {
                        var days = IntegerType.FromString(args[0]);
                        if(days <= Settings.MaxDaysPassed) {
                            PassDays(days);
                        }
                        else
                        {
                            Console.WriteLine(Console.Red + "Maximum days you can pass is " + Settings.MaxDaysPassed);
                            Console.WriteLine("Change maxDaysPassed with ");
                        }
                    }
                    catch (InvalidCastException e)
                    {
                        Console.WriteLine(Console.Red + "Format is: d [#number of days]");
                    }
                }
            }

            if (command == "q")
            {
                Console.WriteLine("Goodbye!");
                Program.EndGame = true;
            }

            if (command == "god")
            {
                if(Settings.GodMode)
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
                    }
                }
            }
        }

        public static void WriteInput(string command, List<string> args, List<string> tags)
        {
            string consoleInput = command;
            foreach (var arg in args)
            {
                consoleInput += " " + arg;
            }
            foreach (var tag in tags)
            {
                consoleInput += " " + tag;
            }
            Console.WriteLine(consoleInput);
        }

        public static void FormatArgs(List<string> args)
        {
            for (int i = 0; i < args.Count; i++)
            {
                if (args[i].StartsWith("$"))
                {
                    try
                    {
                        int index = IntegerType.FromString(args[i].Substring(1));
                        args[i] = Console.PreviousList[index];
                    }
                    catch (Exception e)
                    {
                        continue;
                    }
                }
            }
        }

        private static void PassDays(int days)
        {
            for (var i = 0; i < days; i++)
            {
                Console.WriteLine();
                Settlement.Get().PassTime();
                Console.WriteLine(Time.Date + ":");
                EventManager.ListEvents();
                EventManager.ArchiveEvents();
                System.Threading.Thread.Sleep(100);
            }
        }
    }
}