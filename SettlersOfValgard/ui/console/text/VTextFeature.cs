namespace SettlersOfValgardGame.ui.console.text
{
    public class VTextFeature
    {
        public static readonly VTextFeature Bold = new VTextFeature("\u001b[1m");
        public static readonly VTextFeature Underline = new VTextFeature("\u001b[4m");
        public static readonly VTextFeature ReversedColors = new VTextFeature("\u001b[7m");
        
        public string Ansi { get; }

        private VTextFeature(string ansi)
        {
            Ansi = ansi;
        }
    }
}