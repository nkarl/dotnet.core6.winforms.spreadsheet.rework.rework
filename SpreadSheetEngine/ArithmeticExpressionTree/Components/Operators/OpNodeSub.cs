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
        /// <summary>
        /// Initializes a new instance of the <see cref="OpNodeSub"/> class.
        /// </summary>
        public OpNodeSub()
        {
            this.SetSymbol('-');
            this.SetPrecedence(10);
            this.SetAssociativity(OpAssociativity.Leftward);
            /*
            this.symbol = '-';
            this.precedence = 10;
            this.associativity = OpAssociativity.Leftward;
        */
        }
    }
}