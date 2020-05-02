using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic.CompilerServices;
using SettlersOfValgard.Model.Name;
using SettlersOfValgard.UtilLibrary;
using SettlersOfValgard.View.Commands.Core;

namespace SettlersOfValgard.View
{
    public class IOManager
    {
        private static readonly string[] Yes = {"y", "Y", "yes", "Yes"};
        private static readonly string[] No = {"n", "N", "no", "No"};
        
        public static List<string> PreviousList { get; set; } = new List<string>();
        public static readonly CommandManager CommandManager = new CommandManager();

        private const string ListOption = "list";

        public static string GetName(string query)
        {
            CustomConsole.WriteLine(query);
            var s = CustomConsole.ReadLine();

            while (s.Trim().Length < 1)
            {
                CustomConsole.WriteLine($"{CustomConsole.Red}ERROR: A name cannot be empty!");
                CustomConsole.WriteLine(query);
                s = CustomConsole.ReadLine();
            }
            
            return s.Trim();
        }

        public static bool GetYesNo(string question)
        {
            CustomConsole.WriteLine($"{question} [y/n]");
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

            //Remove extra whitespace
            for (int i = 0; i < input.Length; i++)
            {
                input[i] = input[i].Replace(" ", "");
            }
            
            input = input.Where(i => !i.Equals("")).ToArray(); // Remove empty inputs
            
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

        public static void ListInConsole<T>(IEnumerable<T> list, bool numbered = false, bool separated = false, Func<T, string> func = null)
            where T : INamed
        {
            if (!separated)
            {
                //Converts to dictionary
                var dictionary = new Dictionary<string, List<T>>();
                foreach (var item in list)
                    if (!dictionary.ContainsKey(item.Name))
                        dictionary.Add(item.Name, new List<T>{item});
                    else
                        dictionary[item.Name].Add(item);

                //Outputs
                var count = 1;
                PreviousList = new List<string>();
                foreach (var (name, items) in dictionary)
                {
                    if (numbered)
                    {
                        CustomConsole.Write($"{count} ");
                    }
                    
                    CustomConsole.Write($"{name}");
                    CustomConsole.Write(items.Count > 1 ? $" x{items.Count}" : ""); // amount
                    CustomConsole.Write(func == null ? "" : $" {func(items[0])}"); // additional function
                    CustomConsole.WriteLine();
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

        public static T ChooseItemFromList<T>(IEnumerable<T> enumerable, Func<T, string> labelFunc)
        {
            var list = enumerable.ToList();
            
            var number = 1;
            foreach (var t in list)
            {
                CustomConsole.WriteLine($"{number}: {labelFunc(t)}");
                number++;
            }

            while (true)
            {
                var input = CustomConsole.ReadLine().Trim();

                try
                {
                    var index = int.Parse(input) - 1;
                    return list[index];
                }
                catch (FormatException e)
                {
                    if (input != ListOption)
                    {
                        CustomConsole.WriteLine($"{CustomConsole.Red}ERROR: Must provide the index of an item on the list!");
                    }
                }
                
                number = 1;
                foreach (var t in list)
                {
                    CustomConsole.WriteLine($"{number}: {labelFunc(t)}");
                    number++;
                }
            }
        }
    }
}