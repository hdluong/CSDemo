using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class LinkedListSolution
    {
        public class ListNode
        {
            public int val;
            public ListNode next;

            public ListNode(int x)
            {
                val = x;
                next = null;
            }
        }

        /// <summary>
        /// 141. Linked List Cycle
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static bool HasCycle(ListNode head)
        {
            var slow = head;
            if (slow == null || slow.next == null || slow.next.next == null)
            {
                return false;
            }

            var fast = slow.next.next;

            while (slow != null && fast != null)
            {
                if (fast.Equals(slow))
                {
                    return true;
                }

                if (fast.next == null)
                {
                    return false;
                }

                slow = slow.next;
                fast = fast.next.next;
            }

            return false;
        }

        /// <summary>
        /// 142. Linked List Cycle II
        /// ex:
        /// [3,2,0,-4]
        /// 1
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode DetectCycle(ListNode head)
        {
            if (head == null)
            {
                return null;
            }

            var slow = head;
            var fast = head;
            var isCycle = false;

            while (fast.next != null && fast.next.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;

                if (fast == slow)
                {
                    isCycle = true;
                    break;
                }
            }

            if (isCycle)
            {
                var slow2 = head;
                while (slow2 != slow)
                {
                    slow = slow.next;
                    slow2 = slow2.next;
                }

                return slow2;
            }

            return null;
        }
    }
}
