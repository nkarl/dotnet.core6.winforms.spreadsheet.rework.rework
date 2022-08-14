// <copyright file="OpNodeDiv.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

namespace SpreadSheetEngine.ArithmeticExpressionTree.Components.Operators
{
    using SpreadSheetEngine.ArithmeticExpressionTree.Components.Abstract;
    using SpreadSheetEngine.ArithmeticExpressionTree.Components.Operators.EnumAttributes;

    /// <summary>
    ///     The Operator Node for Division.
    /// </summary>
    public class OpNodeDiv : OpNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpNodeDiv"/> class.
        /// </summary>
        public OpNodeDiv()
        {
            this.SetAttributes('/', 11, OpAssociativity.Leftward);
        }
    }
}