namespace SettlersOfValgard.Interface.Commands.Arguments
{
    public abstract class BaseStringArgument : Argument
    {
        public string Contents { get; set; }
        public override string Type => "String";
        public override bool IsFilled => Contents != null;
        public override string ContentsAsString => Contents;

        public override void Clear()
        {
            Contents = null;
        }

        protected BaseStringArgument(string name, string description) : base(name, description)
        {
        }
    }
}