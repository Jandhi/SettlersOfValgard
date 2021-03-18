using System;
using System.Collections.Generic;
using System.Linq;
using SettlersOfValgardGame.ui.console.text;
using SettlersOfValgardGame.ui.environment;
using SettlersOfValgardGame.ui.environment.settings;
using static SettlersOfValgardGame.ui.console.VConsole;

namespace SettlersOfValgardGame.ui.elements
{
    public abstract class ListElement<T> : IUiElement where T : VText
    {
        protected ListElement(List<T> contents, VText title = null, bool doClear = true, Func<T, VText> itemDisplayFunction = null, Func<int, VText> indexer = null)
        {
            Contents = contents;
            Title = title;
            DoClear = doClear;
            ItemDisplayFunction = itemDisplayFunction;
            Indexer = indexer;
        }

        public List<T> Contents { get; }
        private Func<T, VText> ItemDisplayFunction { get; }
        private Func<int, VText> Indexer { get; }
        public VText Title { get; }
        public bool DoClear { get; }

        public VText GetItemText(int index)
        {
            VText text;

            if (ItemDisplayFunction != null)
            {
                text = ItemDisplayFunction(Contents[index]);
            }
            else
            {
                text = Contents[index];
            }

            if (Indexer != null)
            {
                text = Indexer(index) + text;
            }
            
            return text;
        }
        
        public abstract void Show(Game game);
        
        public static ListElement<T> CreateListElement(List<T> contents, VText title = null, bool doClear = true, Func<T, VText> itemDisplayFunction = null, Func<int, VText> indexer = null)
        {
            if (contents.Count >= Settings.MultiPageDisplayThreshold.Content)
            {
                return new MultiPageListElement<T>(contents, Settings.MultiPageDisplayThreshold.Content, title, doClear, itemDisplayFunction, indexer);
            }
            else
            {
                return new SinglePageListElement<T>(contents, title, doClear, itemDisplayFunction, indexer);
            }
        }

        public static ListElement<T> CreateListElement(VText title = null, bool doClear = true, Func<T, VText> itemDisplayFunction = null, Func<int, VText> indexer = null, params T[] contents)
        {
            return CreateListElement(contents.ToList(), title, doClear, itemDisplayFunction, indexer);
        }
    }
}