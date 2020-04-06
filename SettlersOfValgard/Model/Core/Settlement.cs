using System.Collections.Generic;
using System.Linq;
using SettlersOfValgard.Model.Building;
using SettlersOfValgard.Model.Event;
using SettlersOfValgard.Model.Location.Weather;
using SettlersOfValgard.Model.Name;
using SettlersOfValgard.Model.Rank;
using SettlersOfValgard.Model.Resource;
using SettlersOfValgard.Model.Settler;
using SettlersOfValgard.Model.Settler.Event;
using SettlersOfValgard.Model.Time;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Core
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
        public bool StopDayPass { get; set; } = false;

        public List<Settler.Settler> Settlers
        {
            get
            {
                List<Settler.Settler> settlers = new List<Settler.Settler>();
                foreach (var family in Families)
                {
                    settlers.AddRange(family.Members);
                }

                return settlers;
            }
        }

        public List<Family> Families { get; } = new List<Family>();
        public List<Building.Building> Buildings { get; } = new List<Building.Building>();
        
        public PlayerRank Rank => PlayerRank.GetRank(Settlers.Count);

        public List<Tech.Tech> UnlockedTech { get; } = new List<Tech.Tech>();
        public List<Blueprint> Blueprints { get; } = new List<Blueprint>();

        public Settlement(string name, Location.Location location)
        {
            Name = name;
            Location = location;
            Stockpile = new Stockpile();
        }

        public void PassDay()
        {
            StartDay();
            DoWork();
            FeedSettlers();
            
            EventManager.GoThroughEvents(this);
            EventManager.ArchiveTodaysEvents();
            EventManager.ClearTodaysEvents();
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
            var eatCount = EventManager.TodaysEvents.OfType<SettlerAteEvent>().Count();
            var meals = new Bundle();
            foreach (var settlerAte in EventManager.TodaysEvents.OfType<SettlerAteEvent>())
            {
                meals += settlerAte.Meal;
            }
            EventManager.TodaysEvents.Add(new CumulativeSettlerAteEvent(eatCount, meals));
        }
        
        private void AddCumulativeSettlerStarvedEvent()
        {
            var starveCount = EventManager.TodaysEvents.OfType<SettlerStarvedEvent>().Count();
            EventManager.TodaysEvents.Add(new CumulativeSettlerStarvedEvent(starveCount));
        }

        public override string ToString()
        {
            return $"{Rank.Color}{Name}{CustomConsole.White}";
        }

        public void AddEvent(IEvent evn)
        {
            EventManager.TodaysEvents.Add(evn);
        }
    }
}