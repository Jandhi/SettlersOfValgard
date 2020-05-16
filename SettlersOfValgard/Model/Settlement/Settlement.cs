using System.Collections.Generic;
using System.Linq;
using SettlersOfValgard.Model.Building;
using SettlersOfValgard.Model.Event;
using SettlersOfValgard.Model.Location.Weather;
using SettlersOfValgard.Model.Message;
using SettlersOfValgard.Model.Name;
using SettlersOfValgard.Model.Rank;
using SettlersOfValgard.Model.Resource;
using SettlersOfValgard.Model.Settler;
using SettlersOfValgard.Model.Settler.Event;
using SettlersOfValgard.Model.Settler.Message;
using SettlersOfValgard.Model.Tech;
using SettlersOfValgard.Model.Time;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Settlement
{
    public class Settlement : INamed, IDated
    {
        public string Name { get; }

        public Date Birthday { get; } = new Date(0);
        public Location.Location Location { get; }

        public Date TodaysDate { get; set; } = new Date(0);
        public Weather TodaysWeather { get; set; }
        
        public Stockpile Stockpile { get; }

        public EventManager EventManager { get; } = new EventManager();
        public MessageManager MessageManager { get; } = new MessageManager();
        public bool StopDayPass { get; set; } = false;

        public SettlerManager SettlerManager = new SettlerManager();
        public List<Settler.Settler> Settlers => SettlerManager.Settlers;

        public List<Family> Families => SettlerManager.Families;
        public List<Building.Building> Buildings { get; } = new List<Building.Building>();
        
        public PlayerRank Rank => PlayerRank.GetRank(Settlers.Count);

        public TechManager TechManager { get; }
        public List<Blueprint> Blueprints { get; } = new List<Blueprint>();

        public Settlement(string name, Location.Location location, Culture.Culture culture)
        {
            Name = name;
            Location = location;
            TechManager = new TechManager(culture.TechTree);
            Stockpile = new Stockpile();
            TodaysWeather = Location.GenerateWeather();
        }

        public void PassDay()
        {
            StartDay();
            DoWork();
            FeedSettlers();
            
            Stockpile.AddTodaysTransactionsMessage(MessageManager);
            Stockpile.ArchiveTodaysTransactions();
            Stockpile.ClearTodaysTransactions();
            
            MessageManager.GoThroughMessages(this);
            MessageManager.ArchiveTodaysMessages();
            MessageManager.ClearTodaysMessages();

            EventManager.ExecuteTodaysEvents(this);
        }

        public void StartDay()
        {
            TodaysDate.Increment();
            TodaysWeather = Location.GenerateWeather();
        }

        public void DoWork()
        {
            foreach (var settler in Settlers)
            {
                var work = settler.Workplace;
                work?.HostWork(settler, this);
            }
        }

        public void FeedSettlers()
        {
            foreach (var settler in Settlers)
            {
                settler.GoEat(this);
            }
            
            AddCumulativeSettlerAteEvent();
            AddCumulativeSettlerStarvedEvent();
        }

        private void AddCumulativeSettlerAteEvent()
        {
            var eatCount = MessageManager.TodaysMessages.OfType<SettlerAteMessage>().Count();
            var meals = new Bundle();
            foreach (var settlerAte in MessageManager.TodaysMessages.OfType<SettlerAteMessage>())
            {
                meals += settlerAte.Meal;
            }
            if(eatCount > 0) MessageManager.TodaysMessages.Add(new CumulativeSettlerAteMessage(eatCount, meals));
        }
        
        private void AddCumulativeSettlerStarvedEvent()
        {
            var starveCount = MessageManager.TodaysMessages.OfType<SettlerStarvedMessage>().Count();
            MessageManager.TodaysMessages.Add(new CumulativeSettlerStarvedMessage(starveCount));
        }

        public override string ToString()
        {
            return $"{Rank.Color}{Name}{CustomConsole.White}";
        }

        public void AddMessage(Message.Message evn)
        {
            MessageManager.TodaysMessages.Add(evn);
        }
    }
}