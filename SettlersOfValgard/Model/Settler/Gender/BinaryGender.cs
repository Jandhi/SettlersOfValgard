using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Settler.Gender
{
    public class BinaryGender : Gender
    {
        public static readonly BinaryGender Male = new BinaryGender("Male", "M", 'm', CustomConsole.Cyan, "he", "him", "his");
        public static readonly BinaryGender Female = new BinaryGender("Female", "F", 'f', CustomConsole.Magenta, "she", "her", "her");
        public static readonly BinaryGender Ambiguous = new BinaryGender("Ambiguous", "?", '?', CustomConsole.Gray);
        public static readonly BinaryGender Transgressing = new BinaryGender("Transgressing", "X", 'x', CustomConsole.Yellow);
        public static readonly BinaryGender[] Genders = {Male, Female, Ambiguous, Transgressing};

        public bool Is(Settler settler)
        {
            return settler is IGendered<BinaryGender> gendered && gendered.Gender == this;
        }

        public BinaryGender(string name, string symbol, int value, string color, string subjective = "they", string objective = "them", string possessive = "their") : base(name, symbol, value, color, subjective, objective, possessive)
        {
        }

        public override Gender[] Values => Genders;
    }
}