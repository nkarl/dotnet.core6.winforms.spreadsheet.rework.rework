// See https://aka.ms/new-console-template for more information

using SpreadSheetEngine.ArithmeticExpressionTree;

Console.WriteLine("Hello, World!");

var exp1 = "(A1+B2)+C3";
var exp2 = "20-22+30";
var exp3 = "1.1+2+3";
var exp4 = "1.1+2.2+3.3";
var exp5 = "A1+22+C3";
/*var exp = exp5;
// ExpressionParser.ParseInfixWithBraces(exp1);
var tree = new ExpressionTree(exp);
tree.Show();
tree.ShowVarDict();
var result = tree.Evaluate();
Console.WriteLine($"result = {result}");*/

var output = ExpressionParser.FromInfixToBlocksWithBraces(exp1).ToArray();

Console.WriteLine($"var output: {output.GetType().Name}, count={output.Count()}");
for (int i = 0; i < output.Count(); ++i)
{
    string b = output[i];
    Console.WriteLine($"output[{i}]: \"{b}\", type={b.GetType().Name}, isEmptyStr={b==string.Empty}");
}