using System.Collections.Generic;
using System.Linq;
using SettlersOfValgardGame.ui.environment;

namespace SettlersOfValgardGame.settlersOfValgard.resources.storage
{
    //A ledger with positive amounts
    public class Bundle : Ledger
    {
        public Bundle(Dictionary<Resource, int> contents) : base(contents)
        {
            VerifyIntegrity();
        }

        public Bundle(params (Resource, int)[] items) : base(items)
        {
            VerifyIntegrity();
        }
        
        public Dictionary<StorageType, int> Size { get; set; }

        public int GetSize(StorageType type)
        {
            return Size.ContainsKey(type) ? Size[type] : 0;
        }

        public int this[Resource key]
        {
            get => Contents.Keys.Contains(key) ? Contents[key] : 0;
            set => Contents[key] = value;
        }

        public override void Add(Resource resource, int amount)
        {
            base.Add(resource, amount);
            VerifyIntegrity();
        }

        protected void VerifyIntegrity()
        {
            Size = new Dictionary<StorageType, int>();
            foreach (var (resource, amount) in Contents)
            {
                if (amount < 0)
                {
                    throw new GameException("A bundle cannot have negative items!", game =>
                    {
                        Contents = new Dictionary<Resource, int>();
                        VerifyIntegrity();
                    });
                }

                if (Size.Keys.Contains(resource.StorageType))
                {
                    Size[resource.StorageType] += resource.Size * amount;
                }
                else
                {
                    Size.Add(resource.StorageType, resource.Size * amount);
                }
            }
        }

        public static Bundle operator +(Bundle a, Bundle b)
        {
            var bundle = new Bundle();

            foreach (var (resource, amount) in a)
            {
                bundle.Add(resource, amount);
            }
            
            foreach (var (resource, amount) in b)
            {
                bundle.Add(resource, amount);
            }

            return bundle;
        }

        public bool Contains(Bundle other)
        {
            foreach (var (type, amount) in other.Size)
            {
                if (!Size.ContainsKey(type) || Size[type] < amount)
                {
                    return false;
                }
            }

            foreach (var (resource, amount) in other)
            {
                if (this[resource] < amount)
                {
                    return false;
                }
            }

            return true;
        }
    }
}