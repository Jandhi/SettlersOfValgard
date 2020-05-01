using System;
using SettlersOfValgard.Model.Name;

namespace SettlersOfValgard.View.Command
{
    public abstract class Argument : INamed
    {

        public Argument(string name, ArgType type)
        {
            Name = name;
            Type = type;
        }

        public string Name { get; }
        public ArgType Type { get; }
        public string Contents { get; set; } = null;

        public void Clear()
        {
            Contents = null;
        }

        public abstract bool IsUsable();
    }
}