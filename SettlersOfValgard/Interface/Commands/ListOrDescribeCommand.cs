using System.Collections.Generic;
using SettlersOfValgard.Interface.Commands.Arguments;
using SettlersOfValgard.Interface.Console;
using SettlersOfValgard.Util;

namespace SettlersOfValgard.Interface.Commands
{
    public abstract class ListOrDescribeCommand<T> : Command where T : INamed
    {
        public abstract List<T> List(Game.Game game);
        public abstract void Describe(T t);
        public abstract string TypeName { get; }
        
        public StringArgument NameArgument;

        public ListOrDescribeCommand()
        {
            NameArgument = new StringArgument("name", $"The start of the name of the {TypeName}");
        }

        public override List<Argument> Arguments => new List<Argument>{NameArgument};

        public override void Execute(Game.Game game)
        {
            var list = StringsUtility.Match(NameArgument.Contents, List(game));
            if (list.Count == 0)
            {
                VConsole.WriteLine($"No {TypeName} found!");
            } 
            else if (list.Count > 1)
            {
                foreach (var item in list)
                {
                    VConsole.WriteLine($"{item}");
                }
            }
            else
            {
                Describe(list[0]);
            }
        }
    }
}