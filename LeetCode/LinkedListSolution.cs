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

        /// <summary>
        /// 19. Remove Nth Node From End of List
        /// </summary>
        /// <param name="head"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode prev = null;
            var s = head;
            var f = head;
            var k = n - 1;

            while (f.next != null)
            {
                if (k != 0)
                {
                    f = f.next;
                    k--;
                    continue;
                }

                f = f.next;
                prev = s;
                s = s.next;
            }

            if (prev != null)
            {
                prev.next = s.next;
            }
            else
            {
                if (s == head)
                {
                    head = head.next;
                }
                else
                {
                    head = null;
                }
            }

            return head;
        }

        /// <summary>
        /// 206. Reverse Linked List
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static ListNode ReverseList(ListNode head)
        {
            ListNode reverseHead = null;
            var blackNode = head;

            while (blackNode != null)
            {
                var prevNode = reverseHead;
                reverseHead = new ListNode(blackNode.val);
                reverseHead.next = prevNode;

                blackNode = blackNode.next;
            }

            return reverseHead;
        }

        public ListNode ReverseList1(ListNode head)
        {
            /* iterative solution */
            ListNode newHead = null;
            while (head != null)
            {
                ListNode next = head.next;
                head.next = newHead;
                newHead = head;
                head = next;
            }

            return newHead;
        }

        public ListNode ReverseList2(ListNode head)
        {
            /* recursive solution */
            return ReverseListInt(head, null);
        }

        private ListNode ReverseListInt(ListNode head, ListNode newHead)
        {
            if (head == null)
                return newHead;
            ListNode next = head.next;
            head.next = newHead;
            return ReverseListInt(next, head);
        }

        /// <summary>
        /// 203. Remove Linked List Elements
        /// Input: head = [1,2,6,6,3,4,5,6], val = 6
        /// Output: [1,2,3,4,5]
        /// </summary>
        /// <param name="head"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public static ListNode RemoveElements(ListNode head, int val)
        {
            ListNode prevNode = null;
            var curNode = head;

            while (curNode != null)
            {
                if (curNode.val == val)
                {
                    if (prevNode == null)
                    {
                        head = head.next;
                        curNode = head;
                    }
                    else
                    {
                        prevNode.next = curNode.next;
                        curNode = curNode.next;
                    }

                    continue;
                }

                prevNode = curNode;
                curNode = curNode.next;
            }

            return head;
        }

        /// <summary>
        /// 328. Odd Even Linked List
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static ListNode OddEvenList(ListNode head)
        {
            if (head == null || head.next == null || head.next.next == null)
            {
                return head;
            }

            ListNode first = head;
            ListNode second = head.next;
            ListNode next = null;

            var odd = first;
            var even = second;
            head = even.next;

            while (head != null)
            {
                if (head.next != null)
                {
                    next = head.next.next;
                }
                else
                {
                    next = head.next;
                }

                odd.next = head;
                even.next = head.next;
                odd = odd.next;
                even = even.next;

                head = next;
            }

            if (even != null)
            {
                even.next = null;
            }
            odd.next = second;

            return first;
        }

        /// <summary>
        /// 234. Palindrome Linked List
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static bool IsPalindrome(ListNode head)
        {
            var curNode = head;
            int n = 0;
            while (curNode != null)
            {
                n++;
                curNode = curNode.next;
            }

            int n1 = n / 2;
            // reverse first part list
            ListNode newHead = null;
            while (n1 > 0)
            {
                ListNode next = head.next;
                head.next = newHead;
                newHead = head;
                head = next;

                n1--;
            }

            if (n % 2 != 0 && head != null)
            {
                head = head.next;    
            }

            // compare original list to reverse list
            while (head != null && newHead != null)
            {
                if (head.val != newHead.val)
                {
                    return false;
                }

                newHead = newHead.next;
                head = head.next;
            }

            return true;
        }

        //static void Main(string[] args)
        //{
        //    // [1,2,6,6,3,4,5,6]
        //    ListNode head = new ListNode(1);
        //    var node1 = new ListNode(2);
        //    var node2 = new ListNode(3);
        //    var node3 = new ListNode(4);
        //    var node4 = new ListNode(5);
        //    //var node5 = new ListNode(6);
        //    //var node6 = new ListNode(5);
        //    //var node7 = new ListNode(6);

        //    head.next = node1;
        //    node1.next = node2;
        //    node2.next = node3;
        //    node3.next = node4;
        //    //node4.next = node5;
        //    //node5.next = node6;
        //    //node6.next = node7;

        //    var h = OddEvenList(head);
        //}
    }
}
