using System.Collections.Generic;
using SettlersOfValgard.building.harvest;
using SettlersOfValgard.building.Residential;
using SettlersOfValgard.command;
using SettlersOfValgard.events;
using SettlersOfValgard.settler;
using SettlersOfValgard.tech;

namespace SettlersOfValgard
{
    internal class Program
    {
        private static Settlement _settlement;
        public static bool EndGame = false;

        private static void Main(string[] args)
        {
            Init();
            //SettlersOfValgard.Menu();
            
            Settlement.Get().TechManager.Discover(new BasicTech());
            var hut = new HuntersHut();
            var valin = new Settler("Valin", 20, Gender.Male);
            valin.Work = hut;
            Settlement.Get().Buildings.Add(hut);
            Settlement.Get().Settlers.Add(valin);
            

            while (!EndGame)
            {
                var input = Console.ReadLine();
                Console.Clear();
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
                if (split[i].StartsWith("-"))
                    tags.Add(split[i]);
                else
                    args.Add(split[i]);
            Command.ExecuteCommand(new Command(command, args, tags));
        }

        public static void Init()
        {
            EventManager.InitializeLists();
        }
    }
}