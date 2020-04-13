using System.Collections.Generic;
using SettlersOfValgard.Model.Name;

namespace SettlersOfValgard.View.Command
{
    public abstract class Command : INamed
    {
        public abstract string Name { get; }
        public abstract string [] Aliases { get; }
        public abstract List<Argument> Arguments { get; }
        public abstract List<Tag> Tags { get; }
        public abstract string UseCommandTo { get; }
        public virtual bool NeedsValidation => false;
        public virtual bool NeedsGodMode => false;
        
        
    }
}