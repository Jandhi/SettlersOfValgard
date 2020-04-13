using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Settler.Gender
{
    public class BinaryGender : Gender
    {
        public static readonly BinaryGender Male = new BinaryGender("Male", "M", 'm', CustomConsole.Cyan);
        public static readonly BinaryGender Female = new BinaryGender("Female", "F", 'f', CustomConsole.Magenta);
        public static readonly BinaryGender Ambiguous = new BinaryGender("Ambiguous", "?", '?', CustomConsole.Gray);
        public static readonly BinaryGender Transgressing = new BinaryGender("Transgressing", "X", 'x', CustomConsole.Yellow);

        public BinaryGender(string name, string symbol, int value, string color) : base(name, symbol, value, color)
        {
        }

        public bool Is(Settler settler)
        {
            return settler is IGendered<BinaryGender> gendered && gendered.Gender == this;
        }
    }
}