// <copyright file="ExpressionTree_Construction.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

namespace SpreadSheetEngine.ArithmeticExpressionTree
{
    using SpreadSheetEngine.ArithmeticExpressionTree.Components.Abstract;
    using SpreadSheetEngine.ArithmeticExpressionTree.Components.Operators;

    /// <summary>
    ///     The Binary Tree to hold all nodes in an arithmetic expression tree.
    /// </summary>
    internal partial class ExpressionTree
    {
        /*
         * ASSUMPTIONS:
         *  - THAT: the input expression is in correct format and parser works.
         *
         * TREE STRUCTURE:
         *  - OPERATORS ARE INTERNAL NODES.
         *  - OPERANDS ARE LEAF NODES.
         *
         */

        /// <summary>
        ///     Dictionary for casting from the general OpNode to specialized operator node.
        /// </summary>
        private static readonly Dictionary<char, Func<OpNode, OpNode>> CastOperator = new ()
        {
            { '+', op => (OpNodeAdd)op },
            { '-', op => (OpNodeSub)op },
            { '*', op => (OpNodeMul)op },
            { '/', op => (OpNodeDiv)op },
        };

        private static readonly Dictionary<char, Func<double, double, double>> InvokeOperator = new ()
        {
            { '+', (a, b) => a + b },
            { '-', (a, b) => a - b },
            { '*', (a, b) => a * b },
            { '/', (a, b) => a / b },
        };

        /// <summary>
        ///     Initializes a new instance of the <see cref="ExpressionTree" /> class.
        /// </summary>
        /// <param name="expression">the arithmetic expression as input string.</param>
        public ExpressionTree(string expression = "1+2+3")
        {
            this.Expression = expression;
            var infix = ExpressionParser.ParseInfix(expression);
            if (infix is not null)
            {
                var postfix = ExpressionParser.MakePostfix(infix);
                this.Root = this.MakeTree(postfix);
            }
        }

        /// <summary>
        ///     Gets the expression of this tree.
        /// </summary>
        public string Expression { get; }

        /// <summary>
        ///     Gets or sets the root node of this tree.
        /// </summary>
        private Node? Root { get; set; }

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
                    op = CastOperator[op.Symbol].Invoke(op);
                    op.Right = stack.Pop();
                    op.Left = stack.Pop();
                    stack.Push(op);
                }
                else
                {
                    stack.Push(node);
                }
            }

            this.Root = stack.Pop();
            return this.Root;
        }
    }
}