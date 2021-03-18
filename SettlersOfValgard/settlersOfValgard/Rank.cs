using SettlersOfValgardGame.ui.console.color;
using SettlersOfValgardGame.ui.console.text;
using SettlersOfValgardGame.ui.models;

namespace SettlersOfValgardGame.settlersOfValgard
{
    public class Rank : NamedObject
    {
        
        public static readonly Rank Freeman = new Rank("Freeman", VColor.Green);
        public static readonly Rank Chieftain = new Rank("Chieftain", VColor.Sky);
        public static readonly Rank Gothi = new Rank("Gothi", VColor.Lavender);
        public static readonly Rank Thane = new Rank("Thane", VColor.Orange);
        public static readonly Rank Jarl = new Rank("Jarl", VColor.Red);
        public static readonly Rank Konungr = new Rank("Konungr", VColor.Gold);

        public Rank(string nameText, VColor nameForeground = null) : base()
        {
            NameText = nameText;
            NameForeground = nameForeground;
        }

        public override string NameText { get; }
        public override VColor NameForeground { get; }
    }
}