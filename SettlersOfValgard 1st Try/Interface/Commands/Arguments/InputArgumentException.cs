using System;

namespace SettlersOfValgard.Interface.Commands.Arguments
{
    public class InputArgumentException : FormatException
    {
        public InputArgumentException(string message) : base(message) {}
    }
}