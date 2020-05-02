using System;

namespace SettlersOfValgard.UtilLibrary
{
    public class ArraysUtility
    {
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