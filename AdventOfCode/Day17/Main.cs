using System;
using System.ComponentModel;

namespace AdventOfCode.Day17
{
    public static class Main
    {
        public static void Run()
        {
            var pocket = new PocketDimention();

            pocket.Init(test);
            pocket.RunCycles(6);
            Console.WriteLine($"There are {pocket.ActiveCubes} (112) active cubes");
            //return;
            pocket.Init(data);
            pocket.RunCycles(6);
            Console.WriteLine($"There are {pocket.ActiveCubes} active cubes");
        }

        private static string[] test = new[]
        {
            ".#.",
            "..#",
            "###"
        };

        private static string[] data = new[]
        {
            ".#..####",
            ".#.#...#",
            "#..#.#.#",
            "###..##.",
            "..##...#",
            "..##.###",
            "#.....#.",
            "..##..##"
        };
    }
}