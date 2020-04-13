using System;

namespace SettlersOfValgard.Model.Event.Option
{
    public class RequirementEventOption : EventOption
    {
        private readonly Func<Settlement.Settlement, bool> _isAvailable;
        
        public override bool IsAvailable(Settlement.Settlement settlement)
        {
            return _isAvailable(settlement);
        }

        public RequirementEventOption(string description, Func<Settlement.Settlement, bool> isAvailable, Action<Settlement.Settlement> execute) : base(description, execute)
        {
            _isAvailable = isAvailable;
        }
    }
}