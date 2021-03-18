using System;
using SettlersOfValgardGame.ui.console;
using SettlersOfValgardGame.ui.console.color;
using SettlersOfValgardGame.ui.console.text;
using static SettlersOfValgardGame.ui.console.VConsole;

namespace SettlersOfValgardGame.ui.commands.arguments
{
    public class IntegerArgument : Argument
    {
        public IntegerArgument(string nameText, VText description) : base(nameText, description)
        {
        }
        
        public int Content { get; set; }
        public bool IsNull { get; set; } = true;

        public override bool Fill(string input)
        {
            try
            {
                Content = int.Parse(input);
                IsNull = false;
                return true;
            }
            catch (FormatException)
            {
                WriteError(Name + Text(" needs an integer argument. (Received ") 
                                + Text(input).Apply(VTextTransform.Quote()).Apply(VTextTransform.SetForeground(ColorStandards.Input)) 
                                + Text(")"));
                return false;
            }
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