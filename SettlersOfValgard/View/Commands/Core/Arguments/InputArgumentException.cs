using System;

namespace SettlersOfValgard.View.Commands.Core.Arguments
{
    public class InputArgumentException : FormatException
    {
        public InputArgumentException(string message) : base(message) {}
    }
}