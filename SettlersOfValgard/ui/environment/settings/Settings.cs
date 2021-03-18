using System.Collections.Generic;

namespace SettlersOfValgardGame.ui.environment.settings
{
    public class Settings
    {
        public static readonly List<Setting> All = new List<Setting>();

        public static IntegerSetting MultiPageDisplayThreshold { get; } = new IntegerSetting("MultiPageDisplayThreshold", 10);

        public static void LoadSettings()
        {
            All.Add(MultiPageDisplayThreshold);
        }
    }
}