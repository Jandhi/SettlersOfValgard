using SettlersOfValgardGame.ui.console.text;
using SettlersOfValgardGame.ui.environment;
using static SettlersOfValgardGame.ui.console.VConsole;

namespace SettlersOfValgardGame.ui.elements
{
    public class TitleElement : IUiElement
    {
        public TitleElement(VText title)
        {
            Title = title;
        }

        public VText Title { get; }
        
        public void Show(Game game)
        {
            WriteLine(Title.Apply(VTextTransform.ToUpper()));
            WriteLine("----------");
        }
    }
}