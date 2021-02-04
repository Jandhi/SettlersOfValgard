using System.Collections.Generic;

namespace SettlersOfValgard.UtilLibrary
{
    public class DefaultValueDictionary<TKey, TValue>
    {
        public DefaultValueDictionary(TValue defaultValue)
        {
            DefaultValue = defaultValue;
        }

        public TValue Get(TKey key)
        {
            if(!Dictionary.ContainsKey(key)) Dictionary.Add(key, DefaultValue);
            return Dictionary[key];
        }

        public void Set(TKey key, TValue value)
        {
            if (Dictionary.ContainsKey(key))
            {
                Dictionary[key] = value;
            }
            else
            {
                Dictionary.Add(key, value);
            }
        }
        
        public TValue this[TKey key]
        {
            get => Get(key);
            set => Set(key, value);
        }

        public TValue DefaultValue { get; }
        public Dictionary<TKey, TValue> Dictionary { get; } = new Dictionary<TKey, TValue>();
        
    }
}