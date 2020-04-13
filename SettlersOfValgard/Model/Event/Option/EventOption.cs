using System;
using SettlersOfValgard.Model.Name;

namespace SettlersOfValgard.Model.Event.Option
{
    public class EventOption : IDescribed
    {
        public Action<Settlement.Settlement> Execute { get; }
        public EventOption(string description, Action<Settlement.Settlement> execute)
        {
            Description = description;
            Execute = execute;
        }

        public string Description { get; }
        public virtual bool IsAvailable(Settlement.Settlement settlement) => true;
    }
}