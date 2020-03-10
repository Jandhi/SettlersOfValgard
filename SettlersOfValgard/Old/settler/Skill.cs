using System;
using System.Runtime.CompilerServices;

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

    public interface ISkillIncreaseListener
    {
        void SkillIncreased(Skill skill);
    }

    public class Skill
    {
        public const int NoviceXpThreshold = 20;
        public const int ApprenticeXpThreshold = 100;
        public const int JourneymanXpThreshold = 300;
        public const int ExpertXpThreshold = 600;
        public const int MasterXpThreshold = 1000;
        private readonly ISkillIncreaseListener _listener;

        public SkillType Type;

        public Skill(ISkillIncreaseListener listener, SkillType type)
        {
            _listener = listener;
            Type = type;
        }

        public static int[] Thresholds
        {
            get
            {
                return new[]
                {
                    NoviceXpThreshold, ApprenticeXpThreshold, JourneymanXpThreshold, ExpertXpThreshold,
                    MasterXpThreshold
                };
            }
        }

        public static string AgentFromSkillType(SkillType type)
        {
            return type switch
            {
                SkillType.Woodcutting => "Woodcutter",
                SkillType.Hunting => "Hunter",
                _ => ""
            };
        }

        public int Xp { get; set; }

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
            var levelUp = false;
            foreach (var threshold in Thresholds)
            {
                if (Xp < threshold && Xp + xp >= threshold)
                {
                    levelUp = true;
                }
            }

            Xp += xp;
            if (levelUp) _listener.SkillIncreased(this);
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