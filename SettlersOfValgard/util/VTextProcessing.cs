using SettlersOfValgardGame.ui.console.text;
using SettlersOfValgardGame.ui.models;
using static SettlersOfValgardGame.ui.console.VConsole;

namespace SettlersOfValgardGame.util
{
    public class VTextProcessing
    {
        public static VText GetNameAndDescription<T>(T item) where T : NamedObject, IDescribed
        {
            return item.Name + Text(": ") + item.Description;
        }
    }
}