// <copyright file="ExpressionParser_Methods.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

namespace SpreadSheetEngine.ArithmeticExpressionTree
{
    using System.Collections.Immutable;
    using System.Text;
    using SpreadSheetEngine.ArithmeticExpressionTree.Components;
    using SpreadSheetEngine.ArithmeticExpressionTree.Components.Abstract;
    using SpreadSheetEngine.ArithmeticExpressionTree.Components.Operators.EnumAttributes;

    /// <summary>
    ///     Contains methods only.
    ///     This is a static class. It takes an input expression as string and process that into a node-based
    ///     version ready to be consumed by the Expression Tree's constructor.
    /// </summary>
    internal static partial class ExpressionParser
    {
        /// <summary>
        ///     Parse expression with braces accounted for.
        /// </summary>
        /// <param name="infix">the original expression.</param>
        internal static void ParseInfixWithBraces(string infix)
        {
            // TODO: IMPLEMENT THE DECOMPOSING LOGIC FOR PARENTHESES.
            // var expression = "(A1+B2)+C3";
            var braces = "{[()]}"; // the braces should probably be put into a dict as key-value pair.

            Dictionary<char, char> localBraceDict = new()
            {
                { '{', '}' },
                { '[', ']' },
                { '(', ')' },
            };

            Dictionary<char, Func<char>> localOperatorDict = new()
            {
                { '+', () => '+' },
                { '-', () => '-' },
                { '*', () => '*' },
                { '/', () => '/' },
            };

            var operatorList = (
                from op in localOperatorDict
                select op.Key).ToArray();

            // var operatorList = opList.ToArray();

            // first, parse only operators from the expression.
            var operators = (
                from c in infix
                where operatorList.Contains(c)
                select string.Empty + c).ToArray();

            // then, parse only operands by splitting it by operators.
            var operands = infix.Split(operatorList);

            foreach (var block in operands)
            {
                if (block[0] is var openB && braces.Contains(openB))
                {
                    Console.WriteLine(openB);
                    Console.WriteLine(block[1..]);
                }
                else if (block[^1] is var closeB && braces.Contains(closeB))
                {
                    Console.WriteLine(block[..^1]);
                    Console.WriteLine(closeB);
                }
                else
                {
                    Console.WriteLine(block);
                }
            }
        }
    }
}