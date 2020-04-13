using System.Collections.Generic;
using SettlersOfValgard.Model.Name;

namespace SettlersOfValgard.View.Command
{
    public class Tag : INamed
    {
        public string Name { get; }
        
        public List<Argument> Arguments;

        public Tag(List<Argument> arguments, string name)
        {
            Arguments = arguments;
            Name = name;
        }
    }
}