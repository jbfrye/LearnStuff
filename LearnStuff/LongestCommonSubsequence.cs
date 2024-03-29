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
    class LongestCommonSubsequence
    {
        // Complete the commonChild function below.
        static int commonChild(string s1, string s2)
        {
            int[,] c = new int[s1.Length + 1, s2.Length + 1];

            for (int i = 0; i < s1.Length; i++)
            {
                for (int j = 0; j < s2.Length; j++)
                {
                    if (s1[i] == s2[j])
                        c[i + 1, j + 1] = c[i, j] + 1;
                    else
                        c[i + 1, j + 1] = Math.Max(c[i + 1, j], c[i, j + 1]);
                }
            }
            /*
            // Backtrace the table to determine the actual substring
            int a = s1.Length, b = s2.Length;
            string output = "";
            while (a > 0 && b > 0)
            {
                if (c[a, b] > c[a-1, b] && c[a, b] > c[a, b-1])
                {
                    output = s1[a-1] + output;
                    a--;
                    b--;
                }
                else if (c[a, b] == c[a-1, b])
                    a--;
                else if (c[a, b] == c[a, b-1])
                    b--;
            }
            Console.WriteLine(output);
            */
            return c[s1.Length, s2.Length];
        }

        // Slow Recursive approach
        /*static int commonChild(string s1, string s2) {
            return commonChild(0, 0, s1, s2);
        }

        static int commonChild(int i, int j, string a, string b)
        {
            if (i >= a.Length || j >= b.Length)
                return 0;
            else if (a[i] == b[j])
                return 1 + commonChild(i+1, j+1, a, b);
            else
                return Math.Max(commonChild(i+1, j, a, b), commonChild(i, j+1, a, b));
        }*/

        public static void Run()
        {
            string s1 = "XMJYAUZ";
            string s2 = "MZJAWXU";
            int result = commonChild(s1, s2);

            Console.WriteLine(result);
        }
    }
}