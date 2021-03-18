using SettlersOfValgardGame.ui.console.text;

namespace SettlersOfValgardGame.ui.commands.arguments
{
    public class StringArgument : Argument
    {
        public StringArgument(string nameText, VText description) : base(nameText, description)
        {
        }
        
        public string Content { get; set; }

        public override bool Fill(string input)
        {
            Content = input;
            return true;
        }

        public override bool IsFilled()
        {
            return Content != null;
        }

        public override void Clear()
        {
            Content = null;
        }
    }
}