using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day10
{
    public static class Main
    {
        public static void Run()
        {
            var (joltage, maxJoltage, ones, twos, threes) = (0, data.Max() + 3, 0, 0, 1);

            Console.WriteLine($"Device joltage is {maxJoltage}");
            Console.WriteLine($"Adapter count is {data.Count}");

            while (joltage < maxJoltage - 3)
            {
                if (data.Contains(joltage + 1))
                {
                    ones++;
                    joltage += 1;
                }
                else if (data.Contains(joltage + 2))
                {
                    twos++;
                    joltage += 2;
                }
                else if (data.Contains(joltage + 3))
                {
                    threes++;
                    joltage += 3;
                }
            }

            Console.WriteLine($"1-jumps * 3-jumps = {ones * threes}");


            Console.WriteLine($"There are  {CountAllConfigurations(test1, maxJoltage)} (8) valid configurations ");
            Console.WriteLine($"There are  {CountAllConfigurations(test2, maxJoltage)} (19208) valid configurations ");
            Console.WriteLine($"There are  {CountAllConfigurations(data, maxJoltage)} valid configurations");
        }

        private static long CountAllConfigurations(List<int> list, int maxJoltage)
        {
            // implemented u/pseale's solution
            list.AddRange(new List<int> {0, maxJoltage});
            list.Sort((a, b) => a - b);
            var (multiplier, currentRun) = (1l, 1);
            foreach (var j in list)
            {
                if (list.Contains(j + 1))
                    currentRun++;
                else
                {
                    multiplier *= GetTribonacci(currentRun);
                    currentRun = 1;
                }
            }

            return multiplier;
        }

        private static int GetTribonacci(int n)
        {
            return tribonacci[n - 1];
        }
        private static int[] tribonacci = new int[] { 1, 1, 2, 4, 7, 13, 24, 44, 81, 149 };

        private static List<int> data = new List<int>
        {
            153,
            69,
            163,
            123,
            89,
            4,
            135,
            9,
            124,
            74,
            141,
            132,
            75,
            3,
            18,
            134,
            84,
            15,
            61,
            91,
            90,
            98,
            99,
            51,
            131,
            166,
            127,
            77,
            106,
            50,
            22,
            70,
            43,
            28,
            41,
            160,
            44,
            117,
            66,
            60,
            76,
            17,
            138,
            105,
            97,
            161,
            116,
            49,
            104,
            169,
            71,
            100,
            16,
            54,
            168,
            42,
            57,
            103,
            1,
            32,
            110,
            48,
            12,
            143,
            112,
            82,
            25,
            81,
            148,
            133,
            144,
            118,
            80,
            63,
            156,
            88,
            47,
            115,
            36,
            2,
            94,
            128,
            35,
            62,
            109,
            29,
            40,
            19,
            37,
            122,
            142,
            167,
            7,
            147,
            121,
            159,
            87,
            83,
            111,
            162,
            150,
            8,
            149
        };
        private static List<int> test1 = new List<int>
        {
            16,
            10,
            15,
            5,
            1,
            11,
            7,
            19,
            6,
            12,
            4
        };
        private static List<int> test2 = new List<int>
        {
            28,
            33,
            18,
            42,
            31,
            14,
            46,
            20,
            48,
            47,
            24,
            23,
            49,
            45,
            19,
            38,
            39,
            11,
            1,
            32,
            25,
            35,
            8,
            17,
            7,
            9,
            4,
            2,
            34,
            10,
            3
        };
    }
}