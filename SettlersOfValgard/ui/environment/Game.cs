using System;
using System.Collections.Generic;
using SettlersOfValgardGame.ui.commands;
using SettlersOfValgardGame.ui.commands.basic;
using SettlersOfValgardGame.ui.console.color;
using SettlersOfValgardGame.ui.elements;
using SettlersOfValgardGame.ui.environment.events;
using SettlersOfValgardGame.ui.environment.settings;
using SettlersOfValgardGame.ui.player;
using SettlersOfValgardGame.util.random;

namespace SettlersOfValgardGame.ui.environment
{
    public class Game : ISeeded 
    {
        public static Game Instance;
        public virtual List<Command> GlobalCommands { get; } = new List<Command>(BasicCommands.Commands);
        
        public Game(Profile profile, uint seed, List<Command> gameCommands = null, Action<Game> onStart = null, Action<Game> onClose = null)
        {
            Profile = profile;
            GameCommands = gameCommands ?? new List<Command>();
            OnStart = onStart ?? (game => {});
            OnClose = onClose ?? (game => {});
            Seed = seed;
        }

        public Profile Profile { get; }
        public List<InputLoop> InputLoops { get; } = new List<InputLoop>();
        public List<IUiElement> Elements { get; } = new List<IUiElement>();
        public List<Command> GameCommands { get; }
        public GameEventHandler GameEventHandler { get; } = new GameEventHandler();

        public void Run()
        {
            ColorLoader.Load();
            Settings.LoadSettings();
            Console.Clear();
            var baseLoop = new InputLoop(this, GameCommands);
            InputLoops.Add(baseLoop);
            OnStart(this);
            baseLoop.Start();
            OnClose(this);
        }

        public Action<Game> OnStart { get; }
        public Action<Game> OnClose { get; }
        public Settings Settings { get; } = new Settings();

        private uint _seed;
        public uint Seed
        {
            get => _seed;
            set
            {
                SeedIsSet = true;
                _seed = value;
            }
        }
        public bool SeedIsSet { get; set; }

        public void AddLoop(InputLoop loop)
        {
            InputLoops.Add(loop);
            loop.Start();
            InputLoops.Remove(loop);
        }

        public void AddElement(IUiElement element)
        {
            Elements.Add(element);
            element.Show(this);
            Elements.Remove(element);
        }
    }
}