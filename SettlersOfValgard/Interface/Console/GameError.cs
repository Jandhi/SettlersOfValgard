namespace SettlersOfValgard.Interface.Console
{
    public class GameError
    {
        public GameError(string contents)
        {
            Contents = contents;
        }

        public string Contents { get; }
        
        public void Execute()
        {
            VConsole.WriteLine($"{VColor.Red}ERROR: {Contents}");
        }
    }
}