using System.Text;

namespace SettlersOfValgard.View.Commands.Core.Arguments
{
    public class UnlimitedStringArgument : StringArgument
    {
        public UnlimitedStringArgument(string name) : base(name)
        {
        }

        public override void ProcessArgs(string[] args)
        {
            if (args.Length < 1)
            {
                throw new InputArgumentException($"The Argument {Name} requires a string!");
            }
            
            StringBuilder sb = new StringBuilder(args[0]);
            for (var i = 1; i < args.Length; i++)
            {
                sb.Append($" {args[i]}");
            }

            Contents = sb.ToString();
        }
    }
}