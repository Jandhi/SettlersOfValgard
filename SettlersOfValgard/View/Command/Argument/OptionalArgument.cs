using System.Runtime.InteropServices;

namespace SettlersOfValgard.View.Command
{
    public class OptionalArgument : Argument
    {
        public override bool IsOptional => true;

        public OptionalArgument(string name, ArgType type) : base(name, type)
        {
        }
    }
}