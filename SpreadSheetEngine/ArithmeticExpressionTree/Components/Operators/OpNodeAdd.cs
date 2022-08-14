// <copyright file="OpNodeAdd.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

namespace SpreadSheetEngine.ArithmeticExpressionTree.Components.Operators
{
    using SpreadSheetEngine.ArithmeticExpressionTree.Components.Abstract;
    using SpreadSheetEngine.ArithmeticExpressionTree.Components.Operators.EnumAttributes;

    /// <summary>
    ///     The Operator Node for Addition.
    /// </summary>
    public class OpNodeAdd : OpNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpNodeAdd"/> class.
        /// </summary>
        public OpNodeAdd()
        {
            this.SetAttributes('+', 10, OpAssociativity.Leftward);
        }
    }
}