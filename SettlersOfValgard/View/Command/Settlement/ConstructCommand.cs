using System.Linq;
using System.Text;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.View.Command.Settlement
{
    
    public class ConstructCommand : Command
    {
        public override string Name => "Construct";
        public override string[] Aliases { get; } = {"c", "construct", "Construct"};
        public override bool NeedsValidation => false;
        public override bool AvailableInMenu => false;
        protected override void Execute(string[] args, Game game)
        {
            if (args.Length == 0)
            {
                CustomConsole.WriteLine($"{CustomConsole.Red}You must choose a blueprint to construct. Use \"bp\" to list blueprints.{CustomConsole.White}");
            }
            else
            {
                var stringBuilder = new StringBuilder(args[0]);
                for (int i = 1; i < args.Length; i++) stringBuilder.Append($" {args[i]}");
                var name = stringBuilder.ToString();
                var blueprint = game.Settlement.Blueprints.FirstOrDefault(bp => bp.Name == name);
                if (blueprint == null)
                {
                    
                }
            }
        }
    }
}