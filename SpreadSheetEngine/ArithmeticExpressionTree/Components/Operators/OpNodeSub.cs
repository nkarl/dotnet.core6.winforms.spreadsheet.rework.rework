// <copyright file="OpNodeSub.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

namespace SpreadSheetEngine.ArithmeticExpressionTree.Components.Operators;

using SpreadSheetEngine.ArithmeticExpressionTree.Components.Abstract;

/// <summary>
/// The Operator Node for Subtraction.
/// </summary>
public class OpNodeSub : OpNode
{
   static OpNodeSub()
   {
      op = '-';
      precedence = 10;
   }
}