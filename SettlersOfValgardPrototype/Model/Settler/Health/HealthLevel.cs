using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Settler.Health
{
    public class HealthLevel : CustomEnum<HealthLevel>
    {
        public static readonly HealthLevel Healthy = new HealthLevel("Healthy", 5, CustomConsole.Green);
        public static readonly HealthLevel LightlyWounded = new HealthLevel("Lightly Wounded", 4, CustomConsole.Yellow);
        public static readonly HealthLevel Unwell = new HealthLevel("Suffer", 4, CustomConsole.Yellow);
        public static readonly HealthLevel Wounded = new HealthLevel("Wounded", 3, CustomConsole.DarkYellow);
        public static readonly HealthLevel Sick = new HealthLevel("Sick", 3, CustomConsole.DarkYellow);
        public static readonly HealthLevel BadlyWounded = new HealthLevel("Badly Wounded", 2, CustomConsole.Red);
        public static readonly HealthLevel VerySick = new HealthLevel("Very Sick", 2, CustomConsole.Red);
        public static readonly HealthLevel Dying = new HealthLevel("Dying", 1, CustomConsole.DarkRed);
        public static readonly HealthLevel Dead = new HealthLevel("Dead", 0, CustomConsole.Gray);
        public static HealthLevel[] HealthLevels = {Healthy, LightlyWounded, Wounded, Sick, BadlyWounded, Dying};

        public static HealthLevel Get(double percent, bool disease)
        {
            if (percent > 0.8)
            {
                return Healthy;
            }

            if (percent > 0.6)
            {
                return disease ? Unwell : LightlyWounded;
            }

            if (percent > 0.4)
            {
                return disease ? Sick : Wounded;
            }

            if (percent > 0.2)
            {
                return disease ? VerySick : BadlyWounded;
            }

            return percent > 0 ? Dying : Dead;
        }
        
        public HealthLevel(string name, int value, string color) : base(name, value, color) {}

        public override HealthLevel[] Values => HealthLevels;
    }
}