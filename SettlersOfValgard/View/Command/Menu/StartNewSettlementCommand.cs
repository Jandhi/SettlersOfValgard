using SettlersOfValgard.Model;
using SettlersOfValgard.Model.Building;
using SettlersOfValgard.Model.Building.Residence;
using SettlersOfValgard.Model.Building.Workplace.Harvest;
using SettlersOfValgard.Model.Location;
using SettlersOfValgard.Model.Rank;
using SettlersOfValgard.Model.Resource;
using SettlersOfValgard.Model.Resource.Food;
using SettlersOfValgard.Model.Resource.Material;
using SettlersOfValgard.Model.Settler;
using SettlersOfValgard.Model.Varsk;
using SettlersOfValgard.UtilLibrary;
using SettlersOfValgard.View.Command.Settlement;

namespace SettlersOfValgard.View.Command.Menu
{
    public class StartNewSettlementCommand : Command
    {
        public override string Name => "Start New Settlement";
        public override string[] Aliases { get; } = {"s"};
        public override bool AvailableInMenu => true;
        public override string ToolTip => $"Use \"{Aliases[0]}\" to start a new settlement from the menu.";

        protected override void Execute(string[] args, Game game)
        {
            game.IsInMenu = false;
            
            CustomConsole.WriteLine($"As the snow-covered passes melt, your people have made their way to {CustomConsole.Cyan}Dalland{CustomConsole.White} to start a new life.");
            CustomConsole.WriteLine("After weeks of travel, we have finally found a place we may call home.");
            CustomConsole.WriteLine($"What is your name, {PlayerRank.Freeman}?");
            var playerName = IOManager.GetName();
            game.PlayerName = playerName;
            CustomConsole.WriteLine($"What shall we call our settlement, {PlayerRank.Freeman} {playerName}?");
            var settlementName = IOManager.GetName();
            game.Settlement = new Model.Core.Settlement(settlementName, new TemperateLocation());
            SetUpSettlement(game.Settlement);
            new StatusCommand().AttemptExecution(new string[0], game);
        }

        private void SetUpSettlement(Model.Core.Settlement settlement)
        {
            AddStockpile(settlement);
            AddBluePrints(settlement);
            
            for(int i = 0; i < 3; i++) AddFamilyWithHome(settlement);
        }

        private void AddStockpile(Model.Core.Settlement settlement)
        {
            settlement.Stockpile.Contents.Add(Material.Wood, 30);
            settlement.Stockpile.Contents.Add(Material.Stone, 10);
            settlement.Stockpile.Contents.Add(Food.Grain, 50);
        }

        private void AddFamilyWithHome(Model.Core.Settlement settlement)
        {
            Family family = new VarskFamilyFactory().Generate();
            settlement.Families.Add(family);
            Residence residence = new Hut();
            settlement.Buildings.Add(residence);
            residence.AddResident(family);
        }

        private void AddBluePrints(Model.Core.Settlement settlement)
        {
            settlement.Blueprints.Add(new Blueprint("Hut", new Hut(), new Bundle(Material.Wood, 10)));
            settlement.Blueprints.Add(new Blueprint("Hunter's Hut", new HuntersHut(), new Bundle(Material.Wood, 10)));
        }
    }
}