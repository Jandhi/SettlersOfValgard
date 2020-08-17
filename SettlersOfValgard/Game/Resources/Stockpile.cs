namespace SettlersOfValgard.Game.Resources
{
    /*
     * A bundle with size limits
     */
    public class Stockpile : Bundle
    {
        public Stockpile(int maxSize)
        {
            MaxSize = maxSize;
        }

        public int MaxSize { get; set; }
        public int Space => MaxSize - Size;
        

        //Adds as much as possible, returns rest
        public Bundle Add(Bundle bundle)
        {
            var leftovers = new Bundle();
            foreach (var (resource, bundleAmount) in bundle)
            {
                var addAmount = Space / resource.Size;
                
                if (bundleAmount < addAmount)
                {
                    Add(resource, bundleAmount);
                }
                else
                {
                    Add(resource, addAmount);
                    leftovers.Add(resource, bundleAmount - addAmount);
                }
            }

            return leftovers;
        }

        public override bool Add(Resource res, int amount)
        {
            if (amount < 0) return false;
            return Space > res.Size * amount && base.Add(res, amount);
        }
    }
}