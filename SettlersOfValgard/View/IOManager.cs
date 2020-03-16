using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic.CompilerServices;
using SettlersOfValgard.Model.Name;
using SettlersOfValgard.UtilLibrary;
using SettlersOfValgard.View.Command;

namespace SettlersOfValgard.View
{
    public class IOManager
    {
        private static readonly string[] Yes = {"y", "Y", "yes", "Yes"};
        private static readonly string[] No = {"n", "N", "no", "No"};
        
        public static List<string> PreviousList { get; set; } = new List<string>();
        public static readonly CommandManager CommandManager = new CommandManager();

        public static string GetName()
        {
            return CustomConsole.ReadLine();
        }

        public static bool GetYesNo(string question)
        {
            CustomConsole.WriteLine(question);
            string input = CustomConsole.ReadLine();
            while (!Yes.Contains(input) && !No.Contains(input))
            {
                CustomConsole.WriteLine($"{CustomConsole.Red}ERROR: You must answer y/n!");
                CustomConsole.WriteLine(question);
                input = CustomConsole.ReadLine();
            }

            return Yes.Contains(input);
        }

        public static void GetCommand(Game game)
        {
            var inputLine = CustomConsole.ReadLine();
            var input = inputLine.Split(" ");
            
            if (input.Length <= 0) return; // Don't take empty lines
            
            var command = input[0];
            CommandManager.FindAndExecute(command, ParseArgs(input), game);
        }

        private static string [] ParseArgs(string [] input)
        {
            var args = new string[input.Length - 1];
            for (var i = 0; i < input.Length - 1; i++)
            {
                args[i] = input[i + 1];
                
                if (args[i].StartsWith("$"))
                {
                    try
                    {
                        int num = IntegerType.FromString(args[i].Substring(1));
                        if (num < PreviousList.Count)
                        {
                            args[i] = PreviousList[num];
                        }
                    }
                    catch (InvalidCastException e)
                    {
                        //Don't switch
                    }
                }
            }

            return args;
        }

        public static void ListInConsole<T>(T[] arr, bool numbered = false, bool separated = false) 
            where T : INamed
        {
            ListInConsole<T>(new List<T>(arr), numbered, separated);
        }

        public static void ListInConsole<T>(IEnumerable<T> list, bool numbered = false, bool separated = false)
            where T : INamed
        {
            if (!separated)
            {
                //Converts to dictionary
                var dictionary = new Dictionary<string, int>();
                foreach (var name in list.Select(item => item.ToString()))
                    if (!dictionary.ContainsKey(name))
                        dictionary.Add(name, 1);
                    else
                        dictionary[name] += 1;

                //Outputs
                var count = 1;
                PreviousList = new List<string>();
                foreach (var (name, amount) in dictionary)
                {
                    if (numbered)
                    {
                        CustomConsole.Write(count + " ");
                    }
                    CustomConsole.WriteLine(name + (amount > 1 ? " x" + amount : ""));
                    count++;
                    PreviousList.Add(name);
                }
            }
            else
            {
                var count = 1;
                PreviousList = new List<string>();
                foreach (var name in list.Select(item => item.ToString()))
                {
                    if (numbered)
                    {
                        CustomConsole.Write(count + " ");
                    }
                    CustomConsole.WriteLine(name);
                    count++;
                    PreviousList.Add(name);
                }
            }
        }
    }
}