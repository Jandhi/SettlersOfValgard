using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Settler.Gender
{
    public abstract class Gender : CustomEnum
    {
        public string Symbol { get; }

        protected Gender(string name, string symbol, int value, string color) : base(name, value, color)
        {
            Symbol = symbol;
        }
    }
}