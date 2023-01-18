using System;
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

    /// <summary>
    /// 20. Valid Parentheses
    /// </summary>
    public class ValidParentheses
    {
        public static bool IsValid(string s)
        {
            if (s.Length % 2 != 0)
            {
                return false;
            }

            var stack = new Stack<char>();

            for (int i = 0; i < s.Length; i++)
            {
                switch (s[i])
                {
                    case '(':
                        stack.Push(')');
                        break;
                    case '{':
                        stack.Push('}');
                        break;
                    case '[':
                        stack.Push(']');
                        break;
                    default:
                        if (stack.Count == 0 || stack.Pop() != s[i])
                        {
                            return false;
                        }
                        break;
                }
            }

            return stack.Count == 0;
        }
    }

    /// <summary>
    /// 739. Daily Temperatures
    /// </summary>
    public class DailyTemperatures
    {
        class Pair
        {
            public int Index { get; set; }

            public int Value { get; set; }

            public Pair(int index, int val)
            {
                this.Index = index;
                this.Value = val;
            }
        }

        // Input: temperatures = [73,74,75,71,69,72,76,73]
        // Output: [1,1,4,2,1,1,0,0]
        public static int[] DayToGetWammer(int[] temperatures)
        {
            var result = new int[temperatures.Length];
            var stack = new Stack<Pair>();

            for (var i = 0; i < temperatures.Length; i++)
            {
                while (stack.Any() && temperatures[i] > stack.Peek().Value)
                {
                    var item = stack.Pop();
                    result[item.Index] = i - item.Index;
                }

                stack.Push(new Pair(i, temperatures[i]));
            }

            return result;
        }

        public static int[] DailyTemperatures1(int[] temperatures)
        {
            var result = new int[temperatures.Length];
            var stack = new Stack<int>();

            for (var i = 0; i < temperatures.Length; i++)
            {
                while (stack.Any() && temperatures[i] > temperatures[stack.Peek()])
                {
                    var index = stack.Pop();
                    result[index] = i - index;
                }

                stack.Push(i);
            }

            return result;
        }
    }

    /// <summary>
    /// 150. Evaluate Reverse Polish Notation
    /// </summary>
    public class RPolishNotation
    {
        public int EvalRPN(string[] tokens)
        {
            int x, y;
            var stack = new Stack<int>();

            foreach (var item in tokens)
            {
                switch (item)
                {
                    case "+":
                        x = stack.Pop();
                        y = stack.Pop();
                        stack.Push(y + x);
                        break;
                    case "-":
                        x = stack.Pop();
                        y = stack.Pop();
                        stack.Push(y - x);
                        break;
                    case "*":
                        x = stack.Pop();
                        y = stack.Pop();
                        stack.Push(y * x);
                        break;
                    case "/":
                        x = stack.Pop();
                        y = stack.Pop();
                        stack.Push(y/x);
                        break;
                    default:
                        stack.Push(Int32.Parse(item));
                        break;
                }
            }

            return stack.Peek();
        }
    }

    public class DFS
    {
        private static readonly int[,] DIRECTIONS = { { -1, 0 }, { 0, 1 }, { 1, 0 }, { 0, -1 } };

        public static int NumIslands(char[,] grid)
        {
            var count = 0;
            var rows = grid.GetLength(0);
            var cols = grid.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i, j] == '1')
                    {
                        count++;
                        fillWithWater(grid, rows, cols, i, j);
                    }
                }
            }

            return count;
        }

        public static void fillWithWater(char[,] grid, int rows, int cols, int i, int j)
        {
            var stack = new Stack<int>();

            // 2D -> 1D: index = row * cols + col
            // 1D -> 2D: R = index / cols, C = index % cols
            stack.Push(i * cols + j);
            grid[i, j] = '0';

            while (stack.Any())
            {
                var index = stack.Pop();
                var row = index / cols;
                var col = index % cols;

                for (int k = 0; k < 4; k++)
                {
                    var x = row + DIRECTIONS[k, 0];
                    var y = col + DIRECTIONS[k, 1];

                    if (x >= 0 && x < rows &&
                        y >= 0 && y < cols &&
                        grid[x, y] == '1')
                    {
                        stack.Push(x * cols + y);
                        grid[x, y] = '0';
                    }
                }
            }
        }
    }

    /// <summary>
    /// 733. Flood Fill
    /// </summary>
    public class FloodFill
    {
        private static readonly int[,] DIRECTIONS = { { -1, 0 }, { 0, 1 }, { 1, 0 }, { 0, -1 } };

        public int[,] Fill(int[,] image, int sr, int sc, int color)
        {
            if (image[sr, sc] == color)
            {
                return image;
            }

            var rows = image.GetLength(0);
            var cols = image.GetLength(1);

            var stack = new Stack<int>();
            stack.Push(sr * cols + sc);
            var beforeColor = image[sr, sc];
            image[sr, sc] = color;

            while(stack.Any())
            {
                var index = stack.Pop();
                var row = index / cols;
                var col = index % cols;

                for (int i = 0; i < 4; i++)
                {
                    var x = row + DIRECTIONS[i, 0];
                    var y = col + DIRECTIONS[i, 1];

                    if (x > -1 && x < rows &&
                        y > -1 && y < cols &&
                        image[x, y] == beforeColor)
                    {
                        stack.Push(x * cols + y);
                        image[x, y] = color;
                    }
                }
            }

            return image;
        }
    }

    /// <summary>
    /// 394. Decode String
    /// </summary>
    public class DecodeString
    {
        public static string Decode(string s)
        {
            var word = new StringBuilder();
            var numStr = new StringBuilder();

            var wordStack = new Stack<string>();
            var numStack = new Stack<int>();

            foreach (var c in s)
            {
                switch (c)
                {
                    case ']':
                        var num = numStack.Pop();
                        var duplicateWord = word.ToString();
                        for (int i = 1; i < num; i++)
                        {
                            word.Append(duplicateWord);
                        }

                        word.Insert(0, wordStack.Pop());
                        break;
                    case '[':
                        numStack.Push(Int32.Parse(numStr.ToString()));
                        wordStack.Push(word.ToString());

                        numStr.Clear();
                        word.Clear();
                        break;
                    default:
                        if (Char.IsDigit(c))
                        {
                            numStr.Append(c);
                        }
                        else
                        {
                            word.Append(c);
                        }
                        break;
                }
            }

            return word.ToString();
        }
    }

    /// <summary>
    /// 494. Target Sum
    /// </summary>
    public class TargetSum
    {
        public static int FindTargetSumWays(int[] nums, int target)
        {
            int count = 0;

            CalculateSum(nums, 0, 0, target, ref count);

            return count;
        }

        public static void CalculateSum(int[] nums, int i, int sum, int target, ref int count)
        {
            if (i == nums.Length)
            {
                if (sum == target)
                {
                    count++;
                }
            }
            else
            {
                CalculateSum(nums, i + 1, sum + nums[i], target, ref count);
                CalculateSum(nums, i + 1, sum - nums[i], target, ref count);
            }
        }
    }
    #endregion

    #region Binary Tree
    /// <summary>
    /// Definition for a binary tree node
    /// </summary>
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int val= 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    /// <summary>
    /// 144. Binary Tree Preorder Traversal
    /// </summary>
    public class TreePreorderTraversal
    {
        private IList<int> answer = new List<int>();

        private void RecursionDfs(TreeNode root)
        {
            if (root == null)
            {
                return;
            }

            answer.Add(root.val);
            RecursionDfs(root.left);
            RecursionDfs(root.right);
        }

        public IList<int> PreorderTraversal(TreeNode root)
        {
            RecursionDfs(root);

            return answer;
        }

        public IList<int> IterationDfs(TreeNode root)
        {
            var orders = new List<int>();

            var stack = new Stack<TreeNode>();
            stack.Push(root);

            while (stack.Any())
            {
                var node = stack.Pop();

                if (node != null)
                {
                    orders.Add(node.val);
                    stack.Push(node.right);
                    stack.Push(node.left);
                }
            }

            return orders;
        }
    }

    /// <summary>
    /// 94. Binary Tree Inorder Traversal
    /// </summary>
    public class TreeInorderTraversal
    {
        public IList<int> Iteration(TreeNode root)
        {
            var answer = new List<int>();
            var stack = new Stack<TreeNode>();

            var curr = root;

            while (curr != null || stack.Any())
            {
                while (curr != null)
                {
                    stack.Push(curr);
                    curr = curr.left;
                }

                curr = stack.Pop();
                answer.Add(curr.val);
                curr = curr.right;
            }

            return answer;
        }

        public List<int> Recursion(TreeNode root)
        {
            var res = new List<int>();
            Helper(root, res);
            return res;
        }

        public void Helper(TreeNode root, List<int> res)
        {
            if (root != null)
            {
                Helper(root.left, res);
                res.Add(root.val);
                Helper(root.right, res);
            }
        }
    }
    #endregion

    public class QueueAndStackSolution
    {
        public static void Main(string[] args)
        {
            var node5 = new TreeNode(5, null, null);

            var node3 = new TreeNode(3, null, null);
            var node2 = new TreeNode(2, node3, null);
            var root = new TreeNode(1, node5, node2);

            var result = new TreeInorderTraversal().Recursion(root);
        }
    }
}
