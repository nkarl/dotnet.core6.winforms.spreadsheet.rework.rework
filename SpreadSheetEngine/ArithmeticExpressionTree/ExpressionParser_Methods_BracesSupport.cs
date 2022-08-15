// <copyright file="ExpressionParser_Methods_BracesSupport.cs" company="Charles Nguyen -- 011606177">
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
        internal static IEnumerable<string> FromInfixToBlocksWithBraces(string infix)
        {
            /*
             * From an expression string, iterate through each character and try to build up
             * blocks of operands and operators. The block resets at either the next operator
             * or the end of expression.
             */
            var blockExpression = new List<string>();
            var block = new StringBuilder();
            var braces = "{[()]}"; // the braces should probably be put into a dict as key-value pair.

            // Handles the case where the first block is a negative number.
            if (OperatorDict.ContainsKey(infix[0]))
            {
                block.Append(infix[0]);
                infix = infix[1..];
            }

            foreach (char c in infix)
            {
                if (OperatorDict.ContainsKey(c) || braces.Contains(c))
                {
                    if (block.ToString() != string.Empty)
                    {
                        // adds as new operand only if block is not empty string.
                        blockExpression.Add(block.ToString());
                    }

                    blockExpression.Add(c.ToString()); // adds operator to the list.
                    block = new StringBuilder(); // resets the block.
                }
                else
                {
                    block.Append(c); // otherwise, continue appending the character to the block.
                }
            }

            blockExpression.Add(block.ToString()); // adds the final block.
            return blockExpression;
        }

        internal static void ParseInfixWithBraces_Zero(string infix = "(A1+B2)+C3")
        {
            /*
             * TODO:
             *  - Write tests for the braces logic.
             *  - Fix any errors if exist.
             */

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

            foreach (string block in operands)
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