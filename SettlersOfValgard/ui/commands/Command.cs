using System;
using System.Collections.Generic;
using System.Linq;
using SettlersOfValgardGame.ui.commands.arguments;
using SettlersOfValgardGame.ui.console.color;
using SettlersOfValgardGame.ui.console.text;
using SettlersOfValgardGame.ui.environment;
using SettlersOfValgardGame.ui.models;

namespace SettlersOfValgardGame.ui.commands
{
    public class Command : NamedObject, IDescribed, IHasArguments
    {
        protected Command(string name, 
            VText useThisCommandTo, VColor nameForeground = null, List<Argument> arguments = null, List<Argument> optionalArguments = null, List<Tag> tags = null,
            List<Permission> requiredPermissions = null, VColor color = null)
        {
            Description = useThisCommandTo;
            NameText = name;
            NameForeground = nameForeground ?? ColorStandards.Command;
            Arguments = arguments ?? new List<Argument>();
            OptionalArguments = optionalArguments ?? new List<Argument>();
            Tags = tags ?? new List<Tag>();
            RequiredPermissions = requiredPermissions ?? new List<Permission>();
        }
        
        public Command(string name, 
            VText useThisCommandTo, 
            Action<Game, Command> action, VColor nameForeground = null, List<Argument> arguments = null, List<Argument> optionalArguments = null, List<Tag> tags = null,
            List<Permission> requiredPermissions = null, VColor color = null)
        {
            Description = useThisCommandTo;
            Action = action;
            NameText = name;
            NameForeground = nameForeground ?? ColorStandards.Command;
            Arguments = arguments ?? new List<Argument>();
            OptionalArguments = optionalArguments ?? new List<Argument>();
            Tags = tags ?? new List<Tag>();
            RequiredPermissions = requiredPermissions ?? new List<Permission>();
        }
        
        public Action<Game, Command> Action { get; }
        public VText Description { get; }
        public List<Permission> RequiredPermissions { get; }
        public string CallName { get; set; } // Name under which command is called
        public List<Tag> Tags { get; }
        public List<Tag> UsedTags { get; set; } = new List<Tag>();
        public List<Argument> Arguments { get; }
        public List<Argument> OptionalArguments { get; }

        public virtual bool IsMatch(string input)
        {
            return NameText.ToLower().StartsWith(input.ToLower());
        }

        public virtual bool IsExactMatch(string input)
        {
            return NameText.ToLower() == input.ToLower();
        }

        public void Clear()
        {
            CallName = null;
            UsedTags = new List<Tag>();
            Arguments.ForEach(arg => arg.Clear());
            OptionalArguments.ForEach(arg => arg.Clear());
            Tags.ForEach(tag => tag.Clear());
        }

        public override string NameText { get; }
        public override VColor NameForeground { get; }
    }
}