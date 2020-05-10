using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Settler.Skill
{
    public class Skill : CustomEnum<Skill>
    {
        public static readonly Skill Hunter = new Skill("Hunter", 0, CustomConsole.Red);
        public static readonly Skill Woodcutter = new Skill("Woodcutter", 1, CustomConsole.Green);
        public static readonly Skill Mason = new Skill("Mason", 2, CustomConsole.Gray);
        public static readonly Skill Gatherer = new Skill("Gatherer", 3, CustomConsole.Green);
        public static readonly Skill[] Skills = {Hunter, Woodcutter, Mason, Gatherer};

        private Skill(string name, int value, string color) : base(name, value, color)
        {
        }

        public override Skill[] Values => Skills;
    }
}