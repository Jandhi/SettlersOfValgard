using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic.CompilerServices;
using SettlersOfValgard.CustomConsoleLibrary;
using SettlersOfValgard.Model.Name;

namespace SettlersOfValgard.View
{
    public class IOManager
    {
        private static readonly string[] Yes = {"y", "Y", "yes", "Yes"};
        private static readonly string[] No = {"n", "N", "no", "No"};
        
        public static List<string> PreviousList { get; set; } = new List<string>();
        private static CommandManager _commandManager = new CommandManager();

        public static string ReceiveName()
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

        public static void ReceiveCommmands()
        {
            var inputLine = CustomConsole.ReadLine();
            var input = inputLine.Split(" ");
            
            if (input.Length <= 0) return; // Don't take empty lines
            
            var command = input[0];
            _commandManager.FindAndExecute(command, ParseArgs(input));
        }

        private static string [] ParseArgs(string [] input)
        {
            var args = new string[input.Length - 1];
            for (var i = 1; i < input.Length; i++)
            {
                args[0] = input[1];
                
                if (args[0].StartsWith("$"))
                {
                    try
                    {
                        int num = IntegerType.FromString(args[0].Substring(1));
                        if (num < PreviousList.Count)
                        {
                            args[0] = PreviousList[num];
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

        public static void ListInConsole<T>(List<T> list, bool numbered = false, bool separated = false)
            where T : INamed
        {
            if (!separated)
            {
                //Converts to dictionary
                var dictionary = new Dictionary<string, int>();
                foreach (var name in list.Select(item => item.Name))
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
                foreach (var name in list.Select(item => item.Name))
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