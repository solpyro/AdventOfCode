using System;
using System.ComponentModel;

namespace AdventOfCode.Day17
{
    public static class Main
    {
        public static void Run()
        {
            var pocket = new PocketDimention3();

            pocket.Init(test);
            pocket.RunCycles(6);
            Console.WriteLine($"There are {pocket.ActiveCubes} (112) active cubes");
            //return;
            pocket.Init(data);
            pocket.RunCycles(6);
            Console.WriteLine($"There are {pocket.ActiveCubes} active cubes");


            var pocket4 = new PocketDimention4();
            pocket4.Init(test);
            pocket4.RunCycles(6);
            Console.WriteLine($"There are {pocket4.ActiveCubes} (848) active hypercubes");
            //return;
            pocket4.Init(data);
            pocket4.RunCycles(6);
            Console.WriteLine($"There are {pocket4.ActiveCubes} active hypercubes");
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