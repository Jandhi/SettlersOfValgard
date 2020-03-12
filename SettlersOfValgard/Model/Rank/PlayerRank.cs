using System;
using SettlersOfValgard.Model.Name;

namespace SettlersOfValgard.Model.Rank
{
    public class PlayerRank : INamed
    {
        public static readonly PlayerRank Freeman = new PlayerRank($"{ConsoleColor.Green}Freeman{ConsoleColor.White}");
        public static readonly PlayerRank Chieftain = new PlayerRank($"{ConsoleColor.Cyan}Chieftain{ConsoleColor.White}");
        public static readonly PlayerRank Gothi = new PlayerRank($"{ConsoleColor.Gray}Gothi{ConsoleColor.White}");
        public static readonly PlayerRank Thane = new PlayerRank($"{ConsoleColor.Magenta}Thane{ConsoleColor.White}");
        public static readonly PlayerRank Jarl = new PlayerRank($"{ConsoleColor.Red}Jarl{ConsoleColor.White}");
        public static readonly PlayerRank Konungr = new PlayerRank($"{ConsoleColor.Yellow}Konungr{ConsoleColor.White}");
            
        private PlayerRank(string name)
        {
            Name = name;
        }

        /*Chieftain,
        Gothi,
        Thane,
        Jarl,
        King;
        */
        public string Name { get; }
    }
}