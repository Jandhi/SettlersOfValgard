using System;
using System.Linq;

namespace SettlersOfValgard.UtilLibrary
{
    public class MathUtil
    {
        
        public static double UnroundedAverage<T>(Func<T, int> weightFunction, params T [] list)
        {
            return (double) list.Aggregate(0, (sum, t) => sum + weightFunction(t)) / list.Length;
        }
        public static double UnroundedAverage(params int [] list)
        {
            return (double) list.Aggregate(0, (sum, i) => sum + i) / list.Length;
        }
        
        public static int Average(params int [] list)
        {
            return list.Aggregate(0, (sum, i) => sum + i) / list.Length;
        }

        public static int RoundTowardsZero(double num)
        {
            if (num > 0)
            {
                return (int) num;
            }
            else
            {
                var i = (int) num;
                if (num - i > 0)
                {
                    return i + 1;
                }
                else
                {
                    return i;
                }
            }
        }
    }
}