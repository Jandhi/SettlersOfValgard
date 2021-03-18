using System;
using SettlersOfValgardGame.ui.console.text;

namespace SettlersOfValgardGame.ui.commands.arguments
{
    public class FloatArgument : Argument
    {
        public FloatArgument(string nameText, VText description) : base(nameText, description)
        {
        }
        
        public float Content { get; set; }
        public bool IsNull { get; set; } = true;

        public override bool Fill(string input)
        {
            try
            {
                Content = float.Parse(input);
                IsNull = false;
                return true;
            }
            catch (FormatException)
            {
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