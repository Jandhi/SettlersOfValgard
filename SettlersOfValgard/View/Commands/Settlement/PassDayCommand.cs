using System.Collections.Generic;
using SettlersOfValgard.View.Commands.Core;
using SettlersOfValgard.View.Commands.Core.Arguments;

namespace SettlersOfValgard.View.Commands.Settlement
{
    public class PassDayCommand : Command
    {
        public override string Name => "PassDay";
        public override string[] Aliases { get; } = {"d", "day"};
        public override string UseCommandTo => "Pass a given amount of days";
        public override List<Argument> OptionalArguments => new List<Argument>{DayAmountArgument};
        public NaturalNumberArgument DayAmountArgument = new NaturalNumberArgument("Number", "Number of Days to Pass"); 
        public override void Execute(Game game)
        {
            if (DayAmountArgument.IsFilled)
            {
                game.Settlement.StopDayPass = false;
                for (int i = 0; i < DayAmountArgument.Contents && !game.Settlement.StopDayPass; i++) game.Settlement.PassDay();
            }
            else
            {
                game.Settlement.PassDay();
            }
        }
    }
}