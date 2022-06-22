using System.Runtime.CompilerServices;

namespace SpreadSheetEngine.ArithmeticExpressionTree.Components.Operators;

using SpreadSheetEngine.ArithmeticExpressionTree.Components.Abstract;

public class Add : OpNode
{
   static Add()
   {
      _op = '+';
      _precedence = 10;
   }
}