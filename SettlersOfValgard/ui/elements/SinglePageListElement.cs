using System;
using System.Collections.Generic;
using SettlersOfValgardGame.ui.console.text;
using SettlersOfValgardGame.ui.environment;
using static SettlersOfValgardGame.ui.console.VConsole;

namespace SettlersOfValgardGame.ui.elements
{
    public class SinglePageListElement<T> : ListElement<T> where T : VText
    {
        public SinglePageListElement(List<T> contents, VText title = null, bool doClear = true, Func<T, VText> itemDisplayFunction = null, Func<int, VText> indexer = null) : base(contents, title, doClear, itemDisplayFunction, indexer)
        {
        }

        public override void Show(Game game)
        {
            if (DoClear)
            {
                Clear();
            }

            if (Title != null)
            {
                game.AddElement(new TitleElement(Title));
            }
            
            for (var index = 0; index < Contents.Count; index++)
            {
                WriteLine(GetItemText(index));
            }
        }
    }
}