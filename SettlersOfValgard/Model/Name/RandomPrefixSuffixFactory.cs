using System;
using SettlersOfValgard.RandomLibrary;

namespace SettlersOfValgard.Model.Name
{
    public class RandomPrefixSuffixFactory : NameFactory
    {
        private string[] _prefix;
        private string[] _suffix;

        public RandomPrefixSuffixFactory(string[] prefix, string[] suffix)
        {
            this._prefix = prefix;
            this._suffix = suffix;
        }


        public override string Generate()
        {
            var rand = new RandomUtil();
            return $"{rand.Get(_prefix)}{rand.Get(_suffix)}";
        }
    }
}