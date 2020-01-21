using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.CompilerServices;
using SettlersOfValgard.building;
using SettlersOfValgard.settler;
using SettlersOfValgard.time;

namespace SettlersOfValgard
{
    class Program
    {
        private static Settlement _settlement;
        
        private static bool _endGame = false;
        private static int _maxDaysPassed = 30;
        static void Main(string[] args)
        {
            _settlement = Settlement.Get();
            
            _settlement.Buildings.Add(new ResidentialBuilding("House", 5));
            _settlement.Buildings.Add(new ResidentialBuilding("House", 5));
            _settlement.Buildings.Add(new ResidentialBuilding("Tent", 3));
            _settlement.Buildings.Add(new WorkBuilding("Woodcutter's Hut", 5));
            _settlement.Buildings.Add(new WorkBuilding("Hunter's Tent", 3));
            
            _settlement.Settlers.Add(new Settler("Eriksen", 30));
            _settlement.Settlers.Add(new Settler("Rudolf", 30));
            _settlement.Settlers.Add(new Settler("Alfa", 30));
            _settlement.Settlers.Add(new Settler("Ylur", 30));
            _settlement.Settlers.Add(new Settler("Arngeir", 30));
            _settlement.Settlers.Add(new Settler("Falka", 30));
            _settlement.Settlers.Add(new Settler("Geirr", 30));
            _settlement.Settlers.Add(new Settler("Valmunda", 30));

            while (!_endGame)
            {
                var input = Console.ReadLine();
                Console.Clear();
                Console.WriteLine(input);
                ParseInput(input);
            }
        }

        private static void ParseInput(string input)
        {
            var split = input.Split(" ");
            var command = split[0];
            var args = new List<string>();
            var tags = new List<string>();
            for (var i = 1; i < split.Length; i++)
            {
                if (split[i].StartsWith("-"))
                {
                    tags.Add(split[i]);
                }
                else
                {
                    args.Add(split[i]);
                }
            }
            ExecuteCommand(command, args, tags);
        }

        private static void ExecuteCommand(string command, List<string> args, List<string> tags)
        {
            if (command == "s")
            {
                ListInConsole(_settlement.Settlers);
            }

            if (command == "b")
            {
                ListInConsole(_settlement.Buildings);
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
                        if(days <= _maxDaysPassed) {
                            PassDays(days);
                        }
                        else
                        {
                            Console.WriteLine(Console.Red + "Maximum days you can pass is " + _maxDaysPassed);
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
                _endGame = true;
            }
        }

        private static void PassDays(int days)
        {
            for (var i = 0; i < days; i++)
            {
                Console.WriteLine();
                _settlement.PassTime();
                Console.WriteLine(Time.Date + ":");
                EventManager.ListEvents();
                EventManager.ArchiveEvents();
                System.Threading.Thread.Sleep(100);
            }
        }

        private static void ListInConsole<T> (IEnumerable<T> list) where T : INamed 
        {
            foreach (var item in list)
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}