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
    class MaximumSubarraySum
    {
        static long MaximumSum(long[] a, long m)
        {
            long curr = 0;
            SortedDictionary<long, long> sDict = new SortedDictionary<long, long>();
            for (long i = 0; i < a.Length; i++)
            {
                curr = (a[i] % m + curr) % m;
                sDict[curr] = i;
            }
            var keyArr = sDict.Keys.ToArray();
            long max = keyArr.Last();
            for (long i = 0; i < sDict.Keys.Count - 1; i++)
            {
                if (sDict[keyArr[i]] > sDict[keyArr[i + 1]])
                    max = Math.Max(max, (keyArr[i] - keyArr[i + 1] + m) % m);
            }
            return max;
        }

        public static void Run()
        {
            long[] a = new long[3] { 1, 5, 9 };
            long m = 5;
            Console.WriteLine(MaximumSum(a, m));
        }
    }
}
