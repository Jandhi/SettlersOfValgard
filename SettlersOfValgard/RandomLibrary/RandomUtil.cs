using System;

namespace SettlersOfValgard.RandomLibrary
{
    public class RandomUtil
    {
        
        public T Get<T>(T[] arr)
        {
            return arr[new Random().Next(arr.Length)];
        }
    }
}