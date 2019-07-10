using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

namespace LearnStuff
{
    class CountingInversions
    {
        static long CountInversions(int[] arr)
        {
            int[] aux = (int[])arr.Clone();
            return CountInversions(arr, 0, arr.Length - 1, aux);
        }

        static long CountInversions(int[] arr, int lo, int hi, int[] aux)
        {
            if (lo >= hi)
                return 0;

            int mid = lo + (hi - lo) / 2;
            long count = 0;
            count += CountInversions(aux, lo, mid, arr);
            count += CountInversions(aux, mid + 1, hi, arr);
            count += Merge(arr, lo, mid, hi, aux);

            return count;
        }

        static long Merge(int[] arr, int lo, int mid, int hi, int[] aux)
        {
            long count = 0;
            int i = lo, j = mid + 1, k = lo;
            while (i <= mid || j <= hi)
            {
                if (i > mid)
                    arr[k++] = aux[j++];
                else if (j > hi)
                    arr[k++] = aux[i++];
                else if (aux[i] <= aux[j])
                    arr[k++] = aux[i++];
                else
                {
                    arr[k++] = aux[j++];
                    count += mid + 1 - i;
                }
            }

            return count;
        }

        public static void Run()
        {
            int[] arr1 = new int[] { 1, 1, 1, 2, 2 };
            int[] arr2 = new int[] { 2, 1, 3, 1, 2 };

            Console.WriteLine(CountInversions(arr1));
            Console.WriteLine(CountInversions(arr2));

            // 0
            // 4
        }
    }
}