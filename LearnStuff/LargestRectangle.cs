using System;
using System.Collections.Generic;
using System.Text;

namespace LearnStuff
{
    class LargestRectangle
    {
        static long FindLargestRectangle(int[] h)
        {
            Stack<int> testing = new Stack<int>();
            int i = 0, area = 0, maxArea = -1, top;

            for (; i < h.Length; i++)
            {
                if (testing.Count == 0)
                    testing.Push(i);
                else
                {
                    // Current number is greater than stack
                    if (h[i] >= h[testing.Peek()])
                        testing.Push(i);
                    else if (h[i] < h[testing.Peek()])
                    {
                        while (testing.Count > 0 && h[i] < h[testing.Peek()])
                        {
                            top = testing.Pop();
                            if (testing.Count == 0)
                                area = h[top] * i;
                            else
                                area = h[top] * (i - testing.Peek() - 1);
                            maxArea = Math.Max(maxArea, area);
                        }
                        testing.Push(i);
                    }
                }
            }

            while (testing.Count > 0)
            {
                top = testing.Pop();
                if (testing.Count == 0)
                    area = h[top] * i;
                else
                    area = h[top] * (i - testing.Peek() - 1);
                maxArea = Math.Max(maxArea, area);
            }
            return maxArea;
        }

        public static void Run()
        {
            int[] h = new int[] { 1, 2, 3, 4, 5 }; // 9
            int[] j = new int[] { 1, 3, 5, 9, 11 }; // 18
            int[] k = new int[] { 11, 11, 10, 10, 10 }; // 50

            Console.WriteLine(FindLargestRectangle(h));
            Console.WriteLine(FindLargestRectangle(j));
            Console.WriteLine(FindLargestRectangle(k));
        }
    }
}
