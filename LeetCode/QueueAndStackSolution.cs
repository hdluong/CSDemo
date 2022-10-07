using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    /// <summary>
    /// 622. Design Circular Queue
    /// </summary>
    public class MyCircularQueue
    {
        private int[] data;
        private int head;
        private int tail;
        private int count;

        public MyCircularQueue(int k)
        {
            data = new int[k];
            head = -1;
            tail = -1;
            count = 0;
        }

        public bool EnQueue(int value)
        {
            if (IsFull())
            {
                return false;
            }

            if (IsEmpty())
            {
                data[++tail] = value;
                head++;
            }
            else
            {
                if (tail == data.Length -1)
                {
                    tail = -1;
                }

                data[++tail] = value;
            }

            count++;
            return true;
        }

        public bool DeQueue()
        {
            if (IsEmpty())
            {
                return false;
            }

            data[head] = -1;
            if (head == data.Length - 1)
            {
                head = -1;
            }

            head++;
            count--;

            if (IsEmpty())
            {
                head = -1;
                tail = -1;
                count = 0;
            }

            return true;
        }

        public int Front()
        {
            if (IsEmpty())
            {
                return -1;
            }

            return data[head];
        }

        public int Rear()
        {
            if (IsEmpty())
            {
                return -1;
            }

            return data[tail];
        }

        public bool IsEmpty()
        {
            return count <= 0;
        }

        public bool IsFull()
        {
            return count >= data.Length;
        }
    }

    public class QueueAndStackSolution
    {
        public static void Main(string[] args)
        {
            MyCircularQueue obj = new MyCircularQueue(2);
            var param_1 = obj.EnQueue(4);
            var param_2 = obj.Rear();
            var param_3 = obj.EnQueue(9);
            var param_4 = obj.DeQueue();
            var param_5 = obj.Front();
            var param_6 = obj.DeQueue();
            var param_7 = obj.DeQueue();
            var param_8 = obj.IsEmpty();
            var param_9 = obj.DeQueue();
            var param_10 = obj.EnQueue(6);
            var param_11 = obj.EnQueue(4);
        }
    }
}
