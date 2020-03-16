using SettlersOfValgard.Model.Name;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Rank
{
    public class PlayerRank : CustomEnum
    {
        public static readonly PlayerRank Freeman = new PlayerRank("Freeman", 0, CustomConsole.Green);
        public static readonly PlayerRank Chieftain = new PlayerRank("Chieftain", 1, CustomConsole.Cyan);
        public static readonly PlayerRank Gothi = new PlayerRank("Gothi", 2, CustomConsole.Gray);
        public static readonly PlayerRank Thane = new PlayerRank("Thane", 3, CustomConsole.Magenta);
        public static readonly PlayerRank Jarl = new PlayerRank("Jarl", 4, CustomConsole.Red);
        public static readonly PlayerRank Konungr = new PlayerRank("Konungr", 5, CustomConsole.Yellow);
        public static readonly PlayerRank[] Ranks = {Freeman, Chieftain, Gothi, Thane, Jarl, Konungr};

        public static PlayerRank GetRank(int population)
        {
            if (population < 50)
            {
                return Freeman;
            } 
            else if (population < 100)
            {
                return Chieftain;
            }
            else if (population < 200)
            {
                return Gothi;
            }
            else if (population < 500)
            {
                return Thane;
            }
            else if (population < 1000)
            {
                return Jarl;
            }
            else return Konungr;
        }

        private PlayerRank(string name, int value, string color) : base(name, value, color)
        {
        }
    }
}