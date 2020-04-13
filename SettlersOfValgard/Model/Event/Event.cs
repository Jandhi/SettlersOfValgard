using System;
using System.Collections.Generic;
using System.Linq;
using SettlersOfValgard.Model.Event.Option;
using SettlersOfValgard.Model.Name;
using SettlersOfValgard.UtilLibrary;
using SettlersOfValgard.View;

namespace SettlersOfValgard.Model.Event
{
    public abstract class Event : INamed, IDescribed
    {
        public abstract string Name { get; }
        public abstract string Description { get; }

        public abstract List<EventOption> Options { get; }

        public const string ListOptions = "list";

        public virtual void PreExecute(Settlement.Settlement settlement) {}
        public virtual void PostExecute(Settlement.Settlement settlement) {}

        public void Execute(Settlement.Settlement settlement)
        {
            PreExecute(settlement);
            CustomConsole.TitleLine();
            CustomConsole.WriteLine($"{Name.ToUpper()}:");
            CustomConsole.WriteLine($"{Description}");
            IOManager.ChooseItemFromList(Options.Where(op => op.IsAvailable(settlement)), op => op.Description).Execute(settlement);
            PostExecute(settlement);
        }
    }
}