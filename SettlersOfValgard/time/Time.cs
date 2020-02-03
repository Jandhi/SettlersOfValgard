using System;

namespace SettlersOfValgard.time
{
    public class Time
    {
        public const ConsoleColor SpringColor = ConsoleColor.Green;
        public const ConsoleColor SummerColor = ConsoleColor.Yellow;
        public const ConsoleColor FallColor = ConsoleColor.Red;
        public const ConsoleColor WinterColor = ConsoleColor.Cyan;

        public static string SeasonToString(Season season)
        {
            return season switch
            {
                Season.Spring => (Console.Color(season.ToString(), SpringColor)),
                Season.Summer => (Console.Color(season.ToString(), SummerColor)),
                Season.Fall => (Console.Color(season.ToString(), FallColor)),
                Season.Winter => (Console.Color(season.ToString(), WinterColor)),
                _ => season.ToString()
            };
        }

        public const int DaysInYear = 500;
        public static int DaysInSeason => DaysInYear / 4;
        public static int DaysInCycle => DaysInSeason / 5;

        public static Age Age { get; } = new Age(0, 0);
        public static int Days => Age.Days % DaysInYear;
        public static int Years => Age.Days / DaysInYear;
        public static Season Season => (Season) (Days / DaysInSeason);
        public static Cycle Cycle => (Cycle) (Days / DaysInCycle);

        public static string Date =>
            AddOrdinal(Days % DaysInCycle) + " of " + Cycle + " (Year " + Years + " Day " + Days + ")";

        public static string AddOrdinal(int num)
        {
            if (num <= 0) return num.ToString();

            switch (num % 100)
            {
                case 11:
                case 12:
                case 13:
                    return num + "th";
            }

            switch (num % 10)
            {
                case 1:
                    return num + "st";
                case 2:
                    return num + "nd";
                case 3:
                    return num + "rd";
                default:
                    return num + "th";
            }
        }
    }
}