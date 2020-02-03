using System;
using System.Reflection.Emit;
using SettlersOfValgard.settler;
using SettlersOfValgard.tech;

namespace SettlersOfValgard
{
    public class SettlersOfValgard
    {
        public const ConsoleColor TitleColor = ConsoleColor.Cyan;
        
        public static void Menu()
        {
            Console.WriteLine("Welcome to " + Console.Color("Settlers of Valgard", TitleColor));
            
            Input:
            Console.WriteLine("To start a settlement, enter \"s\"");
            string input = Console.ReadLine();
            while (input != "s" && input != "o")
            {
                Console.WriteLine(Console.Red + "Invalid entry!");
                Console.WriteLine("To see your options again, enter \"o\"");
                input = Console.ReadLine();
            }

            if (input == "o")
            {
                Console.Clear();
                goto Input;
            }
            if (input == "s")
            {
                Console.Clear();
                Intro();
            }
        }

        public static void Intro()
        {
            var settlement = Settlement.Get();
            Console.WriteLine("The year is 59 after Vallr's landing. " +
                              "With the melt of the mountain passes, you and your group of fellow settlers " +
                              "crossed the Red Mountains and reached Dalland, the \"land of valleys\"...");
            Console.ReadLine();
            Console.WriteLine("This is where you will settle down.");
            Console.WriteLine(Settlement.RankToString(settlement.Rank) + Console.White + ", what is your name?");
            SetPlayerName(Console.ReadLine());
            Console.WriteLine("Hail, " + Settlement.RankToString(settlement.Rank) + " " + settlement.PlayerName);
            Console.WriteLine("What shall we name our settlement?");
            SetSettlementName(Console.ReadLine());
            Console.Clear();
            new BasicTech().GetDiscovered(settlement.TechManager);
            Console.WriteLine("Welcome to the " + settlement.SettlementRank + " of " + settlement.Name);
        }

        private static void SetPlayerName(string input)
        {
            var name = input;
            
            if (input == "?")
            {
                var gender = (Gender) Random.Weighted(SettlementSettings.GenderWeights);
                name = new VarskNameFactory().GetSettlerName(gender, 30);
            } 
            else if (input == "?M")
            {
                name = new VarskNameFactory().GetSettlerName(Gender.Male, 30);
            }
            else if (input == "?F")
            {
                name = new VarskNameFactory().GetSettlerName(Gender.Female, 30);
            }
            else if (input == "?X")
            {
                name = new VarskNameFactory().GetSettlerName(Gender.NonConforming, 30);
            }

            Settlement.Get().PlayerName = name;
        }

        public static void SetSettlementName(string input)
        {
            var name = input;
            
            Settlement.Get().Name = name;
        }
    }
}