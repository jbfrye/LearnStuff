using System;
using System.Collections.Generic;
using System.Text;

namespace LearnStuff.Sorting
{
    class MergeSort
    {
        public static void Sort(int[] arr)
        {
            Sort(arr, 0, arr.Length - 1);
        }

        private static void Sort(int[] arr, int start, int end)
        {
            if (start == end)
                return;
            int mid = (start + end) / 2;
            Sort(arr, start, mid);
            Sort(arr, mid + 1, end);
            Merge(arr, start, mid, end);
        }

        private static void Merge(int[] arr, int start, int mid, int end)
        {
            int i = 0, j = 0, k = start, n1 = mid - start + 1, n2 = end - mid;
            int[] L = new int[n1];
            int[] R = new int[n2];
            Array.Copy(arr, start, L, 0, n1);
            Array.Copy(arr, mid+1, R, 0, n2);

            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                k++;
            }

            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }
        }
    }
}
