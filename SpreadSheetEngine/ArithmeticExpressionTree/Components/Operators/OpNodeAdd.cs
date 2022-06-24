// <copyright file="OpNodeAdd.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

using SpreadSheetEngine.ArithmeticExpressionTree.Components.Operators.EnumAttributes;

namespace SpreadSheetEngine.ArithmeticExpressionTree.Components.Operators;

using SpreadSheetEngine.ArithmeticExpressionTree.Components.Abstract;

/// <summary>
/// The Operator Node for Addition.
/// </summary>
public class OpNodeAdd : OpNode
{
   static OpNodeAdd()
   {
      op = '+';
      precedence = 10;
      associativity = OpAssociativity.LTR;
   }
}