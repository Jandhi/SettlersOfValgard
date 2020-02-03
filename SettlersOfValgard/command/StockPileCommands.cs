using SettlersOfValgard.resource;

namespace SettlersOfValgard.command
{
    public static class StockPileCommands
    {
        public static void StockPile(Command command)
        {
            if (command.Args.Count == 0)
            {
                var isEmpty = true;
                
                foreach ((Resource resource, int amount) in Settlement.Get().StockPile.Contents)
                {
                    if (amount > 0)
                    {
                        isEmpty = false;
                        Console.WriteLine(resource + " x" + amount);
                    }
                }
                
                if(isEmpty) Console.WriteLine("Your stockpile is empty.");
            }
        } 
    }
}