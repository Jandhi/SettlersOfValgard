using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.VisualBasic.CompilerServices;
using SettlersOfValgard.building;
using SettlersOfValgard.events;
using SettlersOfValgard.resource;
using SettlersOfValgard.time;

namespace SettlersOfValgard.command
{
    public static class SettlementCommands
    {
        public static void Settlers(Command command)
        {
            var numbered = command.Tags.Contains("-n");
            var separated = command.Tags.Contains("-s");
            Console.ListInConsole(Settlement.Get().Settlers, numbered, separated);
        }

        public static void Buildings(Command command)
        {
            var numbered = command.Tags.Contains("-n");
            var separated = command.Tags.Contains("-s");
            Console.ListInConsole(Settlement.Get().Buildings, numbered, separated);
        }

        public static void Build(Command command)
        {
            if(command.Args.Count == 0) {
                var numbered = command.Tags.Contains("-n");
                Console.ListInConsole(Settlement.Get().TechManager.UnlockedBuildings, numbered);
            }
            else
            {
                var buildingName = command.Args[0];
                for (var i = 1; i < command.Args.Count; i++) buildingName += " " + command.Args[i];
                
                var building = Settlement.Get().TechManager.UnlockedBuildings.FirstOrDefault(unlocked => string.Equals(unlocked.Name,buildingName, StringComparison.CurrentCultureIgnoreCase));

                if (building == null)
                {
                    Console.WriteLine(Console.Color("Unknown building!", ConsoleColor.Red));
                    Console.WriteLine("Use \"bd\" to list available buildings");
                }
                else
                {
                    if (Settlement.Get().StockPile.Has(building.Cost))
                    {
                        //TODO Build building
                        Settlement.Get().StockPile.Remove(building.Cost);
                        Settlement.Get().Buildings.Add(building.BuildNew());
                    }
                    else
                    {
                        Console.WriteLine(Console.Color("You don't have the required resources!", ConsoleColor.Red));
                        Console.WriteLine(building.Name + " Cost: " + building.Cost.ToLine());
                    }
                }
            }
        }

        public static void Home(Command command)
        {
            if (command.Args.Count == 0)
            {
                var numbered = command.Tags.Contains("-n");
                var list = Settlement.Get().Buildings.FindAll(building => building is ResidentialBuilding);
                if(list.Count > 0) {
                    Console.ListInConsole(list, numbered);
                }
                else
                {
                    Console.WriteLine("You don't have any homes.");
                }
            }
        }
        
        public static void PassDays(Command command)
        {
            if (command.Args.Count == 0)
                PassDaysHelper(1);
            else
                try
                {
                    var days = IntegerType.FromString(command.Args[0]);
                    if (days <= Settings.MaxDaysPassed)
                    {
                        PassDaysHelper(days);
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

        private static void PassDaysHelper(int days)
        {
            for (var i = 0; i < days; i++)
            {
                Settlement.Get().PassTime();
                Console.WriteLine(Time.Date + ":");
                EventManager.ListEvents();
                EventManager.ArchiveEvents();
                Thread.Sleep(100);
                if(i < days - 1) Console.WriteLine("---"); // Lines between days
            }
        }
    }
}