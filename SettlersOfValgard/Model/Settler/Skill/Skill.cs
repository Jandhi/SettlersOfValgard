using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Settler.Skill
{
    public class Skill : CustomEnum
    {
        public static readonly Skill Hunter = new Skill("Hunter", 0, CustomConsole.Red);
        public static readonly Skill Woodcutter = new Skill("Woodcutter", 1, CustomConsole.Green);
        public static readonly Skill Mason = new Skill("Mason", 2, CustomConsole.Gray);

        private Skill(string name, int value, string color) : base(name, value, color)
        {
        }
    }
}