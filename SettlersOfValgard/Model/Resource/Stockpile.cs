namespace SettlersOfValgard.Model.Resource
{
    public class Stockpile
    {
        public Bundle Contents { get; }

        public Stockpile(Bundle contents)
        {
            Contents = contents;
        }
    }
}