using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day18
{
    public static class AdvancedMathParser
    {
        public static long Parse(string expr)
        {
            var b = 0;
            if (expr == "5 + (8 * 3 + 9 + 3 * 4 * 3)")
                b = 1;
            expr = expr.Replace(" ", "");

            return ParseFactors(expr);
        }

        private static long ParseFactors(string expr)
        {
            var factors = new List<long>();

            while (expr != string.Empty)
            {
                var i = 0;
                var brackets = 0;
                while (i < expr.Length)
                {
                    if (expr[i] == '(')
                        brackets++;
                    if (expr[i] == ')')
                        brackets--;
                    if (expr[i] == '*' && brackets == 0)
                        break;
                    i++;
                }

                var factor = expr.Substring(0, i);
                expr = (i < expr.Length) ? expr.Substring(i + 1) : string.Empty;

                if (factor[0] == '(')
                    factors.Add(ParseFactors(factor.Substring(1, factor.Length - 2)));
                else
                {
                    if (long.TryParse(factor, out var f))
                        factors.Add(f);
                    else
                        factors.Add(ParseAddends(factor));
                }
            }

            return factors.Aggregate((a, b) => a * b);
        }
        private static long ParseAddends(string expr)
        {
            var addends = new List<long>();

            while (expr != string.Empty)
            {
                var i = 0;
                var brackets = 0;
                while (i < expr.Length)
                {
                    if (expr[i] == '(')
                        brackets++;
                    if (expr[i] == ')')
                        brackets--;
                    if (expr[i] == '+' && brackets == 0)
                        break;
                    i++;
                }

                var addend = expr.Substring(0, i);
                
                expr = (i<expr.Length)?expr.Substring(i+1):string.Empty;

                if (addend[0] == '(')
                    addends.Add(ParseFactors(addend.Substring(1, addend.Length - 2)));
                else
                {
                    if (long.TryParse(addend, out var a))
                        addends.Add(a);
                    else
                        addends.Add(ParseFactors(addend));
                }
            }

            return addends.Aggregate((a, b) => a + b);
        }
    }
}