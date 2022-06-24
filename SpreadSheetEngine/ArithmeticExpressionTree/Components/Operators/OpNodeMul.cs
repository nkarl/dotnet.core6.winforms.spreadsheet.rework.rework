// <copyright file="OpNodeMul.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

namespace SpreadSheetEngine.ArithmeticExpressionTree.Components.Operators;

using SpreadSheetEngine.ArithmeticExpressionTree.Components.Abstract;
using SpreadSheetEngine.ArithmeticExpressionTree.Components.Operators.EnumAttributes;

/// <summary>
/// The Operator Node for Multiplication.
/// </summary>
public class OpNodeMul : OpNode
{
   static OpNodeMul()
   {
      op = '*';
      precedence = 11;
      associativity = OpAssociativity.LTR;
   }
}