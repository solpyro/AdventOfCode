using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace AdventOfCode.Day18
{
    public static class AdvancedMathParser
    {
        public static long Parse(string expr)
        {
            expr = expr.Replace(" ", "");

            expr = ParseBrackets(expr);
            expr = ParseAddition(expr);

            return MathParser.Parse(expr);
        }

        private static string ParseBrackets(string expr)
        {
            while (expr.Contains('('))
            {
                var bracketsLength = 0;
                var nestCount = 0;
                for(var i=expr.IndexOf('(')+1;i<expr.Length;i++)
                {
                    if (expr[i] == '(')
                    {
                        nestCount++;
                    }
                    if (expr[i] == ')')
                    {
                        if (nestCount == 0)
                        {
                            bracketsLength = i- expr.IndexOf('(') - 1;
                            break;
                        }

                        nestCount--;
                    }
                }

                var value = Parse(expr.Substring(expr.IndexOf('(')+1, bracketsLength));
                expr = expr.Substring(0, expr.IndexOf('(')) + value + expr.Substring(expr.IndexOf('(')+bracketsLength + 2);
            }

            return expr;
        }
        private static string ParseAddition(string expr)
        {
            while (AdditionRx.IsMatch(expr))
            {
                var match = AdditionRx.Match(expr);
                expr = AdditionRx.Replace(expr,
                    $"{long.Parse(match.Groups[1].Value) + long.Parse(match.Groups[2].Value)}", 1);
            }

            return expr;
        }
        private static readonly Regex AdditionRx = new Regex(@"(\d+)\+(\d+)");
    }
}