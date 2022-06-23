using System.Runtime.CompilerServices;

namespace SpreadSheetEngine.ArithmeticExpressionTree.Components.Operators;

using SpreadSheetEngine.ArithmeticExpressionTree.Components.Abstract;

public class OpNodeSub : OpNode
{
   static OpNodeSub()
   {
      _op = '-';
      _precedence = 10;
   }
}