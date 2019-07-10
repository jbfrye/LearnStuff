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
    class FraudulentActivity
    {
        static int ActivityNotifications(int[] expenditure, int d)
        {
            if (expenditure.Length < d)
                return -1;

            int count = 0;

            int[] freq = new int[201];
            Queue<int> q = new Queue<int>();

            for (int i = 0; i < expenditure.Length; i++)
            {
                while (i < d)
                {
                    q.Enqueue(expenditure[i]);
                    freq[expenditure[i]]++;
                    i++;
                }

                double median = FindMedian(freq, d);
                if (expenditure[i] >= 2 * median)
                    count++;

                int elem = q.Dequeue();
                freq[elem]--;

                q.Enqueue(expenditure[i]);
                freq[expenditure[i]]++;
            }
            return count;
        }

        static double FindMedian(int[] data, int d)
        {
            if (d % 2 == 1)
            {
                int center = 0;
                for (int i = 0; i < data.Length; i++)
                {
                    center += data[i];

                    if (center > d / 2)
                        return i;
                }
            }
            else
            {
                int count = 0, first = -1, second = -1;
                for (int i = 0; i < data.Length; i++)
                {
                    count += data[i];

                    if (count == d / 2)
                        first = i;
                    else if (count > d / 2)
                    {
                        if (first < 0)
                            first = i;
                        second = i;
                        return ((double)first + second) / 2;
                    }
                }
            }
            return 0;
        }

        public static void Run()
        {
            int d = 5;
            int[] expenditure = new int[9] { 2, 3, 4, 2, 3, 6, 8, 4, 5 };
            int result = ActivityNotifications(expenditure, d);
            // result = 2

            Console.WriteLine(result);
        }
    }
}