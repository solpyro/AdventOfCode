using System;
using System.Reflection;

namespace AdventOfCode.Day08
{
    internal class Instruction
    {
        public string Op { get; set; }
        public int Arg { get; set; }

        public bool Ran { get; set; }

        public (int, int) Execute(int ptr, int acc)
        {
            switch (Op)
            {
                case "nop":
                    return (++ptr, acc);
                case "acc":
                    return (++ptr, acc + Arg);
                case "jmp":
                    return (ptr + Arg, acc);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}