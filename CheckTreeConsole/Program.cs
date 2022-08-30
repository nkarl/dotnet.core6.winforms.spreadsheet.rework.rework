// See https://aka.ms/new-console-template for more information

using SpreadSheetEngine.ArithmeticExpressionTree;

Console.WriteLine("Hello, World!");

var exp1 = "(A1+B2)+C3";
var exp2 = "20-22+30";
var exp3 = "1.1+2+3";
var exp4 = "1.1+2.2+3.3";
var exp5 = "A1+22+C3";
var exp6 = "A1*(B1+C1)-(D1+(E1/F1))";
var exp = exp1;
/*
// ExpressionParser.ParseInfixWithBraces(exp1);
var tree = new ExpressionTree(exp);
tree.Show();
tree.ShowVarDict();
var result = tree.Evaluate();
Console.WriteLine($"result = {result}");*/

var str = ExpressionParser.FromInfixToBlocks(exp);
var output = str.ToArray();

Console.WriteLine($"var output: {output.GetType().Name}, count={output.Count()}");
Console.WriteLine('[');
for (var i = 0; i < output.Count(); ++i)
{
    var b = output[i];
    Console.Write($"\"{b}\"");
    // Console.WriteLine($"output[{i}]: \"{b}\", type={b.GetType().Name}, isEmptyStr={b==string.Empty}");
    if (i < output.Count() - 1)
    {
        Console.WriteLine(", ");
    }
}

Console.WriteLine();
Console.WriteLine(']');

var postfix = ExpressionParser.FromBlocksToPostfixNodes(str);
var output2 = postfix.ToArray();
for (var i = 0; i < output2.Count(); ++i)
{
    var b = output2[i].Type;
    Console.Write($"\"{b}\"");
    // Console.WriteLine($"output[{i}]: \"{b}\", type={b.GetType().Name}, isEmptyStr={b==string.Empty}");
    if (i < output2.Count() - 1)
    {
        Console.WriteLine(", ");
    }
}
/*
var blockInfix = ExpressionParser.FromInfixToBlocks(exp);
var output = ExpressionParser.FromBlocksToPostfixNodes(blockInfix).ToArray();

Console.Write('[');
for (int i = 0; i < output.Count(); ++i)
{
    string b = output[i].Type;
    Console.Write($"\"{b}\", ");
    // Console.WriteLine($"output[{i}]: \"{b}\", type={b.GetType().Name}, isEmptyStr={b==string.Empty}");
}
Console.Write(']');
*/