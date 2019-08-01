using System;

namespace LearnStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            //FraudulentActivity.Run();
            //CountingInversions.Run();
            //LongestCommonSubsequence.Run();
            //ReverseShuffleMerge.Run();
            //MinimumTimeRequired.Run();
            //MaximumSubarraySum.Run();
            //MinimumPasses.Run();
            //MaxArraySum.Run();
            //ReverseStringsInPlace.Run();
            //UncommonCharacters.Run();
            //LargestRectangle.Run();

            //PracticeAlgorithms.Dijkstras.Run();

            int[] test = new int[] { 38, 27, 43, 3, 9, 82, 10 };
            WriteArray(test);
            Console.WriteLine();
            Sorting.SelectionSort.Sort(test);
            WriteArray(test);

            Console.Read();
        }

        public static void WriteArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }
    }
}
