namespace SettlersOfValgardGame.ui.console.color
{
    
    public class VColor
    {
        public int Value { get; }

        public VColor(int value)
        {
            Value = value;
        }

        public string GetForegroundAnsi()
        {
            return GetForegroundAnsi(Value);
        }

        public string GetBackgroundAnsi()
        {
            return GetBackgroundAnsi(Value);
        }
        
        public static string GetForegroundAnsi(int number)
        {
            return "\u001b[38;5;" + number + "m";
        }
        
        public static string GetBackgroundAnsi(int number)
        {
            return "\u001b[48;5;" + number + "m";
        }
    }
}