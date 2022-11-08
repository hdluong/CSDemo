﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LeetCode
{
    #region Queue
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

    /// <summary>
    /// 752. Open the Lock
    /// </summary>
    public class OpenTheLock
    {
        class PosTracker
        {
            private string position;
            public string Position 
            {
                get
                {
                    return position;
                }
            }

            private int moves;
            public int Moves 
            {
                get
                {
                    return moves;
                }
            }

            public PosTracker(string position, int moves)
            {
                this.position = position;
                this.moves = moves;
            }
        }

        private static List<string> GetChildren(string parent)
        {
            var result = new List<string>();

            for (int i = 0; i < parent.Length; i++)
            {
                var num = Int32.Parse(parent[i].ToString());
                var next_num = (num + 1) % 10;
                var prev_num = (num - 1 + 10) % 10;

                // ->
                result.Add(parent.Substring(0, i) + next_num + parent.Substring(i + 1));
                // <-
                result.Add(parent.Substring(0, i) + prev_num + parent.Substring(i + 1));
            }

            return result;
        }

        public static int OpenLock(string[] deadends, string target)
        {
            if (deadends.Contains("0000"))
            {
                return -1;
            }

            var queue = new Queue<PosTracker>();
            var visited = new HashSet<string>();

            queue.Enqueue(new PosTracker("0000", 0));

            foreach (var deadend in deadends)
            {
                visited.Add(deadend);
            }

            while (queue.Any())
            {
                var pt = queue.Dequeue();

                if (pt.Position.Equals(target))
                {
                    return pt.Moves;
                }

                foreach (string child in GetChildren(pt.Position))
                {
                    if (!visited.Contains(child))
                    {
                        visited.Add(child);
                        queue.Enqueue(new PosTracker(child, pt.Moves + 1));
                    }
                }
            }

            return -1;
        }
    }

    /// <summary>
    /// 279. Perfect squares
    /// </summary>
    public class PerfectSquares
    {
        class Tracker
        {
            public int Num { get; set; }

            public int Steps { get; set; }

            public Tracker(int num, int steps)
            {
                Num = num;
                Steps = steps;
            }
        }

        private static List<int> GetChildren(int n)
        {
            var result = new List<int>();
            var maxSquare = (int)Math.Sqrt(n);

            for (int i = 1; i <= maxSquare; i++)
            {
                result.Add(n - i * i);
            }

            return result;
        }

        public static int NumSquares(int n)
        {
            var queue = new Queue<Tracker>();
            var visited = new HashSet<int>();

            queue.Enqueue(new Tracker(n, 0));
            visited.Add(n);

            while (queue.Any())
            {
                var x = queue.Dequeue();

                if (x.Num == 0)
                {
                    return x.Steps;
                }

                foreach (var child in GetChildren(x.Num))
                {
                    if (!visited.Contains(child))
                    {
                        queue.Enqueue(new Tracker(child, x.Steps + 1));
                        visited.Add(child);
                    }
                }
            }

            return 0;
        }

        public static int NumSquares1(int n)
        {
            var count = 0;
            var queue = new Queue<int>();
            var visited = new HashSet<int>();

            queue.Enqueue(n);
            visited.Add(n);

            while (queue.Any())
            {
                var size = queue.Count;

                for (int i = 0; i < size; i++)
                {
                    var x = queue.Dequeue();

                    if (x == 0)
                    {
                        return count;
                    }

                    foreach (var child in GetChildren(x))
                    {
                        if (!visited.Contains(child))
                        {
                            queue.Enqueue(child);
                            visited.Add(child);
                        }
                    }
                }

                count++;
            }

            return count;
        }
    }
    #endregion

    #region Stack
    /// <summary>
    /// 155. Min Stack
    /// </summary>
    public class MinStack
    {
        class Stack
        {
            public int val { get; set; }
            public int min { get; set; }

            public Stack(int _val = 0, int _min = 0)
            {
                val = _val;
                min = _min;
            }
        }

        private List<Stack> data;


        public MinStack()
        {
            data = new List<Stack>();
        }

        public bool IsEmpty()
        {
            return data.Count == 0;
        }

        public void Push(int val)
        {
            if (IsEmpty())
            {
                data.Add(new Stack(val, val));
            }
            else
            {
                var min = Math.Min(val, GetMin());
                data.Add(new Stack(val, min));
            }
        }

        public void Pop()
        {
            if (!IsEmpty())
            {
                data.RemoveAt(data.Count - 1);
            }
        }

        public int Top()
        {
            if (IsEmpty())
            {
                return -1;
            }

            return data[data.Count - 1].val;
        }

        public int GetMin()
        {
            if (IsEmpty())
            {
                return -1;
            }

            return data[data.Count - 1].min;
        }
    }
    #endregion

    public class QueueAndStackSolution
    {
        public static void Main(string[] args)
        {
            var obj = new MinStack();
            obj.Push(-2);
            obj.Push(0);
            obj.Push(-1);

            var min = obj.GetMin();
        }
    }
}
