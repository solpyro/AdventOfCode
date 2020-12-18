using System;
using System.ComponentModel;
using System.Security;

namespace AdventOfCode.Day18
{
    public static class MathParser
    {
        public static long Parse(string expr)
        {
            expr = expr.Replace(" ", "");

            long mem;
            (expr, mem) = ConsumeVal(expr);

            while (expr.Length > 0)
            {
                Func<long,long,long> op;
                long val;

                (expr, op) = ConsumeOp(expr);
                (expr, val) = ConsumeVal(expr);
                
                mem = op(mem, val);
            }

            return mem;
        }

        private static (string,long) ConsumeVal(string expr)
        {
            if (expr[0] == '(')
            {
                var i = 1;
                var nested = 0;

                while (nested > 0 || expr[i] != ')')
                {
                    if (expr[i] == '(')
                        nested++;
                    if (expr[i] == ')')
                        nested--;
                    i++;
                }

                var newExpr = expr.Substring(1, i - 1);

                return (expr.Substring(i+1),Parse(newExpr));
            }
            else
            {
                var i = 1;
                while (i < (expr.Length - 1) && "0123456789".Contains(expr[i]))
                    i++;
                return (expr.Substring(i), long.Parse(expr.Substring(0,i)));
            }
        }

        private static (string, Func<long, long, long>) ConsumeOp(string expr)
        {
            switch (expr[0])
            {
                case '+':
                    return (expr.Substring(1), Add);
                case '*':
                    return (expr.Substring(1), Multiply);
                default:
                    throw new NotImplementedException($"No op for {expr[0]}");
            }
        }

        private static long Add(long a, long b) => a + b;
        private static long Multiply(long a, long b) => a * b;
    }
}