using System;
using System.Collections.Generic;
using System.Linq;
using SettlersOfValgardGame.ui.commands.arguments;
using SettlersOfValgardGame.ui.commands.builder;
using SettlersOfValgardGame.ui.console.color;
using SettlersOfValgardGame.ui.console.text;
using SettlersOfValgardGame.ui.elements;
using SettlersOfValgardGame.ui.environment;
using SettlersOfValgardGame.util;
using static SettlersOfValgardGame.ui.console.VConsole;

namespace SettlersOfValgardGame.ui.commands.basic
{
    public class HelpCommand
    {
        private static void DisplayCommand(Game game, Command command)
        {
            game.AddElement(new TitleElement(command));
            WriteLine(command.Description.Apply(VTextTransform.Capitalize()));
            var usage = Text("Usage: ") + command;

            foreach (var argument in command.Arguments)
            {
                usage += Text(" ") + argument.Apply(VTextTransform.Quote("[", "]"))
                             .Apply(VTextTransform.SetForeground(ColorStandards.Argument));
            }

            foreach (var argument in command.OptionalArguments)
            {
                usage += Text(" ") + argument.Apply(VTextTransform.Quote("(", ")"))
                             .Apply(VTextTransform.SetForeground(ColorStandards.Optional));
            }
            
            WriteLine(usage);
            if(command.Arguments.Count > 0 || command.OptionalArguments.Count> 0)
            {
                WriteLine(Text("Arguments:", ColorStandards.Title));
            }

            foreach (var argument in command.Arguments)
            {
                WriteLine(Text(" ") + argument.Apply(VTextTransform.SetForeground(ColorStandards.Argument)) + Text(": ") + argument.Description);
            }
            foreach (var argument in command.OptionalArguments)
            {
                WriteLine(Text(" ") + argument.Apply(VTextTransform.SetForeground(ColorStandards.Optional)) + Text(": ") + argument.Description);
            }
            
            if(command.Tags.Count > 0)
            {
                WriteLine(Text("Tags:", ColorStandards.Title));
            }

            foreach (var tag in command.Tags)
            {
                VText tagUsage = Text(" ") + tag;
                foreach (var argument in tag.Arguments)
                {
                    tagUsage += Text(" ") + argument.Apply(VTextTransform.Quote("[", "]"))
                                 .Apply(VTextTransform.SetForeground(ColorStandards.Argument));
                }

                foreach (var argument in tag.OptionalArguments)
                {
                    tagUsage += Text(" ") + argument.Apply(VTextTransform.Quote("(", ")"))
                                    .Apply(VTextTransform.SetForeground(ColorStandards.Argument));
                }
                
                WriteLine(tagUsage);
                WriteLine(Text("  ") + tag.Description);
                
                foreach (var argument in tag.Arguments)
                {
                    WriteLine(Text("  ") + argument.Apply(VTextTransform.SetForeground(ColorStandards.Argument)) + Text(": ") + argument.Description);
                }
                foreach (var argument in tag.OptionalArguments)
                {
                    WriteLine(Text("  ") + argument.Apply(VTextTransform.SetForeground(ColorStandards.Optional)) + Text(": ") + argument.Description);
                }
            }
        }

        public static Command Help = new CommandBuilder()
            .WithName("Help")
            .WithDescription(Text("get help for available commands"))
            .WithStandardListAction(
                (game, command) => game.InputLoops[^1].Commands,
                ListCommands.CreateListOrDisplayAction<Game, Command>(
                    type: "command",
                    display: (command, game, command2) => DisplayCommand(game, command),
                    onEmptyList: (game, command) =>
                    {
                        WriteLine(Text("Use ") + Text("commands").Apply(VTextTransform.QuoteInput()) +
                                  Text(" to get a list of available commands"));
                        if (game.Elements.Count > 0 && game.Elements[^1] is MultiPageListElement<VText>)
                        {
                            WriteLine(Text("Use ")
                                      + Text("next").Apply(VTextTransform.QuoteInput())
                                      + Text(" and ")
                                      + Text("previous").Apply(VTextTransform.QuoteInput())
                                      + Text(" to navigate between pages"));
                        }
                    })
                )
            .Build();


    }
}