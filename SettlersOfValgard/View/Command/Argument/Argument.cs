using System;
using SettlersOfValgard.Model.Name;

namespace SettlersOfValgard.View.Command
{
    public class Argument : INamed
    {

        public Argument(string name, ArgType type)
        {
            Name = name;
            Type = type;
        }

        public string Name { get; }
        public ArgType Type { get; }
        public virtual bool IsOptional { get; } = false;
        public string Contents { get; set; } = null;

        public bool IsUsable()
        {
            if (Contents == null && !IsOptional)
            {
                throw new FormatException($"The Required Argument [{Name}] has not been provided!");
            }
            
            if (Contents == null && IsOptional)
            {
                return false;
            }

            switch (Type)
            {
                case ArgType.Nat:
                    try
                    {
                        var num = int.Parse(Contents.Trim());
                        if (num < 0) throw new FormatException();
                        return true;
                    }
                    catch (FormatException e)
                    {
                        throw new FormatException($"The Argument [{Name}] requires a positive numerical value!");
                    }
                
                case ArgType.String:
                    return true;
            }

            return false;
        }
    }
}