using System;

namespace SettlersOfValgard
{
    public class Random
    {
        private static System.Random _random = new System.Random();

        public static int Next(int ceiling)
        {
            return _random.Next(ceiling);
        }
    }
}