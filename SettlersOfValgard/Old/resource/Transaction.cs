namespace SettlersOfValgard.resource
{
    public class Transaction
    {
        public Resource Type;
        public int Amount;

        public Transaction(Resource type, int amount)
        {
            Type = type;
            Amount = amount;
        }
    }
}