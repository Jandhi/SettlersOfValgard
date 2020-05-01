using System;
using System.Collections.Generic;
using System.Linq;
using SettlersOfValgard.Model.Time;

namespace SettlersOfValgard.View.Command
{
    public class SettlerCommand : Command
    {
        public override string Name => "Settler";

        public override string[] Aliases => new [] {"s", "settler", "settlers", "Settler", "Settlers"};

        public StringArgument SettlerName = new StringArgument("SettlerName");
        public StringArgument SettlerLastName = new StringArgument("SettlerLastName");
        public Tag Numbered = new Tag("-n", "Produces a numbered list");
        public Tag Separated = new Tag("-s", "Separates identical entries in list");
        public Tag Age = new Tag("-age", "Displays age of settlers");

        private Func<Model.Settler.Settler, string> DisplayAge(Game game)
        {
            return settler => $"(Age: {settler.AgeInDays(game.Settlement) / Date.DaysInYear})";
        }

        public override List<Argument> Arguments { get; } = new List<Argument>();
        public override List<Argument> OptionalArguments => new List<Argument>{SettlerName, SettlerLastName};
        public override List<Tag> Tags { get; } = new List<Tag>();
        public override string UseCommandTo => "get information on the settlers";
        
        public override void Execute(Game game)
        {
            if (SettlerName.Contents == null)
            {
                IOManager.ListInConsole(game.Settlement.Settlers, Numbered.Used, Separated.Used, Age.Used ? DisplayAge(game) : null);
            }
            else
            {
                var name = SettlerName.Contents;
                if (SettlerLastName.IsUsable()) name += " " + SettlerLastName.Contents;
                var settler = game.Settlement.Settlers.FirstOrDefault(settler => settler.Name == name);
                
            }
        }
    }
}