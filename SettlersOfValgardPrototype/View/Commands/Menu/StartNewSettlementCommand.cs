using System.Collections.Generic;
using System.Linq;
using SettlersOfValgard.Model.Building;
using SettlersOfValgard.Model.Building.Residence;
using SettlersOfValgard.Model.Building.Workplace.Harvest;
using SettlersOfValgard.Model.Location;
using SettlersOfValgard.Model.Rank;
using SettlersOfValgard.Model.Resource;
using SettlersOfValgard.Model.Resource.Food;
using SettlersOfValgard.Model.Resource.Material;
using SettlersOfValgard.Model.Settler;
using SettlersOfValgard.Model.Settler.Gender;
using SettlersOfValgard.Model.Settler.Relationship;
using SettlersOfValgard.Model.Varsk;
using SettlersOfValgard.UtilLibrary;
using SettlersOfValgard.View.Commands.Core;
using SettlersOfValgard.View.Commands.Settlement;

namespace SettlersOfValgard.View.Commands.Menu
{
    public class StartNewSettlementCommand : Command
    {
        public override string Name => "Start New Settlement";
        public override string[] Aliases { get; } = {"s"};
        public override string UseCommandTo => "Start a new settlement";

        public override void Execute(Game game)
        {
            game.IsInMenu = false;
            
            CustomConsole.WriteLine($"As the snow-covered passes melt, your people have made their way to {CustomConsole.Cyan}Dalland{CustomConsole.White} to start a new life.");
            CustomConsole.WriteLine("After weeks of travel, we have finally found a place we may call home.");
            
            var playerName = IOManager.GetName($"What is your name, {PlayerRank.Freeman}?");
            while (!IOManager.GetYesNo($"Your name is {playerName}?"))
            {
                playerName = IOManager.GetName($"What is your name, {PlayerRank.Freeman}?");
            }
            game.PlayerName = playerName;

            var settlementName = IOManager.GetName($"What shall we call our settlement, {PlayerRank.Freeman} {playerName}?");
            while (!IOManager.GetYesNo($"You want to call our settlement {settlementName}?"))
            {
                settlementName = IOManager.GetName($"What shall we call our settlement, {PlayerRank.Freeman} {playerName}?");
            }
            
            game.Settlement = new Model.Settlement.Settlement(settlementName, new TemperateLocation(), new VarskCulture());
            SetUpSettlement(game.Settlement);
            new StatusCommand().Execute(game);
        }

        private void SetUpSettlement(Model.Settlement.Settlement settlement)
        {
            AddStockpile(settlement);
            AddBluePrints(settlement);
            
            for(int i = 0; i < 3; i++) AddFamilyWithHome(settlement);
            AddMaleRivalry(settlement);
        }

        private void AddStockpile(Model.Settlement.Settlement settlement)
        {
            settlement.Stockpile.Contents.Add(Material.Wood, 50);
            settlement.Stockpile.Contents.Add(Material.Stone, 20);
            settlement.Stockpile.Contents.Add(Food.Grain, 200);
        }

        private void AddFamilyWithHome(Model.Settlement.Settlement settlement)
        {
            Family family = new VarskFamilyFactory(settlement.SettlerManager).Generate();
            settlement.SettlerManager.Add(family);
            Residence residence = new Hut();
            settlement.Buildings.Add(residence);
            residence.AddResident(family);
        }

        private void AddBluePrints(Model.Settlement.Settlement settlement)
        {
            settlement.Blueprints.Add(new Blueprint("Hut", new Hut(), new Bundle(Material.Wood, 10)));
            settlement.Blueprints.Add(new Blueprint("Hunter's Hut", new HuntersHut(), new Bundle(Material.Wood, 10)));
        }

        private void AddMaleRivalry(Model.Settlement.Settlement settlement)
        {
            var settler1 = RandomUtil.Get(settlement.SettlerManager.Settlers.Where(s => BinaryGender.Male.Is(s)).ToList());
            var settler2 =
                RandomUtil.Get(settlement.SettlerManager.Settlers.Where(s => BinaryGender.Male.Is(s) && s != settler1).ToList());
            AcquaintanceRelationship.Make(settlement.SettlerManager, -25, settler1, settler2);
        }
    }
}