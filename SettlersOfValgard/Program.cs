using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.CompilerServices;
using SettlersOfValgard.building;
using SettlersOfValgard.resource;
using SettlersOfValgard.settler;
using SettlersOfValgard.time;

namespace SettlersOfValgard
{
    class Program
    {
        private static Settlement _settlement;
        public static bool EndGame = false;
        
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
            
            _settlement.StockPile.Add(Resource.Meat, 200);

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
            Command.ExecuteCommand(command, args, tags);
        }
    }
}