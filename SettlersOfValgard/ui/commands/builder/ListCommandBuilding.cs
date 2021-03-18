using System;
using System.Collections.Generic;
using System.Linq;
using SettlersOfValgardGame.ui.commands.arguments;
using SettlersOfValgardGame.ui.console.text;
using SettlersOfValgardGame.ui.elements;
using SettlersOfValgardGame.ui.environment;
using SettlersOfValgardGame.ui.environment.settings;
using SettlersOfValgardGame.util;
using static SettlersOfValgardGame.ui.console.VConsole;

namespace SettlersOfValgardGame.ui.commands.builder
{
    public static class ListCommands
    {
        public static Action<List<TItem>, TGame, Command> CreateListOrDisplayAction<TGame, TItem>(string type, Action<TItem, TGame, Command> display, string typePlural = null, Action<TGame, Command> onEmptyList = null)
            where TGame : Game
            where TItem : VText
        {
            return (list, game, command) =>
            {
                if (list.Count == 0)
                {
                    WriteError("No " + type + " found!");
                    onEmptyList?.Invoke(game, command);
                }
                else if (list.Count == 1)
                {
                    display(list[0], game, command);
                }
                else
                {
                    var title = typePlural ?? type + "s";
                    game.AddElement(ListElement<TItem>.CreateListElement(list, Text(title)));
                }
            };
        }

        public static Action<List<TItem>, TGame, Command> CreateListAction<TGame, TItem>(string type, string typePlural = null, Action<TGame, Command> onEmptyList = null)
            where TGame : Game
            where TItem : VText
        {
            return CreateListOrDisplayAction<TGame, TItem>(type, (item, game, command) =>
            {
                var title = typePlural ?? type + "s";
                game.AddElement(ListElement<TItem>.CreateListElement(new List<TItem>{item}, Text(title)));
            }, typePlural, onEmptyList);
        }
        
        public static CommandBuilder WithStandardListAction<TGame, TItem>(this CommandBuilder commandBuilder,
            Func<TGame, Command, List<TItem>> source, Action<List<TItem>, TGame, Command> followup,
            params Func<TItem, bool>[] filters)
            where TGame : Game
            where TItem : VText
        {
            var prefixArgument = new StringArgument("Prefix", Text("the prefix of your search"));
            var suffixArgument = new StringArgument("suffix", Text("the suffix of your search"));
            var suffixTag = new Tag("-suffix", Text("Allows you to search with a suffix"), new List<Argument>{suffixArgument});
            var infixArgument = new StringArgument("infix", Text("the infix of your search"));
            var infixTag = new Tag("-infix", Text("Allows you to search with an infix"), new List<Argument>{infixArgument});
            var lengthArgument = new IntegerArgument("Length", Text("the length of your search"));
            var lengthTag = new Tag("-length", Text("Allows your to search with a set length"), new List<Argument>{lengthArgument});
            var minLengthArgument = new IntegerArgument("Minimum Length", Text("the minimum length of your search"));
            var minLengthTag = new Tag("-min", Text("Allows your to search with a minimum length"), new List<Argument>{minLengthArgument});
            var maxLengthArgument = new IntegerArgument("Maximum Length", Text("the maximum length of your search"));
            var maxLengthTag = new Tag("-max", Text("Allows your to search with a maximum length"), new List<Argument>{maxLengthArgument});

            commandBuilder.WithOptionalArguments(prefixArgument);
            commandBuilder.WithTags(suffixTag, infixTag, lengthTag, minLengthTag, maxLengthTag);
            
            bool Filter(TItem item)
            {
                var matchCriteria = new StringMatching.MatchCriteria(
                    prefixArgument.IsFilled() ? prefixArgument.Content : null, 
                    suffixArgument.IsFilled() ? suffixArgument.Content : null,
                    infixArgument.IsFilled() ? infixArgument.Content : null, 
                    lengthArgument.IsFilled() ? lengthArgument.Content : -1,
                    minLengthArgument.IsFilled() ? minLengthArgument.Content : -1,
                    maxLengthArgument.IsFilled() ? maxLengthArgument.Content : -1,
                    true);
                return matchCriteria.IsMatch(item.GetContentRaw());
            }

            var completeFilters = filters.ToList();
            completeFilters.Add(Filter);
            return WithListAction(commandBuilder, source, followup, completeFilters.ToArray());
        }

        public static CommandBuilder WithListAction<TGame, TItem>(this CommandBuilder commandBuilder,
            Func<TGame, Command, List<TItem>> source, Action<List<TItem>, TGame, Command> followup,
            params Func<TItem, bool>[] filters)
            where TGame : Game
            where TItem : VText
        {
            void Action(Game passedGame, Command command)
            {
                var game = passedGame as TGame;
                var list = source(game, command);
                foreach (var filter in filters)
                {
                    list = list.Where(filter).ToList();
                }

                followup(list, game, command);
            }

            commandBuilder.WithAction(Action);

            return commandBuilder;
        }
    }
}