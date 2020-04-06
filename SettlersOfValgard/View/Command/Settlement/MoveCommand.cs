using System;

namespace SettlersOfValgard.View.Command.Settlement
{
    public class MoveCommand : Command
    {
        public override string Name => "Move";
        public override string[] Aliases { get; } = {"mv", "move", "Move"};
        public override string ToolTip => "Use ";

        protected override void Execute(string[] args, Game game)
        {
            string name1;
            string name2;
            var ordinal1 = -1;
            var ordinal2 = -1;
            var error = false;
            if (args.Length == 2)
            {
                name1 = args[0];
                name2 = args[1];
            } 
            else if (args.Length == 4)
            {
                try
                {
                    name1 = args[0];
                    ordinal1 = int.Parse(args[1]);
                    name2 = args[2];
                    ordinal2 = int.Parse(args[2]);
                }
                catch (FormatException e)
                {
                    //ERROR
                    error = true;
                }
            }
            else if (args.Length == 3)
            {
                name1 = args[0];
                try
                {
                    ordinal1 = int.Parse(args[1]);
                    name2 = args[2];
                }
                catch (FormatException e1)
                {
                    name2 = args[1];
                    try
                    {
                        ordinal2 = int.Parse(args[2]);
                    }
                    catch (FormatException e2)
                    {
                        //ERROR
                        error = true;
                    }
                }
            }

            if (error)
            {
                
            }
            else
            {
                
            }
        }
    }
}