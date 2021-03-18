using System.Collections.Generic;
using SettlersOfValgardGame.ui.commands.arguments;
using SettlersOfValgardGame.ui.console.color;
using SettlersOfValgardGame.ui.console.text;
using SettlersOfValgardGame.ui.models;

namespace SettlersOfValgardGame.ui.commands
{
    public class Tag : NamedObject, IDescribed, IHasArguments
    {
        
        public Tag(string nameText, VText description, List<Argument> arguments = null, List<Argument> optionalArguments = null, VColor nameForeground = null)
        {
            NameText = nameText;
            Description = description;
            NameForeground = nameForeground ?? ColorStandards.Tag;
            Arguments = arguments ?? new List<Argument>();
            OptionalArguments = optionalArguments ?? new List<Argument>();
        }

        public VText Description { get; }
        public List<Argument> Arguments { get; }
        public List<Argument> OptionalArguments { get; }

        public void Clear()
        {
            Arguments.ForEach(arg => arg.Clear());
            OptionalArguments.ForEach(arg => arg.Clear());
        }

        public override string NameText { get; }
        public override VColor NameForeground { get; }
    }
}