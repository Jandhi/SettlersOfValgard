namespace SettlersOfValgard.Interface.Commands.Arguments
{
    public class NaturalNumberArgument : IntegerArgument
    {
        public override string Type => "Natural Number";
        public NaturalNumberArgument(string name, string description) : base(name, description)
        {
        }

        public override void ProcessArgs(string[] args)
        {
            base.ProcessArgs(args);
            if (Contents < 1)
            {
                IsValid = false;
                throw new InputArgumentException($"The Argument {Name} requires a natural number! (An integer x > 0)");
            }
        }
    }
}