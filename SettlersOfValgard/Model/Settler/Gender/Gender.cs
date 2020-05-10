using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Settler.Gender
{
    public abstract class Gender : CustomEnum<Gender>
    {
        public string Symbol { get; }

        protected Gender(string name, string symbol, int value, string color, string subjective = "they", string objective = "them", string possessive = "their") : base(name, value, color)
        {
            Symbol = symbol;
            Subjective = subjective;
            Objective = objective;
            Possessive = possessive;
        }
        
        public string Subjective { get; }
        public string Objective { get; }
        public string Possessive { get; }
    }
}