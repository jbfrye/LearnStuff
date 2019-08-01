using System;
using System.Collections.Generic;
using System.Text;

namespace LearnStuff.Sorting
{
    class InsertionSort
    {
        public static void Sort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int select = arr[i], j = i - 1;
                while (j >= 0 && arr[j] > select)
                {
                    arr[j + 1] = arr[j];
                    arr[j] = select;
                    j--;
                }
            }
        }
    }
}
