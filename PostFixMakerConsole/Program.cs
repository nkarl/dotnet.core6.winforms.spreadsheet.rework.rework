// See https://aka.ms/new-console-template for more information

using System.Collections.Immutable;
using SpreadSheetEngine.ArithmeticExpressionTree;

Console.WriteLine("Hello, World!");

static void MakePostfix(string input)
{
    var blocks = ExpressionParser.FromStrToBlocks(input);
    var nodes = ExpressionParser.FromBlocksToNodes(blocks);
    /*
    var postfix = ExpressionParser.MakePostfix(nodes);
    var output = (
            from n in postfix 
            select n.Type).ToImmutableList();
            */

    /*
    foreach (var n in output)
    {
        Console.WriteLine(n);
    }
    */
    Console.WriteLine("DONE");
    Console.WriteLine();
}

var infix1= "11+22+33";
var expect1 = new [] { "ConstNode", "ConstNode", "OpNodeAdd", "ConstNode", "OpNodeAdd" };
MakePostfix(infix1);

var infix2 = "11-22*33";
var expect2 = new [] {"ConstNode", "ConstNode", "ConstNode", "OpNodeMul", "OpNodeSub"};
MakePostfix(infix2);