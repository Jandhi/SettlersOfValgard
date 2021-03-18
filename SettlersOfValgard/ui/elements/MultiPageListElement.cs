using System;
using System.Collections.Generic;
using System.Linq;
using SettlersOfValgardGame.ui.commands;
using SettlersOfValgardGame.ui.commands.arguments;
using SettlersOfValgardGame.ui.commands.builder;
using SettlersOfValgardGame.ui.console.color;
using SettlersOfValgardGame.ui.console.text;
using SettlersOfValgardGame.ui.environment;
using SettlersOfValgardGame.ui.models;
using static SettlersOfValgardGame.ui.console.VConsole;

namespace SettlersOfValgardGame.ui.elements
{
    public class MultiPageListElement<T> : ListElement<T>, IMultiPageElement where T : VText
    {

        public static Command NextPageCommand<TItem>() where TItem : VText
        {
            var pagesArgument = new IntegerArgument("pages", Text("The amount of pages you would like to advance"));

            void NextPageAction<TItemInner>(Game game, Command command) where TItemInner : VText
            {
                var element = game.Elements[^1] as MultiPageListElement<TItemInner>;
                var pages = pagesArgument.IsFilled() ? pagesArgument.Content : 1;
                if (element.CurrentPageNum + pages <= element.MaxPage)
                {
                    element.CurrentPageNum += pages;
                    element.DisplayPage(element.CurrentPageNum);
                }
                else
                {
                    WriteError(pages == 1 ? "Already at last page!" : "You cannot advance that many pages!");
                }
            }

            return new CommandBuilder()
                .WithName("next")
                .WithDescription(Text("go to the next page"))
                .WithOptionalArguments(pagesArgument)
                .WithAction(NextPageAction<TItem>)
                .Build();
        }
        
        public static Command PreviousPageCommand<TItem>() where TItem : VText
        {
            var pagesArgument = new IntegerArgument("pages", Text("The amount of pages you would like to go back"));

            void PreviousPageAction<TItemInner>(Game game, Command command) where TItemInner : VText
            {
                var element = game.Elements[^1] as MultiPageListElement<TItemInner>;
                var pages = pagesArgument.IsFilled() ? pagesArgument.Content : 1;
                if (element.CurrentPageNum - pages > 0)
                {
                    element.CurrentPageNum -= pages;
                    element.DisplayPage(element.CurrentPageNum);
                }
                else
                {
                    WriteError(pages == 1 ? "Already at first page!" : "You cannot go back that many pages!");
                }
            }

            return new CommandBuilder()
                .WithName("previous")
                .WithDescription(Text("go to the previous page"))
                .WithOptionalArguments(pagesArgument)
                .WithAction(PreviousPageAction<TItem>)
                .Build();
        }
        
        public static Command PageCommand<TItem>() where TItem : VText
        {
            var pageArgument = new IntegerArgument("page", Text("The page you would like to go to"));

            void PageAction<TItemInner>(Game game, Command command) where TItemInner : VText
            {
                var element = game.Elements[^1] as MultiPageListElement<TItemInner>;
                var page = pageArgument.IsFilled() ? pageArgument.Content : 1;
                element.CurrentPageNum = page;
                element.DisplayPage(element.CurrentPageNum);
            }

            return new CommandBuilder()
                .WithName("page")
                .WithDescription(Text("go to the given page"))
                .WithArguments(pageArgument)
                .WithAction(PageAction<TItem>)
                .Build();
        }

        
        public int ItemsPerPage { get; }
        public int CurrentPageNum { get; set; } = 1;
        public int MaxPage => Contents.Count / ItemsPerPage + (Contents.Count % ItemsPerPage == 0 ? 0 : 1);

        public void DisplayPage(int page)
        {
            Clear();
            WriteLine("Page " + CurrentPageNum + "/" + MaxPage);
            WriteLine("--------");
            for (var index  = (page - 1) * ItemsPerPage; index < page * ItemsPerPage && index < Contents.Count; index++)
            {
                WriteLine(GetItemText(index));
            }
        }

        public override void Show(Game game)
        {
            game.AddLoop(new InputLoop(game, new List<Command>{NextPageCommand<T>(), PreviousPageCommand<T>(), PageCommand<T>()}, g => DisplayPage(CurrentPageNum)));
        }

        public MultiPageListElement(List<T> contents, int itemsPerPage, VText title = null, bool doClear = true, Func<T, VText> itemDisplayFunction = null, Func<int, VText> indexer = null) : base(contents, title, doClear, itemDisplayFunction, indexer)
        {
            ItemsPerPage = itemsPerPage;
        }
    }
}