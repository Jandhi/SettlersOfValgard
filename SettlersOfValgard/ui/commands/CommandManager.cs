using System;
using System.Collections.Generic;
using System.Linq;
using SettlersOfValgardGame.ui.commands.arguments;
using SettlersOfValgardGame.ui.console.color;
using SettlersOfValgardGame.ui.console.text;
using SettlersOfValgardGame.ui.elements;
using SettlersOfValgardGame.ui.environment;
using static SettlersOfValgardGame.ui.console.text.VTextTransform;
using static SettlersOfValgardGame.ui.console.VConsole;
using Game = SettlersOfValgardGame.ui.environment.Game;

namespace SettlersOfValgardGame.ui.commands
{
    public static class CommandManager
    {
        public static void ProcessArguments(Game game, string[] input, List<Command> commands)
        {
            var commandName = input[0];
            var matches = new List<Command>();

            foreach (var command in commands)
            {
                if (command.IsExactMatch(commandName))
                {
                    AttemptCommandExecution(game, input, command);
                    return;
                }

                if (command.IsMatch(commandName))
                {
                    matches.Add(command);
                }
            }

            if (matches.Count == 1)
            {
                // ONE MATCH
                AttemptCommandExecution(game, input, matches[0]);
            }
            else if (matches.Count == 0)
            {
                // NO MATCHES
                WriteError(Text("No commands starting with ") +
                           Text(commandName).Apply(Quote(), SetForeground(ColorStandards.Input)) + Text(" found."));
                var similarCommands = GetSimilarCommands(commandName);
                if (similarCommands.Count > 0)
                {
                    WriteLine("Did you mean:");
                    game.AddElement(ListElement<Command>.CreateListElement(similarCommands));
                }
            }
            else
            {
                WriteLine(Text("Commands starting with ") +
                          Text(commandName).Apply(Quote(), SetForeground(ColorStandards.Input)) + Text(":"));
                game.AddElement(ListElement<Command>.CreateListElement(matches));
            }
        }

        public static List<Command> GetSimilarCommands(string commandName)
        {
            //TODO
            return new List<Command>();
        }
        
        public static void AttemptCommandExecution(Game game, string[] input, Command command)
        {
            if(AttemptFillCommand(game, input, command))
            {
                try
                {
                    command.Action(game, command);
                }
                catch (GameException g)
                {
                    WriteError(g.Explanation);
                    g.Callback?.Invoke(game);
                }
                catch (Exception e)
                {
                    WriteError(Text(e.Message));
                    WriteError(Text(e.StackTrace));
                }
            }
            
            CleanUp(command);
        }
        
        public static bool AttemptFillCommand(Game game, string[] input, Command command)
        {
            command.CallName = input[0];

            var commandInput = new List<string>();

            for (var i = 1; i < input.Length; i++)
            {
                var part = input[i];

                if (command.Tags.Any(tag => tag.NameText == part))
                {
                    var tag = command.Tags.FirstOrDefault(tag => tag.NameText == part);
                    if (command.UsedTags.Contains(tag))
                    {
                        WriteError(Text("Tag ") + tag + Text(" cannot be used more than once!"));
                        return false;
                    }
                    
                    command.UsedTags.Add(tag);
                    var tagInput = new List<string>();
                    
                    i++;
                    while (i < input.Length)
                    {
                        part = input[i];

                        if (command.Tags.Any(tag => tag.NameText == part))
                        {
                            i--;
                            break;
                        }
                        
                        tagInput.Add(part);
                        i++;
                    }

                    var success = AttemptFill(tagInput.ToArray(), tag, tag);
                    if (!success)
                    {
                        return false;
                    }
                    
                }
                else
                {
                    commandInput.Add(part);
                }
            }
            
            return AttemptFill(commandInput.ToArray(), command, command);
        }

        public static bool AttemptFill(string[] input, IHasArguments item, VText textItem)
        {
            if (input.Length < item.Arguments.Count)
            {
                WriteError(textItem + Text(" needs at least " + item.Arguments.Count + " arguments! (received " + input.Length + ")"));
                return false;
            }
            
            if(input.Length > item.Arguments.Count + item.OptionalArguments.Count)
            {
                WriteError(textItem + Text(" receives at most " + item.Arguments.Count + " arguments! (received " + input.Length + ")"));
                return false;
            }
            
            var count = 0;
            foreach (var part in input)
            {
                bool success;
                
                if (count < item.Arguments.Count)
                {
                    success = item.Arguments[count].Fill(part);
                }
                else
                {
                    success = item.OptionalArguments[count - item.Arguments.Count].Fill(part);
                }

                count++;
                if (!success)
                {
                    return false;
                }
            }

            return true;
        }

        public static void CleanUp(Command command)
        {
            command.Clear();
        }
    }
}