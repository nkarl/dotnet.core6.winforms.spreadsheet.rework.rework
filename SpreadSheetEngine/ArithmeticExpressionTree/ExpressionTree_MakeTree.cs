// <copyright file="ExpressionTree_MakeTree.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

namespace SpreadSheetEngine.ArithmeticExpressionTree
{
    using SpreadSheetEngine.ArithmeticExpressionTree.Components;
    using SpreadSheetEngine.ArithmeticExpressionTree.Components.Abstract;

    /// <summary>
    ///     The Binary Tree to hold all nodes in an arithmetic expression tree.
    /// </summary>
    internal partial class ExpressionTree
    {
        /*
         * TODO: Add a method to set value in the variable dictionary.
         */

        /// <summary>
        ///     Initializes a new instance of the <see cref="ExpressionTree" /> class.
        /// </summary>
        /// <param name="expression">the arithmetic expression as input string.</param>
        public ExpressionTree(string expression = "1+2+3")
        {
            this.Expression = expression;
            this.VarDictionary = new Dictionary<string, VarNode>();
            /*
            this.Expression = expression;
            */
            /*
            var infix = ExpressionParser.ParseInfix(expression);
            if (infix is not null)
            {
                var postfix = ExpressionParser.MakePostfix(infix);
                this.Root = this.MakeTree(postfix);
            }
            */

            var postfix = ExpressionParser.MakePostfix(expression);
            if (postfix != null)
            {
                this.Root = this.MakeTree(postfix);
            }
        }

        /// <summary>
        ///     Checks if tree is empty.
        /// </summary>
        /// <returns>true or false.</returns>
        public bool IsEmpty()
        {
            return this.Root is null;
        }

        /// <summary>
        ///     Makes a new tree from a postfix list.
        /// </summary>
        /// <param name="postfix">the postfix.</param>
        /// <returns>the new root node of the tree.</returns>
        private Node MakeTree(IEnumerable<Node> postfix)
        {
            var stack = new Stack<Node>();

            foreach (var node in postfix)
            {
                if (node is OpNode op)
                {
                    // For each item in postfix, simply push to stack if it is not an operator,
                    // op = CastOperator[op.Symbol].Invoke(op);
                    op.Right = stack.Pop();
                    op.Left = stack.Pop();
                    stack.Push(op);
                }
                else
                {
                    // otherwise do some magic and then push.
                    stack.Push(node);
                    if (node is VarNode variable)
                    {
                        this.VarDictionary.Add(variable.Name, variable);
                    }
                }
            }

            this.Root = stack.Pop();
            return this.Root;
        }
    }
}