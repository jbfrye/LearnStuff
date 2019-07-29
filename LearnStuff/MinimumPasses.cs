using System;
using System.Collections.Generic;
using System.Text;

namespace LearnStuff
{
    class MinimumPasses
    {
        static long MinPasses(long m, long w, long p, long n)
        {
            long passes = 0, candy = 0, run = Int64.MaxValue, step;

            while (candy < n)
            {
                // Calculate the number of passes needed to buy more workers and machines
                step = (m > Int64.MaxValue / w) ? 0 : (p - candy) / (m * w);

                // Buy more workers and machines
                if (step <= 0)
                {
                    // Make sure that they are spread evenly for greatest output
                    long mw = candy / p;
                    if (m >= w + mw)
                        w += mw;
                    else if (w >= m + mw)
                        m += mw;
                    else
                    {
                        long total = m + w + mw;
                        m = total / 2;
                        w = total - m;
                    }
                    candy %= p;
                    step = 1;
                }
                // Increase the total number of passes taken
                passes += step;
                if (step * m > Int64.MaxValue / w)
                    candy = Int64.MaxValue;
                // Produce the candy for this pass and calculate the number of runs needed to achieve the goal with this production
                else
                {
                    candy += step * m * w;
                    run = Math.Min(run, (long)(passes + Math.Ceiling((n - candy) / (m * w * 1.0))));
                }
            }

            return Math.Min(passes, run);
        }

        public static void Run()
        {
            //long m = 3, w = 1, p = 2, n = 12; // 3
            //long m = 1, w = 1, p = 6, n = 45; // 16
            long m = 38, w = 25, p = 22, n = 21; // 1

            Console.WriteLine(MinPasses(m, w, p, n));
        }
    }
}
