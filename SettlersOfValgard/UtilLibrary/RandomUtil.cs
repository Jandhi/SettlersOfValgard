using System;
using System.Collections.Generic;
using System.Linq;

namespace SettlersOfValgard.UtilLibrary
{
    public class RandomUtil
    {
        public static bool CoinFlip()
        {
            return new Random().Next(2) == 0;
        }
        public static T Get<T>(List<T> list)
        {
            return list == null || list.Count == 0 ? default : list[new Random().Next(list.Count)];
        }
        
        public static T Get<T>(T[] arr)
        {
            return arr.Length == 0 ? default : arr[new Random().Next(arr.Length)];
        }
        
        
        public static T WeightedGet<T>(IEnumerable<T> arr, T def, Func<T, int> weightFunc)
        {
            var roll = new Random().Next(arr.Aggregate(0, (sum, arg) => sum + weightFunc(arg)));
            var cumulative = 0;
            foreach (var t in arr)
            {
                cumulative += weightFunc(t);
                if (roll < cumulative) return t;
            }

            return def;
        }
        
        public static T WeightedPercentGet<T>(IEnumerable<T> arr, T def, Func<T, int> weightFunc)
        {
            var roll = new Random().Next(100);
            var cumulative = 0;
            foreach (var t in arr)
            {
                cumulative += weightFunc(t);
                if (roll < cumulative) return t;
            }

            return def;
        }

        public static bool Chance(int chance, int total)
        {
            return new Random().Next(total) < chance;
        }
    }
}