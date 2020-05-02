namespace SettlersOfValgard.View.Commands.Core.Arguments
{
    public class NaturalNumberArgument : IntegerArgument
    {
        public NaturalNumberArgument(string name) : base(name)
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