using System;
using System.Collections.Generic;
using System.Linq;
using SettlersOfValgard.Util;

/*
 * Class to get input from player
 */
namespace SettlersOfValgard.Interface.Console
{
    public static class VInput
    {
        public static List<INamed> PreviousList { get; set; }

        public static string[] GetArgs()
        {
            var input = System.Console.ReadLine();
            var args = input.Split(" ").ToList();
            args = args.Where(arg => arg != "").ToList(); // Filter out empties
            args = args.Select(Modify).ToList(); // Modifies arguments
            return args.ToArray();
        }

        //Modifies input arguments
        private static string Modify(string arg)
        {
            if (arg.StartsWith("$"))
            {
                try
                {
                    var index = int.Parse(arg.Substring(1));
                    if (PreviousList.Count < index)
                    {
                        new GameError($"The index {index} is out of bounds!").Execute();
                    }
                    else
                    {
                        return PreviousList[index].Name;
                    }
                }
                catch (FormatException e)
                {
                    return arg;
                }
            }
            return arg;
        }

        public static string WaitForKey()
        {
            VConsole.WriteLine("Press any key to continue...");
            return System.Console.ReadKey().ToString();
        }
    }
}