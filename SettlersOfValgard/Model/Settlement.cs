using System.Collections.Generic;
using SettlersOfValgard.Model.Building;
using SettlersOfValgard.Model.Location.Weather;
using SettlersOfValgard.Model.Name;
using SettlersOfValgard.Model.Rank;
using SettlersOfValgard.Model.Resource;
using SettlersOfValgard.Model.Settler;
using SettlersOfValgard.Model.Time;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model
{
    public class Settlement : INamed, IDated
    {
        public string Name { get; }

        public Date Birthday { get; } = new Date(0);
        public Location.Location Location { get; }

        public Date TodaysDate { get; set; } = new Date(0);
        public Weather TodaysWeather { get; set; }
        
        public Stockpile Stockpile { get; }

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
        }

        public override string ToString()
        {
            return $"{Rank.Color}{Name}{CustomConsole.White}";
        }
    }
}