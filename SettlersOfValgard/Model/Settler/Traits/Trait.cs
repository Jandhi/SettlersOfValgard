using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Settler.Traits
{
    public class Trait : CustomEnum<Trait>
    {
        public string PositiveDescriptor { get; }
        public string NegativeDescriptor { get; }
        
        //Likelihood to do good things
        public static Trait Kindness = new Trait("Kindness", 1, CustomConsole.Green, CustomConsole.Green,"Kind", CustomConsole.Red, "Cruel");
        //Likelihood to win fights, work well with manual labour
        public static Trait Strength = new Trait("Strength", 2, CustomConsole.Yellow, CustomConsole.Yellow, "Strong", CustomConsole.DarkMagenta ,"Weak");
        //Work well with smart labour
        public static Trait Cleverness = new Trait("Cleverness", 3, CustomConsole.Cyan, CustomConsole.Cyan, "Clever", CustomConsole.Gray, "Dim");
        //Likelihood to commit crime or duplicitous acts
        public static Trait Honour = new Trait("Honour", 4, CustomConsole.Blue, CustomConsole.Blue, "Honourable", CustomConsole.Red, "Crooked");
        //Likelihood to flee from danger, be heroic
        public static Trait Bravery = new Trait("Bravery", 5, CustomConsole.Red, CustomConsole.Yellow, "Brave", CustomConsole.Blue, "Cowardly");
        //Likelihood to die form illness, wounds
        public static Trait Health = new Trait("Health", 6, CustomConsole.DarkRed, CustomConsole.Red, "Healthy", CustomConsole.DarkGreen, "Sickly");
        //Likelihood to have children
        public static Trait Fertility = new Trait("Fertility", 7, CustomConsole.Magenta, CustomConsole.Magenta, "Fertile", CustomConsole.Gray, "Barren");
        //Likelihood to attract mate
        public static Trait Beauty = new Trait("Beauty", 8, CustomConsole.Magenta, CustomConsole.Magenta, "Fair", CustomConsole.Gray, "Ugly");
        //Likelihood to make good relationships
        public static Trait Charm = new Trait("Charm", 9, CustomConsole.Green, CustomConsole.Magenta, "Charming", CustomConsole.Gray, "Boring");

        public static Trait[] Traits =
            {Kindness, Strength, Cleverness, Honour, Bravery, Health, Fertility, Beauty, Charm};
        
        protected Trait(string name, int value, string color, string positiveColor, string positiveDescriptor, string negativeColor, string negativeDescriptor) : base(name, value, color)
        {
            PositiveDescriptor = positiveColor + positiveDescriptor + CustomConsole.White;
            NegativeDescriptor = negativeColor + negativeDescriptor + CustomConsole.White;
        }

        public override Trait[] Values => Traits;
    }
}