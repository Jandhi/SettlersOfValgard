using System;
using System.Collections.Generic;
using SettlersOfValgard.time;

namespace SettlersOfValgard.command
{
    public static class InfoCommands
    {
        public static void List(Command command)
        {
            if (command.Args.Count > 0)
            {

                var arg0 = command.Args[0].ToLower();

                if (arg0 == "rank")
                {
                    foreach (var rank in Enum.GetValues(typeof(PlayerRank)))
                    {
                        Console.WriteLine(Settlement.RankToString((PlayerRank) rank));
                    }
                } 
                else if (arg0 == "settlement")
                {
                    foreach (var rank in Enum.GetValues(typeof(PlayerRank)))
                    {
                        Console.WriteLine( Console.Color(Settlement.RankToSettlement((PlayerRank) rank), Settlement.RankToColor((PlayerRank) rank)));
                    }
                }
                else if (arg0 == "season")
                {
                    foreach (var season in Enum.GetValues(typeof(Season)))
                    {
                        Console.WriteLine(Time.SeasonToString((Season) season));
                    }
                }
            }
            else
            {
                Console.WriteLine(Console.Red + "Format is: list [enum to list]");
            }
        }
    }
}