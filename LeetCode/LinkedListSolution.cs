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

        /// <summary>
        /// 160. Intersection of Two Linked Lists
        /// </summary>
        /// <param name="headA"></param>
        /// <param name="headB"></param>
        /// <returns></returns>
        public static ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            var n1 = headA;
            var n2 = headB;

            while (n1 != n2)
            {
                n1 = n1 == null ? headB : n1.next;
                n2 = n2 == null ? headA : n2.next;
            }

            return n1;
        }

        /// <summary>
        /// [4, 1, 8, 4, 5]
        /// [5, 6, 1, 8, 4, 5]
        /// </summary>
        /// <param name="headA"></param>
        /// <param name="headB"></param>
        /// <returns></returns>
        public static ListNode GetIntersectionNode1(ListNode headA, ListNode headB)
        {
            var p1 = headA;
            var p2 = headB;
            var length1 = 0;
            var length2 = 0;

            while (p1 != null || p2 != null)
            {
                if (p1 != null)
                {
                    p1 = p1.next;
                    length1++;
                }

                if (p2 != null)
                {
                    p2 = p2.next;
                    length2++;
                }
            }

            var k = Math.Abs(length1 - length2);
            p1 = headA;
            p2 = headB;

            while (p1 != null && p2 != null)
            {
                if (k != 0)
                {
                    if (length1 > length2)
                    {
                        p1 = p1.next;
                    }
                    else if (length1 < length2)
                    {
                        p2 = p2.next;
                    }

                    k--;
                    continue;
                }

                if (p1 == p2)
                {
                    return p1;
                }

                p1 = p1.next;
                p2 = p2.next;
            }

            return null;
        }
    }
}
