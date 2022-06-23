using System.Runtime.CompilerServices;

namespace SpreadSheetEngine.ArithmeticExpressionTree.Components.Operators;

using SpreadSheetEngine.ArithmeticExpressionTree.Components.Abstract;

public class OpNodeDiv : OpNode
{
   static OpNodeDiv()
   {
      _op = '/';
      _precedence = 11;
   }
}