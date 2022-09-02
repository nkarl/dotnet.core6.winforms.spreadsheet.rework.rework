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
            this.varDict = new Dictionary<string, VarNode>();
            this.Expression = expression;
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

            // For each item in postfix, simply push to stack if it is not an operator,
            // otherwise do some magic and then push.
            foreach (var node in postfix)
            {
                if (node is OpNode op)
                {
                    // op = CastOperator[op.Symbol].Invoke(op);
                    op.Right = stack.Pop();
                    op.Left = stack.Pop();
                    stack.Push(op);
                }
                else
                {
                    stack.Push(node);
                    if (node is VarNode variable)
                    {
                        this.varDict.Add(variable.Name, variable);
                    }
                }
            }

            this.Root = stack.Pop();
            return this.Root;
        }

        /*
         * REQUIREMENTS FOR THE TREE:
         *  - Supports operators +, -, *, /
         *  - Supports:
         *      - parsing of user-entered expression.
         *      - building an expression tree out of that input.
         *
         * SPECIFICATIONS:
         *  - Each node in the tree must be one of the three types:
         *      + ConstantNode (NO CHILDREN)
         *      + VariableNode (NO CHILDREN)
         *      + BinaryOperatorNode
         *
         *  - Supports multichar values like "A2"
         *
         *  - Requirements for variables:
         *      + will start with an alphabet char,
         *      + upper or lower-case,
         *      + followed by any number of alphabet chars and decimal digits (0-9)
         *
         *  - Creating new expression clears the old expression.
         *
         *  - Has a default expression, such as "A1+B1+C1", so that the user has something to work with.
         *
         *  - If variable is not set, they can be default to 0.
         *
         */
    }
}