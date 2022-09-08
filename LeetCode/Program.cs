using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class Program
    {
        /// <summary>
        /// 13. Roman to Integer
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 14. Longest Common Prefix
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
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

        #region Sorting
        public static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        public static void BubbleSort(int[] arr)
        {
            var swapped = true;
            var n = arr.Length;

            while (swapped)
            {
                swapped = false;

                for (int i = 0; i < n - 1; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        Swap(ref arr[i], ref arr[i + 1]);
                        swapped = true;
                    }
                }

                n--;
            }
        }

        public static void SelectionSort(int[] arr)
        {
            var n = arr.Length;
            for (int i = 0; i < n-1; i++)
            {
                var minIndex = i;
                for (int j = i+1; j < n; j++)
                {
                    if (arr[j] < arr[minIndex])
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    Swap(ref arr[i], ref arr[minIndex]);
                }
            }
        }

        public static void InsertionSort(int[] arr)
        {
            var n = arr.Length;
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (arr[j] < arr[j-1])
                    {
                        Swap(ref arr[j], ref arr[j - 1]);
                    }
                }
            }
        }
        #endregion

        #region Array
        public static void PrintArray<T>(T[] array)
        {
            foreach (var x in array)
            {
                Console.WriteLine(x);
            }
        }

        /// <summary>
        /// 1295. Find Numbers with Even Number of Digits
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int FindEvenNumbers(int[] nums)
        {
            var count = 0;
            var numDigits = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                numDigits = 0;
                int tmp = nums[i];

                while (tmp > 0)
                {
                    tmp = tmp/10;
                    numDigits++;
                }

                if (numDigits % 2 == 0)
                {
                    count++;
                }
            }

            return count;
        }

        /// <summary>
        /// 977. Squares of a Sorted Array
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int[] SortedSquares(int[] nums)
        {
            var n = nums.Length;
            var squares = new int[n];
            int i = 0, j = n - 1;

            for (int k = n - 1; k >= 0; k--)
            {
                if (Math.Abs(nums[i]) > Math.Abs(nums[j]))
                {
                    squares[k] = nums[i] * nums[i];
                    i++;
                }
                else
                {
                    squares[k] = nums[j] * nums[j];
                    j--;
                }
            }

            return squares;
        }

        /*
         * 1089. Duplicate Zeros
         * Input: arr = [1,0,2,3,0,4,5,0]
         * Output:      [1,0,0,2,3,0,0,4]
         * 
        */
        public static void DuplicateZeros(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 0)
                {
                    for (int j = arr.Length - 1; j > i; j--)
                    {
                        arr[j] = arr[j - 1];
                    }

                    arr[i] = 0;
                    i++;
                }
            }
        }

        public static void DuplicateZeros1(int[] arr)
        {
            var queue = new Queue<int>();
            int i = 0;

            while (i < arr.Length)
            {
                if (arr[i] == 0)
                {
                    queue.Enqueue(0);
                    queue.Enqueue(0);
                }
                else
                {
                    queue.Enqueue(arr[i]);
                }

                arr[i] = queue.Dequeue();
                i++;
            }

        }

        /*
         * 88. Merge Sorted Array
         * Input: nums1 = [1,2,3,0,0,0], m = 3, nums2 = [2,5,6], n = 3
         * Output: [1,2,2,3,5,6]
         *
        */
        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            var i = m - 1;
            var j = n - 1;
            var k = m + n - 1;

            while (i >= 0 || j >= 0)
            {
                if (i >= 0 && j >= 0)
                {
                    if (nums2[j] >= nums1[i])
                    {
                        nums1[k--] = nums2[j--];
                    }
                    else
                    {
                        nums1[k--] = nums1[i--];
                    }
                }
                else if (i >= 0)
                {
                    nums1[k--] = nums1[i--];
                }
                else
                {
                    nums1[k--] = nums2[j--];
                }
            }
        }

        /// <summary>
        /// 27. Remove Element
        /// Input: nums = [0,1,2,2,3,0,4,2], val = 2
        /// Output: 5, nums = [0,1,4,0,3, _, _, _]
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public static int RemoveElement(int[] nums, int val)
        {
            var j = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != val)
                {
                    nums[j++] = nums[i];
                }
            }

            return j;
        }

        /// <summary>
        /// 26. Remove Duplicates from Sorted Array
        /// Input: nums = [0,0,1,1,1,2,2,3,3,4]
        /// Output: 5, nums = [0,1,2,3,4, _, _, _, _, _]
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int RemoveDuplicates(int[] nums)
        {
            var j = 1;
            var val = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] != val)
                {
                    nums[j++] = nums[i];
                    val = nums[i];
                }
            }

            return j;
        }

        /// <summary>
        /// 1346. Check If N and Its Double Exist
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static bool CheckIfExist(int[] arr)
        {
            var idxMap = new SortedList<int, int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (idxMap.ContainsKey(2*arr[i]) || (arr[i]%2 == 0 && idxMap.ContainsKey(arr[i]/2)))
                {
                    return true;
                }

                idxMap[arr[i]] = i;
            }

            return false;
        }

        /// <summary>
        /// 941. Valid Mountain Array
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static bool ValidMountainArray(int[] arr)
        {
            if (arr.Length < 3)
            {
                return false;
            }

            int k = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                k = i;

                if (arr[i] == arr[i+1])
                {
                    return false;
                }

                if (arr[i] > arr[i+1])
                {
                    if (i == 0)
                    {
                        return false;
                    }
                    break;
                }
            }

            for (int j = arr.Length - 1; j > k; j--)
            {
                if (arr[j] >= arr[j-1])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool ValidMountainArray1(int[] arr)
        {
            if (arr.Length < 3)
            {
                return false;
            }

            int i = 0;
            for (; i < arr.Length - 1; i++)
            {
                if (arr[i] == arr[i + 1])
                {
                    return false;
                }

                if (arr[i] > arr[i + 1])
                {
                    break;
                }
            }

            if (i == 0 || i == arr.Length - 1)
            {
                return false;
            }

            for (int j = i; j < arr.Length - 1; j++)
            {
                if (arr[j] <= arr[j+1])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 1299. Replace Elements with Greatest Element on Right Side
        /// Input: arr = [17,18,5,4,6,1]
        /// Output: [18,6,6,6,1,-1]
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int[] ReplaceElements(int[] arr)
        {
            var n = arr.Length;
            var max = arr[n - 1];
            arr[n - 1] = -1;
            for (int i = n - 2; i >= 0; i--)
            {
                var tmp = arr[i];
                arr[i] = max;
                if (tmp > max)
                {
                    max = tmp;
                }
            }

            return arr;
        }
        #endregion

        #region Recursion
        public static int GiaiThua(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            int tmp = n * GiaiThua(n - 1);
            return tmp;
        }

        public static int Fibonacci(int n)
        {
            if (n == 1 || n == 2)
            {
                return 1;
            }

            int tmp = Fibonacci(n - 1) + Fibonacci(n - 2);
            return tmp;
        }

        public static void PrintElement(int[] arr, int index)
        {
            if (index < 0 || index >= arr.Length)
            {
                return;
            }

            Console.WriteLine(arr[index]);

            PrintElement(arr, index + 1);

            //Console.WriteLine(arr[index]);
        }

        public class ListNode
        {
            public int val;
            public ListNode next;

            public ListNode(int _val = 0, ListNode _next = null)
            {
                val = _val;
                next = _next;
            }
        }

        /// <summary>
        /// 21. Merge Two Sorted Lists
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public static ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null)
                return l2;

            if (l2 == null)
                return l1;

            if (l1.val < l2.val)
            {
                l1.next = MergeTwoLists(l1.next, l2);
                return l1;
            }
            else
            {
                l2.next = MergeTwoLists(l1, l2.next);
                return l2;
            }
        }
        #endregion

        static void Main(string[] args)
        {
            var array = new int[] { 400 };

            ReplaceElements(array);

            PrintArray(array);
        }
    }
}
