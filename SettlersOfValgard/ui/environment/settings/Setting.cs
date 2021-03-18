using SettlersOfValgardGame.ui.models;

namespace SettlersOfValgardGame.ui.environment.settings
{
    public abstract class Setting : NamedObject
    {
        public Setting(string nameText)
        {
            NameText = nameText;
        }

        public override string NameText { get; }
    }
}