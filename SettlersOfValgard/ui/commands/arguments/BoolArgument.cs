using SettlersOfValgardGame.ui.console;
using SettlersOfValgardGame.ui.console.color;
using SettlersOfValgardGame.ui.console.text;
using static SettlersOfValgardGame.ui.console.VConsole;

namespace SettlersOfValgardGame.ui.commands.arguments
{
    public class BoolArgument : Argument
    {
        public BoolArgument(string nameText, VText description) : base(nameText, description)
        {
        }
        
        public bool Content { get; set; }
        public bool IsNull { get; set; } = true;

        public override bool Fill(string input)
        {
            if (input.ToLower().StartsWith("f"))
            {
                Content = false;
                IsNull = false;
            } 
            else if (input.ToLower().StartsWith("t"))
            {
                Content = true;
                IsNull = false;
            }
            else
            {
                WriteError(Name + Text(" needs a boolean argument. (Received ") 
                                + Text(input).Apply(VTextTransform.Quote()).Apply(VTextTransform.SetForeground(ColorStandards.Input)) 
                                + Text(")"));
                IsNull = true;
            }

            return !IsNull;
        }

        public override bool IsFilled()
        {
            return !IsNull;
        }

        public override void Clear()
        {
            IsNull = true;
        }
    }
}