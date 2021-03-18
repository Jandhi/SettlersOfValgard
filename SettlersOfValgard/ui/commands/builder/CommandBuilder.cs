using System;
using System.Collections.Generic;
using System.Linq;
using SettlersOfValgardGame.ui.commands.arguments;
using SettlersOfValgardGame.ui.console.color;
using SettlersOfValgardGame.ui.console.text;
using SettlersOfValgardGame.ui.environment;
using static SettlersOfValgardGame.ui.console.VConsole;

namespace SettlersOfValgardGame.ui.commands.builder
{
    public class CommandBuilder
    {
        private string _name;
        private VText _description;
        private VColor _color;
        private List<Argument> _arguments = new List<Argument>();
        private List<Argument> _optionalArguments = new List<Argument>();
        private List<Tag> _tags = new List<Tag>();
        private List<Action<Game, Command>> _actions = new List<Action<Game, Command>>();
        private List<Permission> _requiredPermissions = new List<Permission>();

        public CommandBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public CommandBuilder WithDescription(VText description)
        {
            _description = description;
            return this;
        }

        public CommandBuilder WithColor(VColor color)
        {
            _color = color;
            return this;
        }

        public CommandBuilder WithArguments(params Argument[] arguments)
        {
            _arguments.AddRange(arguments);
            return this;
        }
        
        public CommandBuilder WithOptionalArguments(params Argument[] arguments)
        {
            _optionalArguments.AddRange(arguments);
            return this;
        }

        public CommandBuilder WithTags(params Tag[] tags)
        {
            _tags = new List<Tag>(tags);
            return this;
        }
        
        public CommandBuilder WithAction(Action<Game, Command> action)
        {
            return WithAction<Game>(action);
        }

        public CommandBuilder WithAction<TGame>(Action<TGame, Command> action) where TGame : Game
        {
            _actions.Add((passedGame, command) =>
            {
                var game = passedGame as TGame;
                action(game, command);
            });
            return this;
        }

        public CommandBuilder WithConditionalAction(Func<Game, Command, bool> condition,
            Action<Game, Command> action)
        {
            return WithConditionalAction<Game>(condition, action);
        }

        public CommandBuilder WithConditionalAction<TGame>(Func<TGame, Command, bool> condition, Action<TGame, Command> action) where TGame : Game
        {
            _actions.Add((passedGame, command) =>
            {
                var game = passedGame as TGame;
                if (condition(game, command))
                {
                    action(game, command);
                }
            });
            return this;
        }

        public CommandBuilder WithYesNoAction(Action<Game, Command> action)
        {
            var forceTag = new Tag("-f", Text("Forces command to go through"));
            if (_tags == null)
            {
                _tags = new List<Tag>();
            }
            _tags.Add(forceTag);
            _actions.Add((game, command) =>
            {
                if (command.UsedTags.Contains(forceTag))
                {
                    //Forced
                    action(game, command);
                }
                else
                {
                    var question = Text("Are you sure you want to ") + command.Description + Text("? (yes/no)");
                    if (YesNoLoop.Get(game, question.Apply(VTextTransform.SetForeground(VColor.Gold))))
                    {
                        action(game, command);
                    }
                }
            });
            return this;
        }

        public CommandBuilder WithRequiredPermissions(params Permission[] requiredPermissions)
        {
            _requiredPermissions = new List<Permission>(requiredPermissions);
            return this;
        }

        public Command Build()
        {
            Action<Game, Command> finalAction = (game, command) =>
            {
                foreach (var action in _actions)
                {
                    action(game, command);
                }
            };

            if (_name == null)
            {
                throw new FormatException("Command created with blank name!");
            }
            
            if (_actions.Count == 0)
            {
                throw new FormatException("Command " + _name + " created with 0 actions!");
            } 
            
            return new Command(_name, _description, finalAction, _color, _arguments, _optionalArguments, _tags, _requiredPermissions);
        }
    }
}