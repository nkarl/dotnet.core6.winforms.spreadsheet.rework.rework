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
        /// <summary>
        ///     Initializes a new instance of the <see cref="ExpressionTree" /> class.
        /// </summary>
        /// <param name="expression">the arithmetic expression as input string.</param>
        public ExpressionTree(string expression = "1+2+3")
        {
            this.Expression = expression;
            this.VariableDict = new Dictionary<string, VarNode>();

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
                    /*
                     * if the node is an operator, pop two nodes from the stack,
                     * make them the left and right children of the operator,
                     * and push the operator back onto the stack.
                     */
                    /* op = CastOperator[op.Symbol].Invoke(op); */
                    op.Right = stack.Pop();
                    op.Left = stack.Pop();
                    stack.Push(op);
                }
                else
                {
                    /*
                     * if the node is an operand, push it onto the stack.
                     */
                    stack.Push(node);
                    if (node is VarNode variable)
                    {
                        this.VariableDict.Add(variable.Name, variable);
                    }
                }
            }

            this.Root = stack.Pop();
            return this.Root;
        }
    }
}