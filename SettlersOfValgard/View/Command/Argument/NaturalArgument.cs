using System;

namespace SettlersOfValgard.View.Command
{
    public class NaturalArgument : Argument
    {
        public NaturalArgument(string name) : base(name, ArgType.Nat)
        {
        }
        
        public int Value { get; set; }

        public override bool IsUsable()
        {
            if (Contents == null) return false;
            
            try
            {
                var num = int.Parse(Contents.Trim());
                if (num < 0) throw new FormatException();
                Value = num;
                return true;
            }
            catch (FormatException e)
            {
                return false;
            }
        }
    }
}