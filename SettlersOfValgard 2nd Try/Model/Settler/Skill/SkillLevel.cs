using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Settler.Skill
{
    public class SkillLevel : CustomEnum<SkillLevel>
    {
        public static readonly SkillLevel Unskilled = new SkillLevel("Unskilled", 0, CustomConsole.Gray);
        public static readonly SkillLevel Novice = new SkillLevel("Novice", 1, CustomConsole.Green);
        public static readonly SkillLevel Apprentice = new SkillLevel("Apprentice", 2, CustomConsole.Cyan);
        public static readonly SkillLevel Journeyman = new SkillLevel("Journeyman", 3, CustomConsole.Red);
        public static readonly SkillLevel Expert = new SkillLevel("Expert", 4, CustomConsole.Magenta);
        public static readonly SkillLevel Master = new SkillLevel("Master", 5, CustomConsole.Yellow);
        public static readonly SkillLevel[] Levels = {Unskilled, Novice, Apprentice, Journeyman, Expert, Master};

        public static SkillLevel XPtoLevel(int xp)
        {
            if (xp < 5)
            {
                return Unskilled;
            }

            if (xp < 15)
            {
                return Novice;
            }

            if (xp < 30)
            {
                return Apprentice;
            }

            if (xp < 80)
            {
                return Journeyman;
            }

            if (xp < 180)
            {
                return Expert;
            }

            return Master;
        }
        
        private SkillLevel(string name, int value, string color) : base(name, value, color)
        {
        }

        public override SkillLevel[] Values => Levels;
    }
}