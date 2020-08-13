using System;
using System.Collections.Generic;

namespace SettlersOfValgard.Util
{
    public class ArraysUtility
    {
        public static T[] Add<T>(params T[][] arrays)
        {
            List<T> list = new List<T>();
            foreach (var arr in arrays)
            {
                list.AddRange(arr);
            }
            return list.ToArray();
        }
        
        public static T[] SubArray<T>(T[] arr, int startIndex)
        {
            return SubArray(arr, startIndex, arr.Length - startIndex);
        }
        
        public static T[] SubArray<T>(T[] arr, int startIndex, int length)
        {
            if (arr.Length - startIndex < length)
            {
                throw new IndexOutOfRangeException("The length of the subarray exceeds the span of the given array!");
            }
            var newArray = new T[length];
            for (var i = 0; i < length; i++)
            {
                newArray[i] = arr[i + startIndex];
            }
            return newArray;
        }
    }
}