using System.Collections.Generic;
using System.Linq;

namespace SettlersOfValgard
{
    public class Random
    {
        private static readonly System.Random _random = new System.Random();

        public static int Next(int ceiling)
        {
            return _random.Next(ceiling);
        }

        public static T Entry<T>(T[] array)
        {
            return array[Next(array.Length)];
        }

        public static T Entry<T>(List<T> list)
        {
            return list[Next(list.Count)];
        }

        public static bool Odds(int chance, int total)
        {
            return Next(total) < chance;
        }

        public static int Weighted(params int[] arr)
        {
            //Copy array
            var list = new int[arr.Length];
            for (var i = 0; i < arr.Length; i++) list[i] = arr[i];

            var num = Next(list.Sum());
            for (var i = 0; i < list.Length; i++)
                if (num < list[i])
                {
                    return i;
                }
                else
                {
                    if (i < list.Length - 1) list[i + 1] += list[i];
                }

            return -1;
        }
    }
}