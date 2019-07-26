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
    class ReverseShuffleMerge
    {
        static string reverseShuffleMergeExample(string s)
        {
            int n = s.Length;
            char[] temp = s.ToCharArray();
            Array.Reverse(temp);
            List<char> sarr = temp.ToList();
            int[] freq = new int[26];
            for (int i = 0; i < n; i++)
            {
                freq[sarr[i] - 'a']++;
            }
            int[] did_use = new int[26];
            int[] can_use = new int[26];
            Array.Copy(freq, can_use, 26);
            List<char> A = new List<char>();

            for (int i = 0; i < n; i++)
            {
                if (did_use[sarr[i] - 'a'] < freq[sarr[i] - 'a'] / 2)
                {
                    while (A.Count > 0 && sarr[i] < A[A.Count - 1]
                        && did_use[A[A.Count - 1] - 'a'] + can_use[A[A.Count - 1] - 'a'] - 1
                        >= freq[A[A.Count - 1] - 'a'] / 2)
                    {
                        did_use[A[A.Count - 1] - 'a']--;
                        A.RemoveAt(A.Count - 1);
                    }
                    A.Add(sarr[i]);
                    did_use[sarr[i] - 'a']++;
                    can_use[sarr[i] - 'a']--;
                }
                else
                {
                    can_use[sarr[i] - 'a']--;
                }
            }
            string result = "";
            foreach (char c in A)
            {
                result += c;
            }
            return result;
        }
        static string reverseShuffleMerge(string s)
        {
            s.ToLower();
            int[] alpha = new int[26];
            int[] word = new int[26];
            int[] prev = new int[26];
            List<char> lexi = new List<char>();
            Dictionary<int, string> action = new Dictionary<int, string>();
            string result = "";
            char smallest = (char)('z'+1);
            int smallIndex = -1;
            
            for (int i = 0; i < s.Length; i++)
            {
                alpha[s[i] - 'a']++;
                action.Add(i, "none");
            }
            for (int i = 0; i < 26; i++)
            {
                if (alpha[i] > 0)
                    lexi.Add((char)(i + 'a'));
            }
            for (int i = s.Length - 1; i >= 0; i--)
            {
                int letter = s[i] - 'a';
                // Skip the letter if the max are already taken
                if ((alpha[letter] / 2) > word[letter] && action[i] != "add")
                {
                    // Choose the letter if it is the lexicographically smallest
                    if (s[i] == lexi[0])
                    {
                        word[letter]++;
                        result += s[i];
                        action[i] = "add";
                        smallest = (char)('z' + 1);
                        smallIndex = -1;
                    }
                    // This letter isn't the lexicographically smallest
                    else
                    {
                        // If this letter has already been added or passed too many times, it must be added
                        if ((alpha[letter] / 2) <= (word[letter] + prev[letter]))
                        {
                            if (s[i] < smallest)
                            {
                                word[letter]++;
                                result += s[i];
                                action[i] = "add";
                                smallest = (char)('z' + 1);
                                smallIndex = -1;
                            }
                            else
                            {
                                // Revert back to the index of the last smallest char and add it
                                for (int j = i; j <= smallIndex; j++)
                                {
                                    if (action[j] == "skip")
                                    {
                                        action[j] = "none";
                                        prev[s[j] - 'a']--;
                                    }
                                }
                                word[smallest - 'a']++;
                                result += smallest;
                                action[smallIndex] = "add";
                                i = smallIndex;
                                smallest = (char)('z'+1);
                                smallIndex = -1;
                            }
                        }
                        // Otherwise pass it up
                        else
                        {
                            action[i] = "skip";
                            prev[letter]++;
                            if (s[i] < smallest)
                            {
                                smallest = s[i];
                                smallIndex = i;
                            }
                        }
                    }
                    // If the maximum amount of the lexicographically smallest character has been selected, move on to the next smallest
                    if (word[letter] == (alpha[letter] / 2))
                    {
                        lexi.Remove(s[i]);
                    }
                }
            }

            return result;
        }

        public static void Run()
        {
            //string s = "abcdefgabcdefg"; // agfedcb
            //string s = "jjcddjggcdjd"; // cgddjj
            //string s = "aahaxxxhxhxxah"; // ahhxxxa
            //string s = "aabbccbb"; // bcba
            //string s = "djjcddjggbiigjhfghehhbgdigjicafgjcehhfgifadihiajgciagicdahcbajjbhifjiaajigdgdfhdiijjgaiejgegbbiigida"; // aaaaabccigicgjihidfiejfijgidgbhhehgfhjgiibggjddjjd
            string s = "aeiouuoiea"; // aeiou

            string result = reverseShuffleMerge(s);

            Console.WriteLine(result);
        }
    }
}
