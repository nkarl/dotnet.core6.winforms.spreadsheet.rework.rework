// <copyright file="OpNodeMul.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

namespace SpreadSheetEngine.ArithmeticExpressionTree.Components.Operators
{
    using SpreadSheetEngine.ArithmeticExpressionTree.Components.Abstract;
    using SpreadSheetEngine.ArithmeticExpressionTree.Components.Operators.EnumAttributes;

    /// <summary>
    ///     The Operator Node for Multiplication.
    /// </summary>
    public class OpNodeMul : OpNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpNodeMul"/> class.
        /// </summary>
        public OpNodeMul()
        {
            this.SetSymbol('*');
            this.SetPrecedence(11);
            this.SetAssociativity(OpAssociativity.Leftward);
            /*
            this.symbol = '*';
            this.precedence = 11;
            this.associativity = OpAssociativity.Leftward;
        */
        }
    }
}