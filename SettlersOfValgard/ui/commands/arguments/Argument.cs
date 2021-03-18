using SettlersOfValgardGame.ui.console.color;
using SettlersOfValgardGame.ui.console.text;
using SettlersOfValgardGame.ui.models;

namespace SettlersOfValgardGame.ui.commands.arguments
{
    public abstract class Argument : NamedObject, IDescribed
    {
        public Argument(string nameText, VText description)
        {
            NameText = nameText;
            Description = description;
        }

        public override string NameText { get; }

        public VText Description { get; }

        public abstract bool Fill(string input);
        public abstract bool IsFilled();
        public abstract void Clear();
    }
}