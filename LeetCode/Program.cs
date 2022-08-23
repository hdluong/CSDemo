using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class Program
    {
        public int RomanToInt(string s)
        {
            /*
             *  I -> 1
             *  V -> 5
             *  X -> 10
             *  L -> 50
             *  C -> 100
             *  D -> 500
             *  M -> 1000
            */

            // largest to smallest from left to right
            // I can be placed before V(5) and X(10) to make 4 and 9.
            // X can be placed before L(50) and C(100) to make 40 and 90.
            // C can be placed before D(500) and M(1000) to make 400 and 900.

            var valueMap = new SortedList<char, int>()
            {
                {'I', 1 },
                {'V', 5 },
                {'X', 10 },
                {'L', 50 },
                {'C', 100 },
                {'D', 500 },
                {'M', 1000 },
            };

            var result = 0;
            var i = 0;

            for (i = 0; i < s.Length - 1; i++)
            {
                switch (s[i])
                {
                    case 'I':
                        if (s[i+1].Equals('V') || s[i + 1].Equals('X'))
                        {
                            result += valueMap[s[i + 1]] - 1;
                            i++;
                            continue;
                        }

                        break;
                    case 'X':
                        if (s[i + 1].Equals('L') || s[i + 1].Equals('C'))
                        {
                            result += valueMap[s[i + 1]] - 10;
                            i++;
                            continue;
                        }

                        break;
                    case 'C':
                        if (s[i + 1].Equals('D') || s[i + 1].Equals('M'))
                        {
                            result += valueMap[s[i + 1]] - 100;
                            i++;
                            continue;
                        }

                        break;
                    default:
                        break;
                }

                result += valueMap[s[i]];
            }

            if (i < s.Length)
            {
                result += valueMap[s[i]];
            }

            return result;
        }

        public static string LongestCommonPrefix(string[] strs)
        {
            if (strs.Length == 1)
            {
                return strs[0];
            }

            if (string.IsNullOrEmpty(strs[0]))
            {
                return string.Empty;
            }

            string longestPrefix = strs[0];
            
            for (int i = 1; i < strs.Length; i++)
            {
                while (!strs[i].StartsWith(longestPrefix))
                {
                    longestPrefix = longestPrefix.Substring(0, longestPrefix.Length - 1);
                    if (string.IsNullOrEmpty(longestPrefix))
                    {
                        return longestPrefix;
                    }
                }
            }

            return longestPrefix;
        }
        
        static void Main(string[] args)
        {
            
        }
    }
}
