// <copyright file="OpNodeDiv.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

namespace SpreadSheetEngine.ArithmeticExpressionTree.Components.Operators;

using SpreadSheetEngine.ArithmeticExpressionTree.Components.Abstract;

/// <summary>
/// The Operator Node for Division.
/// </summary>
public class OpNodeDiv : OpNode
{
   static OpNodeDiv()
   {
      op = '/';
      precedence = 11;
   }
}