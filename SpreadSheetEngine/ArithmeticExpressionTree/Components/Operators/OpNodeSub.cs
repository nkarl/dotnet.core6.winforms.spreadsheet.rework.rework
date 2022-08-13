// <copyright file="OpNodeSub.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

namespace SpreadSheetEngine.ArithmeticExpressionTree.Components.Operators
{
    using Abstract;
    using EnumAttributes;

    /// <summary>
    ///     The Operator Node for Subtraction.
    /// </summary>
    public class OpNodeSub : OpNode
    {
        public OpNodeSub()
        {
            symbol = '-';
            precedence = 10;
            associativity = OpAssociativity.Leftward;
        }
    }
}