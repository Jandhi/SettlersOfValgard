namespace SettlersOfValgard.View.Commands.Core.Arguments
{
    public abstract class StringArgument : Argument
    {
        public string Contents { get; set; }

        public override bool IsFilled => Contents != null;
        public override string ContentsAsString => Contents;

        public override void Clear()
        {
            Contents = null;
        }

        protected StringArgument(string name) : base(name)
        {
        }
    }
}