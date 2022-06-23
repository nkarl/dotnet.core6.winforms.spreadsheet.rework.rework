using System.Runtime.CompilerServices;

namespace SpreadSheetEngine.ArithmeticExpressionTree.Components.Operators;

using SpreadSheetEngine.ArithmeticExpressionTree.Components.Abstract;

public class OpNodeAdd : OpNode
{
   static OpNodeAdd()
   {
      _op = '+';
      _precedence = 10;
   }
}