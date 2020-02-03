using System;
using System.Collections.Generic;
using System.Linq;
using SettlersOfValgard.building;
using SettlersOfValgard.events;
using SettlersOfValgard.resource;
using SettlersOfValgard.settler;
using SettlersOfValgard.tech;
using SettlersOfValgard.time;

namespace SettlersOfValgard
{
    public class Settlement : INamed, IAgeable, IDoesRoutines
    {
        private static readonly Settlement _singleton = new Settlement();
        
        public const ConsoleColor FreemanColor = ConsoleColor.Green;
        public static string FreemanSettlement = "Homestead";
        
        public const int HuskarlThreshold = 20;
        public const ConsoleColor HuskarlColor = ConsoleColor.Blue;
        public static string HuskarlSettlement = "Farmstead";
        
        public const int GothiThreshold = 50;
        public const ConsoleColor GothiColor = ConsoleColor.Cyan;
        public static string GothiSettlement = "Hamlet";
        
        public const int HirdmanThreshold = 100;
        public const ConsoleColor HirdmanColor = ConsoleColor.Red;
        public static string HirdmanSettlement = "Village";
        
        public const int ThegnThreshold = 200;
        public const ConsoleColor ThegnColor = ConsoleColor.Magenta;
        public static string ThegnSettlement = "Town";
        
        public const int JarlThreshold = 500;
        public const ConsoleColor JarlColor = ConsoleColor.DarkYellow;
        public static string JarlSettlement = "Hold";
        
        public const int KonungrThreshold = 1000;
        public const ConsoleColor KonungrColor = ConsoleColor.Yellow;
        public static string KonungrSettlement = "Capital";

        public PlayerRank Rank
        {
            get
            {
                if (Settlers.Count < HuskarlThreshold) return PlayerRank.Freeman;
                if (Settlers.Count < GothiThreshold) return PlayerRank.Huskarl;
                if (Settlers.Count < HirdmanThreshold) return PlayerRank.Gothi;
                if (Settlers.Count < ThegnThreshold) return PlayerRank.Hirdman;
                if (Settlers.Count < JarlThreshold) return PlayerRank.Thegn;
                return Settlers.Count < KonungrThreshold ? PlayerRank.Jarl : PlayerRank.Konungr;
            }
        }

        public static ConsoleColor RankToColor(PlayerRank rank)
        {
            return rank switch
            {
                PlayerRank.Freeman => FreemanColor,
                PlayerRank.Huskarl => HuskarlColor,
                PlayerRank.Gothi => GothiColor,
                PlayerRank.Hirdman => HirdmanColor,
                PlayerRank.Thegn => ThegnColor,
                PlayerRank.Jarl => JarlColor,
                PlayerRank.Konungr => KonungrColor,
                _ => ConsoleColor.White
            };
        }

        public static string RankToString(PlayerRank rank)
        {
            return Console.Color(rank.ToString(), RankToColor(rank));
        }
        
        public static string RankToSettlement(PlayerRank rank)
        {
            return rank switch
            {
                PlayerRank.Huskarl => HuskarlSettlement,
                PlayerRank.Gothi => GothiSettlement,
                PlayerRank.Hirdman => HirdmanSettlement,
                PlayerRank.Thegn => ThegnSettlement,
                PlayerRank.Jarl => JarlSettlement,
                PlayerRank.Konungr => KonungrSettlement,
                _ => FreemanSettlement
            };
        }

        public string Name { get; set; }
        public string PlayerName { get; set; }

        public string SettlementRank => Console.Color(RankToSettlement(Rank), RankToColor(Rank));
        public Age Age { get; } = new Age();
        
        public List<Building> Buildings = new List<Building>();
        public List<Settler> Settlers = new List<Settler>();
        public int StarveCount;
        public StockPile StockPile = new StockPile();

        public TechManager TechManager = new TechManager();

        public int EatCount;
        public int HomelessCount;
        public int IdleCount;

        private Settlement()
        {
        }

        public void DayRoutine()
        {
            foreach (var settler in Settlers) settler.DayRoutine();

            if (IdleCount > 0) SettlementEvents.Idle(IdleCount);
        }

        public void EveningRoutine()
        {
            FeedSettlers();
            if (StarveCount > 0) SettlementEvents.Starved(StarveCount);

            foreach (var settler in Settlers) settler.EveningRoutine();
        }

        public void NightRoutine()
        {
            foreach (var settler in Settlers) settler.NightRoutine();

            if (HomelessCount > 0) SettlementEvents.Homeless(HomelessCount);
        }

        public static Settlement Get()
        {
            return _singleton;
        }

        public void PassTime()
        {
            ResetCounts();
            DayRoutine();
            EveningRoutine();
            NightRoutine();
            StockPile.SumTodaysTransactions();
            StockPile.DailyStockPileTally();
            StockPile.ArchiveTransactions();
            DoAging();
        }

        public void ResetCounts()
        {
            EatCount = 0;
            StarveCount = 0;
            IdleCount = 0;
            HomelessCount = 0;
        }

        public void FeedSettlers()
        {
            foreach (var lifeStage in SettlementSettings.FeedOrder)
            foreach (var settler in Settlers.Where(settler => settler.LifeStage == lifeStage))
                settler.Eat();

            if (EatCount > 0) SettlementEvents.FedSettlers(EatCount);
        }

        public void DoAging()
        {
            Time.Age.doAging(); // Time passes
            Age.doAging(); // Settlement ages
            foreach (var settler in Settlers) settler.Age.doAging();
            foreach (var building in Buildings) building.Age.doAging();
        }
    }

    public enum PlayerRank
    {
        Freeman,
        Huskarl,
        Gothi,
        Hirdman,
        Thegn,
        Jarl,
        Konungr
    }
}