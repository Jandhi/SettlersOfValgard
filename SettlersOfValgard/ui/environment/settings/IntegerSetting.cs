namespace SettlersOfValgardGame.ui.environment.settings
{
    public class IntegerSetting : Setting
    {
        public IntegerSetting(string nameText, int content) : base(nameText)
        {
            Content = content;
        }
        
        public int Content { get; set; }
    }
}