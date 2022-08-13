// <copyright file="OpNode.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

namespace SpreadSheetEngine.ArithmeticExpressionTree.Components.Abstract
{
    using SpreadSheetEngine.ArithmeticExpressionTree.Components.Operators.EnumAttributes;

    /// <summary>
    /// The Operator Node.
    /// </summary>
    public abstract class OpNode : Node
    {
        /// <summary>
        /// The operator to be assigned.
        /// </summary>
        protected char symbol;

        /// <summary>
        /// The precedence to be assigned.
        /// </summary>
        protected int precedence;

        /// <summary>
        /// The associativity to be assigned.
        /// </summary>
        protected OpAssociativity associativity;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpNode"/> class.
        /// The Operator Node.
        /// </summary>
        protected OpNode()
        {
            this.Left = this.Right = null;
        }

        /// <summary>
        /// Gets the character denoting this operator.
        /// </summary>
        public char Symbol => symbol;

        /// <summary>
        /// Gets the precedence of this operator.
        /// </summary>
        public int Precedence => precedence;

        /// <summary>
        /// Gets the associativity of this operator. LTR=1 and RTL=-1.
        /// </summary>
        public OpAssociativity Associativity => associativity;

        /// <summary>
        /// Gets or sets the left child-node.
        /// </summary>
        public Node? Left { get; set; }

        /// <summary>
        /// Gets or sets the right child-node.
        /// </summary>
        public Node? Right { get; set; }
    }
}