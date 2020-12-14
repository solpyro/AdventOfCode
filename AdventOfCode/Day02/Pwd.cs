using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day02
{
    public class Pwd
    {
        private static Regex MinMatch = new Regex(@"^([0-9]+)-");
        private static Regex MaxMatch = new Regex(@"-([0-9]+)\s");
        public string Rule { get; set; }
        public string Wrd { get; set; }

        private char Char => Rule.Last();
        private int Min => short.Parse(MinMatch.Match(Rule).Groups[1].Value);
        private int Max => short.Parse(MaxMatch.Match(Rule).Groups[1].Value);

        private int Count => Wrd.Count(x => x == Char);
        public bool IsValid_v1 => (Count >= Min) && (Count <= Max);
        public bool IsValid_v2 => (Wrd[Min-1]==Char)^(Wrd[Max-1] == Char);
    }
}