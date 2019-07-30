using System;
using System.Collections.Generic;
using System.Text;

namespace LearnStuff
{
    // Dynamic Programming
    class MaxArraySum
    {
        static int MaxSubsetSum(int[] arr)
        {
            int max;
            int[] maxArr = new int[arr.Length];

            // Initial conditions
            maxArr[0] = arr[0];
            maxArr[1] = Math.Max(maxArr[0], arr[1]);
            max = maxArr[1];

            for (int i = 2; i < arr.Length; i++)
            {
                maxArr[i] = Math.Max(arr[i], Math.Max(max, maxArr[i - 2] + arr[i]));
                if (maxArr[i] > max)
                    max = maxArr[i];
            }

            return max;
        }

        public static void Run()
        {
            //int[] arr = new int[] { 2, 1, 5, 8, 4 }; // 11
            int[] arr = new int[] { 3, 5, -7, 8, 10 }; // 15

            Console.WriteLine(MaxSubsetSum(arr));
        }
    }
}
