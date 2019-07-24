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

class Solution
{

    // Complete the reverseShuffleMerge function below.
    static string reverseShuffleMerge(string s)
    {
        s.ToLower();
        int[] alpha = new int[26];
        int[] a = new int[26];
        int[] traverse = new int[26];
        List<char> lexi = new List<char>();
        string result = "";
        for (int i = 0; i < s.Length; i++)
        {
            alpha[s[i] - 97]++;
            traverse[s[i] - 97]++;
        }
        for (int i = 0; i < 26; i++)
        {
            if (alpha[i] > 0)
                lexi.Add((char)(i + 97));
        }
        for (int i = s.Length - 1; i >= 0; i--)
        {
            int letter = s[i] - 97;
            if ((alpha[letter] / 2) > a[letter])
            {
                if (s[i] == lexi[0])
                {
                    a[letter]++;
                    result += s[i];
                }
                else
                {
                    if (traverse[letter] <= (alpha[letter] / 2) && traverse[letter] >= a[letter])
                    {
                        a[letter]++;
                        result += s[i];
                    }
                }
                if (a[letter] == (alpha[letter] / 2))
                    lexi.Remove(s[i]);
            }
            traverse[letter]--;
        }
        return result;
    }

    static void Main(string[] args)
    {
        string s = "abcdefgabcdefg";

        string result = reverseShuffleMerge(s);

        Console.WriteLine(result);
        Console.Read();
    }
}
