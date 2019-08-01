using System;
using System.Collections.Generic;
using System.Text;

namespace LearnStuff.Sorting
{
    class SelectionSort
    {
        public static void Sort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int minValue = Int32.MaxValue, minIndex = -1;
                for (int j = i; j < arr.Length; j++)
                {
                    if (arr[j] < minValue)
                    {
                        minValue = arr[j];
                        minIndex = j;
                    }
                }
                int temp = arr[i];
                arr[i] = arr[minIndex];
                arr[minIndex] = temp;
            }
        }
    }
}
