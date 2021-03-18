using System;
using System.Collections.Generic;
using System.Linq;
using SettlersOfValgardGame.ui.commands.arguments;
using SettlersOfValgardGame.ui.console.text;
using SettlersOfValgardGame.ui.environment;
using SettlersOfValgardGame.util;
using static SettlersOfValgardGame.ui.console.VConsole;

namespace SettlersOfValgardGame.ui.commands.builder
{
    public static class SelectionCommandBuilding
    {
        public class Selection<T>
        {
            public T Content { get; set; }
        }

        public static CommandBuilder WithDefaultSelectionAction<TGame, TItem>(this CommandBuilder commandBuilder, 
            Func<TGame, Command, List<TItem>> source, Selection<TItem> selection,  string type, string typePlural = null, 
            params Func<TItem, bool>[] filters)
            where TGame : Game
            where TItem : VText
        {
            var argument = new StringArgument(type + " name", Text("The name of the " + type));
            commandBuilder = commandBuilder.WithArguments(argument);

            var totalFilters = filters.ToList();
            totalFilters.Add(item =>
            {
                var criteria = new StringMatching.MatchCriteria(argument.Content.ToLower());
                return criteria.IsMatch(item.GetContentRaw().ToLower());
            });
            
            return commandBuilder.WithAction(CreateSelectionAction(source, selection, type, typePlural, filters));
        }

        public static Action<TGame, Command> CreateSelectionAction<TGame, TItem>(Func<TGame, Command, List<TItem>> source, 
            Selection<TItem> selection, string type, string typePlural = null, params Func<TItem, bool>[] filters)
            where TGame : Game
            where TItem : VText
        {
            void Action(TGame game, Command command)
            {
                var list = source(game, command).Where(item => filters.All(filter => filter(item))).ToList();
                
                if (list.Count == 0)
                {
                    throw new GameException("No " + type + " found!");
                } 
                else if (list.Count == 1)
                {
                    selection.Content = list[0];
                }
                else
                {
                    //do Selection
                }
            }

            return Action;
        }
    }
}