// <copyright file="OpNodeAdd.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

namespace SpreadSheetEngine.ArithmeticExpressionTree.Components.Operators
{
   using SpreadSheetEngine.ArithmeticExpressionTree.Components.Abstract;
   using SpreadSheetEngine.ArithmeticExpressionTree.Components.Operators.EnumAttributes;

   /// <summary>
   /// The Operator Node for Addition.
   /// </summary>
   public class OpNodeAdd : OpNode
   {
      static OpNodeAdd()
      {
         symbol = '+';
         precedence = 10;
         associativity = OpAssociativity.Leftward;
      }
   }
}