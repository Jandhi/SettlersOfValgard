using System.Collections.Generic;
using SettlersOfValgardGame.ui.console.text;

namespace SettlersOfValgardGame.ui.elements
{
    public interface IMultiPageElement
    {
        void DisplayPage(int index);
        int CurrentPageNum { get; set; }
        int MaxPage { get; }
    }
}