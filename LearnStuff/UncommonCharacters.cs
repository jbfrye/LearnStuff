using System;
using System.Collections.Generic;
using System.Text;

namespace LearnStuff
{
    class UncommonCharacters
    {
        static string FindUncommonCharacters(string s1, string s2)
        {
            int[] s1Freq = new int[26];
            int[] s2Freq = new int[26];
            string result = "";

            for (int i = 0; i < s1.Length; i++)
                s1Freq[s1[i] - 'a']++;
            for (int i = 0; i < s2.Length; i++)
                s2Freq[s2[i] - 'a']++;

            for (int i = 0; i < 26; i++)
            {
                if (s1Freq[i] > 0 && s2Freq[i] == 0)
                    result += (char)(i + 'a');
                else if (s1Freq[i] == 0 && s2Freq[i] > 0)
                    result += (char)(i + 'a');
            }
            return result;
        }

        public static void Run()
        {
            string s1 = "characters";
            string s2 = "alphabets";
            Console.WriteLine(FindUncommonCharacters(s1, s2));
        }
    }
}
