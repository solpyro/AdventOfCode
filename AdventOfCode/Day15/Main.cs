using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace AdventOfCode.Day15
{
    public static class Main
    {
        public static void Run()
        {
            foreach (var t in test)
            {
                Console.WriteLine($"The 2020th term for [{string.Join(',', t.Data)}] is {CountingGame(t.Data)} ({t.Result1})");
            }
            Console.WriteLine($"The 2020th term for [{string.Join(',', data)}] is {CountingGame(data)}");


            foreach (var t in test)
            {
                Console.WriteLine($"The 2020th term for [{string.Join(',', t.Data)}] is {CountingGame(t.Data, 30000000)} ({t.Result2})");
            }
            Console.WriteLine($"The 2020th term for [{string.Join(',', data)}] is {CountingGame(data, 30000000)}");

        }

        private static int CountingGame(int[] starter, int term = 2020)
        {
            var dict = new Dictionary<int, int>();
            var (current, last) = (0, 0);

            for (var i = 1; i <= term; i++)
            {
                if (i-1 < starter.Length)
                {
                    current = starter[i-1];
                    dict.Add(current,i);
                }
                else
                {
                    if (!dict.ContainsKey(last))
                    {
                        dict.Add(last, i);
                        current = 0;
                    } else
                    {
                        current = (i-1)-dict[last];
                    }
                    dict[last] = i-1;
                }
                last = current;
            }

            return current;
        }

        private static int[] data =
        {
            8, 0, 17, 4, 1, 12
        };

        private static (int[] Data, int Result1, int Result2)[] test =
        {
            (new [] {0, 3, 6}, 436, 175594),
            (new [] {1, 3, 2}, 1, 2578),
            (new [] {2, 1, 3}, 10, 3544142),
            (new [] {1, 2, 3}, 27, 261214),
            (new [] {2, 3, 1}, 78, 6895259),
            (new [] {3, 2, 1}, 438, 18),
            (new [] {3, 1, 2}, 1836, 362)
        };
    }
}