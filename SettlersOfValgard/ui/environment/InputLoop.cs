using System;
using System.Collections.Generic;
using System.Linq;
using SettlersOfValgardGame.ui.environment;
using static SettlersOfValgardGame.ui.console.VConsole;

namespace SettlersOfValgardGame.ui.commands
{
    public class InputLoop
    {
        private const int TooManyNullLoops = 100;
        
        public bool IsLooping = true;
        public List<Command> Commands;
        public Game Game;
        public Action<Game> OnStart { get; }
        public Action<Game> OnClose { get; }
        public Action<Game> OnLoop { get; }

        public InputLoop(Game game, List<Command> commands, Action<Game> onStart = null, Action<Game> onClose = null, Action<Game> onLoop = null)
        {
            Game = game;
            Commands = commands;
            Commands.AddRange(game.GlobalCommands);
            OnStart = onStart ?? (game => {});
            OnLoop = onLoop ?? (game => {});
            OnClose = onClose ?? (game => {});
        }

        public void Start()
        {
            OnStart(Game);
            
            while (IsLooping)
            {
                OnLoop(Game);
                PromptInput();
            }
            
            OnClose(Game);
        }

        public void PromptInput()
        {
            var input = Console.ReadLine();
            var nullLoops = 0;
            
            while (input == null && nullLoops < TooManyNullLoops)
            {
                nullLoops++;
                input = Console.ReadLine();
            }

            if (input != null)
            {
                ProcessInput(input);
            }
            else
            {
                WriteError("Something went terribly wrong!", true);
            }
        }

        public void ProcessInput(string input)
        {
            //Split by quotes and spaces
            var split = input.Split('\"').ToList();
            var parts = new List<string>();
            for (var index = 0; index < split.Count; index++)
            {
                if (index % 2 == 0) // Not in quotes
                {
                    parts.AddRange(split[index].Split(' '));
                }
                else // In quotes
                {
                    parts.Add(split[index]);
                }
            }

            //Filter empties
            parts = parts.Where(part => part != "").ToList();
            
            //Empty line
            if (parts.Count == 0)
            {
                return;
            }

            var arguments = ReplaceSigns(parts);
            
            CommandManager.ProcessArguments(Game, arguments, Commands);   
        }

        public string[] ReplaceSigns(List<string> input)
        {
            //TODO
            return input.ToArray();
        }
    }
}