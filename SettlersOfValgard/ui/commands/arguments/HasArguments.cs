using System.Collections.Generic;

namespace SettlersOfValgardGame.ui.commands.arguments
{
    public interface IHasArguments
    {
        List<Argument> Arguments { get; }
        List<Argument> OptionalArguments { get; }
    }
}