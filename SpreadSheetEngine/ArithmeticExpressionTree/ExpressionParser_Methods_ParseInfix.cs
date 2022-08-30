// <copyright file="ExpressionParser_Methods_ParseInfix.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

namespace SpreadSheetEngine.ArithmeticExpressionTree
{
    using System.Collections.Immutable;
    using System.Text;
    using SpreadSheetEngine.ArithmeticExpressionTree.Components;
    using SpreadSheetEngine.ArithmeticExpressionTree.Components.Abstract;

    /// <summary>
    ///     Contains methods only.
    ///     This is a static class. It takes an input expression as string and process that into a node-based
    ///     version ready to be consumed by the Expression Tree's constructor.
    /// </summary>
    internal static partial class ExpressionParser
    {
        /// <summary>
        ///     Parses a given string into a list of nodes.
        /// </summary>
        /// <param name="infix">the input expression to be parsed.</param>
        /// <returns>an ArrayList of Nodes.</returns>
        public static IEnumerable<Node>? ParseInfix(string infix)
        {
            var blocks = FromInfixToBlocks(infix);
            var nodes = FromBlocksToNodes(blocks);
            return nodes;
        }

        /// <summary>
        ///     Converts the string expression into a list of strings.
        /// </summary>
        /// <param name="infix">the original string expression.</param>
        /// <returns>a list of strings.</returns>
        internal static IEnumerable<string> FromInfixToBlocks(string infix)
        {
            // From an expression string, iterate through each character and try to build up blocks of operands and operators.
            //  the block resets at either the next operator or the end of expression.
            var blockExpression = new List<string>();
            var block = new StringBuilder();
            var braces = "{[()]}";

            // Handles the case where the first block is a negative number.
            if (infix[0] == '-')
            {
                /*
                 * TODO: fix this to capture the entire negative number.
                 */
                block.Append(infix[0]);
                infix = infix[1..];
            }

            foreach (var c in infix)
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

            if (block.ToString() != string.Empty)
            {
                blockExpression.Add(block.ToString()); // adds the final block.
            }

            return blockExpression;
        }

        /// <summary>
        ///     Converts block expression into node expression.
        /// </summary>
        /// <param name="blocks">expression as blocks of string.</param>
        /// <returns>expression as nodes.</returns>
        internal static IEnumerable<Node>? FromBlocksToNodes(IEnumerable<string> blocks)
        {
            /*
             * TODO: Audit this and see if it's possible to combine this with the PostFix maker.
             */
            var nodes = new List<Node>();

            foreach (var block in blocks)
            {
                Node newNode;
                if (block.Length > 1)
                {
                    if (IsValidVarName(block))
                    {
                        newNode = NodeFromStr(block);
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    newNode = NodeFromChar(block[0]);
                }

                nodes.Add(newNode);
            }

            return nodes.ToImmutableList();
        }

        /// <summary>
        ///     Factory method to create a new operator node.
        /// </summary>
        /// <param name="op">char symbol for the supported operator.</param>
        /// <returns>a new node of specialized operator.</returns>
        internal static Node OpNodeFactory(char op)
        {
            return OperatorDict.ContainsKey(op)
                ? OperatorDict[op].Invoke()
                : throw new NotImplementedException("This operator is not supported.");
        }

        /// <summary>
        ///     Creates a new node from a single char.
        /// </summary>
        /// <param name="c">a single parsed character.</param>
        /// <returns>newly created node.</returns>
        private static Node NodeFromChar(char c)
        {
            return c switch
            {
                _ when OperatorDict.ContainsKey(c) => OpNodeFactory(c),
                _ when UpperCase.Contains(c) || LowerCase.Contains(c) => new VarNode($"{c}"),
                _ when Digits.Contains(c) => new ConstNode(c - '0'),
                _ => throw new NotImplementedException(),
            };
        }

        /// <summary>
        ///     Creates a new node from a block of string.
        /// </summary>
        /// <param name="block">a parsed block of string.</param>
        /// <returns>a newly created node.</returns>
        private static Node NodeFromStr(string block)
        {
            try
            {
                var constant = double.Parse(block);
                return new ConstNode(constant);
            }
            catch (FormatException)
            {
                Console.WriteLine($"Safely caught the parsed string {block} as a variable.");
                return new VarNode(block);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new NotImplementedException("Unable to parse string into int.");
            }
        }

        /// <summary>
        ///     Checks if each block starts with a digit, if True then
        ///     check the rest of the string for any letters.
        /// </summary>
        /// <param name="varName">the variable name.</param>
        /// <returns>true or false.</returns>
        private static bool IsValidVarName(string varName)
        {
            if (Digits.Contains(varName[0]))
            {
                foreach (var c in varName[1..])
                {
                    if (UpperCase.Contains(c) || LowerCase.Contains(c))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}