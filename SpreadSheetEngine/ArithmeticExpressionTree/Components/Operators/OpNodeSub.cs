// <copyright file="OpNodeSub.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

namespace SpreadSheetEngine.ArithmeticExpressionTree.Components.Operators
{
    using SpreadSheetEngine.ArithmeticExpressionTree.Components.Abstract;
    using SpreadSheetEngine.ArithmeticExpressionTree.Components.Operators.EnumAttributes;

    /// <summary>
    ///     The Operator Node for Subtraction.
    /// </summary>
    public class OpNodeSub : OpNode
    {
        private const int PrecedenceValue = 10;

        private const OpAssociativity Assoc = OpAssociativity.Leftward;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpNodeSub"/> class.
        /// </summary>
        public OpNodeSub()
        {
            this.SetAttributes('+');
            /*
            this.SetAttributes('+', 10, OpAssociativity.Leftward);
        */
        }

        /// <summary>
        ///     Gets operator precedence.
        /// </summary>
        public int Precedence => PrecedenceValue;

        /// <summary>
        ///     Gets operator associativity.
        /// </summary>
        public OpAssociativity Associativity => Assoc;
    }
}
