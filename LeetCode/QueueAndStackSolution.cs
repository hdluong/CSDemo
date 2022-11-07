using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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

    /// <summary>
    /// 200. Number of islands
    /// </summary>
    public class NumberIslands
    {
        private static readonly int[,] DIRECTIONS = { { -1, 0 }, { 0, 1 }, { 1, 0 }, { 0, -1 } };

        private static void FillWithWater(char[,] grid, int rows, int cols, int i, int j)
        {
            Queue<int> queue = new Queue<int>();

            // 2D -> 1D: index = row * cols + col
            // 1D -> 2D: R = index / cols, C = index % cols
            queue.Enqueue(i * cols + j);
            grid[i, j] = '0';

            while (queue.Any())
            {
                var index = queue.Dequeue();
                var row = index / cols;
                var col = index % cols;

                for (int k = 0; k < 4; k++)
                {
                    var x = row + DIRECTIONS[k, 0];
                    var y = col + DIRECTIONS[k, 1];

                    if (x > -1 && x < rows &&
                        y > -1 && y < cols &&
                        grid[x, y] == '1')
                    {
                        queue.Enqueue(x * cols + y);
                        grid[x, y] = '0';
                    }
                }
            }
        }

        public static int NumIslands(char[,] grid)
        {
            var rows = grid.GetLength(0);
            var cols = grid.GetLength(1);
            var numIsland = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i, j] == '1')
                    {
                        numIsland++;

                        FillWithWater(grid, rows, cols, i, j);
                    }
                }
            }

            return numIsland;
        }
    }

    public class QueueAndStackSolution
    {
        public static void Main(string[] args)
        {
            //MyCircularQueue obj = new MyCircularQueue(2);
            //var param_1 = obj.EnQueue(4);
            //var param_2 = obj.Rear();
            //var param_3 = obj.EnQueue(9);
            //var param_4 = obj.DeQueue();
            //var param_5 = obj.Front();
            //var param_6 = obj.DeQueue();
            //var param_7 = obj.DeQueue();
            //var param_8 = obj.IsEmpty();
            //var param_9 = obj.DeQueue();
            //var param_10 = obj.EnQueue(6);
            //var param_11 = obj.EnQueue(4);

            var grid = new char[,] {
                { '1', '1', '0', '0', '0' },
                { '1', '1', '0', '1', '0' },
                { '1', '1', '0', '0', '0' },
                { '0', '0', '0', '0', '0' }
            };

            Console.WriteLine($"Number of island: {NumberIslands.NumIslands(grid)}");
        }
    }
}
