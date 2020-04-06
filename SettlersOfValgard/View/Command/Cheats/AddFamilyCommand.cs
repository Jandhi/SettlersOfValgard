using SettlersOfValgard.Model.Varsk;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.View.Command.Cheats
{
    public class AddFamilyCommand : Command
    {
        public override string Name => "AddFamily";
        public override string[] Aliases { get; } = {"addf", "addFamily", "addfamily", "addfam", "addFam"};
        public override bool NeedsGodMode => true;

        public override string ToolTip => $"Use \"{Aliases[0]}\" to add a Varsk family to your settlement.";

        protected override void Execute(string[] args, Game game)
        {
            var family = new VarskFamilyFactory().Generate();
            game.Settlement.Families.Add(family);
            CustomConsole.WriteLine($"Added {family.Members.Count} new settlers.");
        }
    }
}