using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LearnStuff
{
    class ReverseStringsInPlace
    {
        public static string ReverseWords(string s)
        {
            List<char> sList = s.ToCharArray().ToList();
            sList = ReverseWords(sList, 0, sList.Count - 1);
            int wordStart = 0, wordEnd = -1;
            for (int i = 0; i < sList.Count; i++)
            {
                if (sList[i] == ' ')
                {
                    wordEnd = i - 1;
                    sList = ReverseWords(sList, wordStart, wordEnd);
                    wordStart = i + 1;
                }
            }
            sList = ReverseWords(sList, wordStart, sList.Count - 1);
            return new String(sList.ToArray());
        }
        public static List<char> ReverseWords(List<char> sList, int start, int end)
        {
            int i = start, j = end;
            while (i < j)
            {
                char temp = sList[i];
                sList[i] = sList[j];
                sList[j] = temp;
                i++;
                j--;
            }
            return sList;
        }

        public static void Run()
        {
            string s = "cake pound steal";
            Console.WriteLine(ReverseWords(s));
        }
    }
}
