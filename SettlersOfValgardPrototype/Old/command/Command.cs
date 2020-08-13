using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.CompilerServices;

namespace SettlersOfValgard.command
{
    public class Command
    {
        public string Name;
        public List<string> Args;
        public List<string> Tags;

        public Command(string name, List<string> args, List<string> tags)
        {
            Name = name;
            Args = args;
            Tags = tags;
        }

        public static void ExecuteCommand(Command command)
        {
            FormatArgs(command.Args);
            WriteInput(command);


            switch (command.Name)
            {
                case "s":
                    SettlementCommands.Settlers(command);
                    break;
                case "b":
                    SettlementCommands.Buildings(command);
                    break;
                case "bd":
                    SettlementCommands.Build(command);
                    break;
                case "h":
                    SettlementCommands.Home(command);
                    break;
                case "d":
                    SettlementCommands.PassDays(command);
                    break;
                case "sp":
                    StockPileCommands.StockPile(command);
                    break;
                case "q":
                    ProgramCommands.Quit(command);
                    break;
                case "god":
                    GodCommands.GodMode(command);
                    break;
                case "gen":
                    GodCommands.Generate(command);
                    break;
                case "list":
                    InfoCommands.List(command);
                    break;
            }
        }

        public static void WriteInput(Command command)
        {
            var consoleInput = command.Name;
            foreach (var arg in command.Args) consoleInput += " " + arg;
            foreach (var tag in command.Tags) consoleInput += " " + tag;
            Console.WriteLine(consoleInput);
        }

        public static void FormatArgs(List<string> args)
        {
            for (var i = 0; i < args.Count; i++)
                if (args[i].StartsWith("$"))
                    try
                    {
                        var index = IntegerType.FromString(args[i].Substring(1));
                        args[i] = Console.PreviousList[index - 1]; // Starts at 1 rather than 0
                    }
                    catch (Exception e)
                    {
                    }
        }
    }
}