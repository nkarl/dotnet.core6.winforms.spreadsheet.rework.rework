using System.Runtime.CompilerServices;

namespace SpreadSheetEngine.ArithmeticExpressionTree.Components.Operators;

using SpreadSheetEngine.ArithmeticExpressionTree.Components.Abstract;

public class OpNodeMul : OpNode
{
   static OpNodeMul()
   {
      _op = '*';
      _precedence = 11;
   }
}