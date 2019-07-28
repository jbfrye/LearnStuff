using System;
using System.Collections.Generic;
using System.Text;

namespace LearnStuff
{
    class MinimumTimeRequired
    {
        static long minTime(long[] machines, long goal)
        {
            Array.Sort(machines);
            long max = machines[machines.Length - 1];
            long minDays = 0;
            long maxDays = max * goal;
            long result = -1;
            while (minDays < maxDays)
            {
                long mid = (minDays + maxDays) / 2;
                long unit = 0;
                foreach (long machine in machines)
                    unit += mid / machine;
                if (unit < goal)
                    minDays = mid + 1;
                else
                {
                    result = mid;
                    maxDays = mid;
                }
            }
            return result;
        }

        public static void Run()
        {
            long[] machines = new long[3] { 4, 5, 6 };
            long goal = 12;
            Console.WriteLine(minTime(machines, goal));
        }
    }
}
