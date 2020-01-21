using System;

namespace SettlersOfValgard.settler
{
    public enum SkillType
    {
        Woodcutting,
        Hunting
    }

    public enum SkillLevel
    {
        Unskilled,
        Novice,
        Apprentice,
        Journeyman,
        Expert,
        Master
    }
    
    public class Skill
    {
        public const int NoviceXpThreshold = 20;
        public const int ApprenticeXpThreshold = 100;
        public const int JourneymanXpThreshold = 300;
        public const int ExpertXpThreshold = 600;
        public const int MasterXpThreshold = 1000;
        
        public SkillType Type;
        public int Xp { get; set; }  = 0;

        public SkillLevel Level
        {
            get
            {
                if (Xp < NoviceXpThreshold) return SkillLevel.Unskilled;
                if (Xp < ApprenticeXpThreshold) return SkillLevel.Novice;
                if (Xp < JourneymanXpThreshold) return SkillLevel.Apprentice;
                if (Xp < ExpertXpThreshold) return SkillLevel.Journeyman;
                if (Xp < MasterXpThreshold) return SkillLevel.Expert;
                return SkillLevel.Master;
            }
        }

        public void GainXp(int xp)
        {
            Xp += xp;
        }

        public static string LevelToString(SkillLevel level)
        {
            switch (level)
            {
                case SkillLevel.Novice:
                    return Console.Color(SkillLevel.Novice.ToString(), ConsoleColor.Green);
                case SkillLevel.Apprentice:
                    return Console.Color(SkillLevel.Apprentice.ToString(), ConsoleColor.Cyan);
                case SkillLevel.Journeyman:
                    return Console.Color(SkillLevel.Journeyman.ToString(), ConsoleColor.Red);
                case SkillLevel.Expert:
                    return Console.Color(SkillLevel.Expert.ToString(), ConsoleColor.Blue);
                case SkillLevel.Master:
                    return Console.Color(SkillLevel.Master.ToString(), ConsoleColor.Yellow);
                default:
                    return Console.Color(SkillLevel.Unskilled.ToString(), ConsoleColor.Gray);
            }
        }
    }
}