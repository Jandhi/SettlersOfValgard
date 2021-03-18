using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SettlersOfValgardGame.ui.models;

namespace SettlersOfValgardGame.util
{
    public static class StringMatching
    {
        public struct MatchCriteria
        {
            public MatchCriteria(string prefix = null, string suffix = null, string infix = null, int length = -1, int minLength = -1, int maxLength = -1, bool ignoreCase = false)
            {
                Prefix = prefix;
                Suffix = suffix;
                Infix = infix;
                Length = length;
                MinLength = minLength;
                MaxLength = maxLength;
                IgnoreCase = ignoreCase;

                if (ignoreCase)
                {
                    Prefix = prefix?.ToLower();
                    Suffix = suffix?.ToLower();
                    Infix = infix?.ToLower();
                }
            }

            public string Prefix { get; }
            public string Suffix { get; }
            public string Infix { get; }
            public int Length { get; }
            public int MinLength { get; }
            public int MaxLength { get; }
            public bool IgnoreCase { get; }
            
            public bool IsMatch(string target)
            {
                if (IgnoreCase)
                {
                    target = target.ToLower();
                }
                
                var isMatch = true;

                if (Prefix != null)
                {
                    isMatch = target.StartsWith(Prefix);
                }

                if (Suffix != null)
                {
                    isMatch = isMatch && target.EndsWith(Suffix);
                }

                if (Infix != null)
                {
                    isMatch = isMatch && target.Contains(Infix);
                }

                if (Length > -1)
                {
                    isMatch = isMatch && target.Length == Length;
                }

                if (MaxLength > -1)
                {
                    isMatch = isMatch && target.Length <= MaxLength;
                }

                if (MinLength > -1)
                {
                    isMatch = isMatch && target.Length >= MinLength;
                }

                return isMatch;
            }

            public bool IsEmpty()
            {
                return Prefix == null && Suffix == null && Infix == null && Length == -1 && MinLength == -1 &&
                       MaxLength == -1;
            }
        }
        
        public static T[] SearchByName<T>(IEnumerable<T> arr, MatchCriteria criteria) where T : INamed
        {
            return Search(arr, criteria, item => item.Name.GetContentRaw());
        }

        public static T[] Search<T>(IEnumerable<T> arr, MatchCriteria criteria, Func<T, string> source)
        {
            return arr.Where(item => criteria.IsMatch(source(item))).ToArray();
        }
    }
}