using System.Collections.Generic;
using System.Linq;
using SettlersOfValgardGame.settlersOfValgard.resources.bundles;
using SettlersOfValgardGame.settlersOfValgard.time;
using static SettlersOfValgardGame.ui.console.VConsole;

namespace SettlersOfValgardGame.settlersOfValgard.resources.storage
{
    //a bundle with limits
    public class Stockpile : Bundle, IDoesDailyUpdate
    {
        public List<Ledger> TransactionArchive { get; } = new List<Ledger>();
        public Ledger TodayTransactions { get; set; } = new Ledger();
        private Dictionary<StorageType, int> SizeLimit { get; set; }
        public Bundle SidePile { get; set; } = new Bundle();

        public int GetLimit(StorageType type)
        {
            return SizeLimit.ContainsKey(type) ? SizeLimit[type] : 0;
        }

        public Stockpile(params (StorageType, int)[] limits)
        {
            SizeLimit = new Dictionary<StorageType, int>();
            foreach (var (type, amount) in limits)
            {
                SizeLimit.Add(type, amount);
            }
        }

        public bool HasSpaceFor(Bundle bundle)
        {
            foreach (var (type, amount) in bundle.Size)
            {
                if (GetLimit(type) < amount + GetSize(type))
                {
                    return false;
                }
            }

            return true;
        }

        public override void Add(Resource resource, int amount)
        {
            var type = resource.StorageType;
            var space = GetLimit(type) - GetSize(type);

            if (space == 0)
            {
                SidePile.Add(resource, amount);
                WriteWarning(Text("Your stockpile is full for type ") + type);
                WriteWarning(resource + Text(" x" + amount + " added to sidepile!"));
            }
            else if(amount < space)
            {
                base.Add(resource, amount);
            }
            else
            {
                base.Add(resource, space);
                SidePile.Add(resource, amount - space);
                WriteWarning(Text("Your stockpile is full for type ") + type);
                WriteWarning(resource + Text(" x" + (amount - space) + " added to sidepile!"));
            }
        }
        
        public static Stockpile operator +(Stockpile stockpile, Bundle bundle)
        {
            foreach (var (resource, amount) in bundle)
            {
                stockpile.Add(resource, amount);
            }

            return stockpile;
        }

        public void DailyUpdate(SettlersOfValgard game)
        {
            //Clear sidepile
            SidePile = new Bundle();
            //Archive transactions
            TransactionArchive.Add(TodayTransactions);
            //Create new ledger for next day
            TodayTransactions = new Ledger();
        }
    }
}