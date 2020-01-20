using System;
using System.Collections.Generic;
using SettlersOfValgard.building;

namespace SettlersOfValgard
{
    class Program
    {
        static void Main(string[] args)
        {
            Settlement settlement = new Settlement();
            
            settlement.Buildings.Add(new ResidentialBuilding("House", 5));
            settlement.Buildings.Add(new ResidentialBuilding("House", 5));
            settlement.Buildings.Add(new ResidentialBuilding("Tent", 3));
            settlement.Buildings.Add(new WorkBuilding("Woodcutter's Hut", 5));
            settlement.Buildings.Add(new WorkBuilding("Hunter's Tent", 3));
            
            settlement.Settlers.Add(new Settler("Eriksen"));
            settlement.Settlers.Add(new Settler("Rudolf"));
            settlement.Settlers.Add(new Settler("Alfa"));
            settlement.Settlers.Add(new Settler("Ylur"));
            settlement.Settlers.Add(new Settler("Arngeir"));
            settlement.Settlers.Add(new Settler("Falka"));
            settlement.Settlers.Add(new Settler("Geirr"));
            settlement.Settlers.Add(new Settler("Valmunda"));
            
            while (true)
            {
                string command = Console.ReadLine();
                Console.Clear();
                Console.WriteLine(command);

                if (command == "s")
                {
                    ListInConsole(settlement.Settlers);
                }

                if (command == "b")
                {
                    ListInConsole(settlement.Buildings);
                }
            }
        }
        
        static void ListInConsole<T> (List<T> list) where T : Named 
        {
            foreach (var item in list)
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}