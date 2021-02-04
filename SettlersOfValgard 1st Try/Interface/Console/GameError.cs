namespace SettlersOfValgard.Interface.Console
{
    public class GameError : TextEffect
    {
        public GameError(string contents)
        {
            Contents = contents;
        }

        public string Contents { get; }

        public override void Write()
        {
            VConsole.WriteLine($"{VColor.Red}ERROR: {Contents}");
        }
    }
}