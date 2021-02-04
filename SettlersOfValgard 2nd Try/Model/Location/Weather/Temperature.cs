using System.Transactions;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Location.Weather
{
    public class Temperature : CustomEnum<Temperature>
    {
        public static readonly Temperature Freezing = new Temperature("Freezing", 0, CustomConsole.Blue);
        public static readonly Temperature Cold = new Temperature("Cold", 1, CustomConsole.Cyan);
        public static readonly Temperature Cool = new Temperature("Cool", 2, CustomConsole.DarkGreen);
        public static readonly Temperature Mild = new Temperature("Mild", 3, CustomConsole.Green); 
        public static readonly Temperature Warm = new Temperature("Warm", 4,CustomConsole.Yellow); 
        public static readonly Temperature Hot = new Temperature("Hot", 5, CustomConsole.Red);
        public static readonly Temperature[] Temperatures = {Freezing, Cold, Cool, Mild, Warm, Hot};
        public override Temperature[] Values => Temperatures;

        private Temperature(string name, int value, string color) : base(name, value, color) {}
    }
}