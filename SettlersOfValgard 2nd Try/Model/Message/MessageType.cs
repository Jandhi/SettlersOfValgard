using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Message
{
    public class MessageType : CustomEnum<MessageType>
    {
        public static readonly MessageType Settler = new MessageType("Settler", 0, CustomConsole.Cyan);
        public static readonly MessageType Building = new MessageType("Building", 1, CustomConsole.DarkYellow);
        public static readonly MessageType Settlement = new MessageType("Settlement", 2, CustomConsole.Red);
        public static readonly MessageType Stockpile = new MessageType("Stockpile", 3, CustomConsole.Yellow);
        public static readonly MessageType[] Types = {Settler, Settlement, Building, Stockpile};
        public override MessageType[] Values => Types;


        private MessageType(string name, int value, string color) : base(name, value, color)
        {
            
        }
    }
}