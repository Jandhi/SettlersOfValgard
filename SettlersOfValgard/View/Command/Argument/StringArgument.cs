namespace SettlersOfValgard.View.Command
{
    public class StringArgument : Argument
    {
        public StringArgument(string name) : base(name, ArgType.String)
        {
        }

        public string Value => Contents;

        public override bool IsUsable()
        {
            return Contents != null;
        }
    }
}