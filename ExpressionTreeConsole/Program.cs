// <copyright file="Program.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

using SpreadSheetEngine.ArithmeticExpressionTree;

string menuOption;
string currentExpression;

void DisplayMenu()
{
    Console.WriteLine(@"
EXPRESSION TREE CONSOLE MENU
----------------------------
    1. Enter an expression
    2. Set a variable
    3. Evaluate expression
    4. Quit
");
}

ExpressionTree MakeNewTree()
{
    ExpressionTree? tree = null;
    while (tree is null)
    {
        Console.Write("Enter an expression: ");
        currentExpression = Console.ReadLine() ?? string.Empty;
        tree = new ExpressionTree(currentExpression);
        if (tree.IsEmpty())
        {
            Console.WriteLine("Invalid variable name. Enter the expression again.");
            tree = null;
        }
    }

    return tree;
}

(string? Name, double Value) GetNewVar()
{
    string?[]? input = null;
    (string? Name, double Value) parsed = (string.Empty, 0);
    while (input is null)
    {
        Console.Write("Enter the variable name and its new value: ");
        input = Console.ReadLine()?.Split(' ');
        try
        {
            var parsedInput = (Name: input?[0], Value: double.Parse(input?[1] ?? string.Empty));
            parsed = (parsedInput.Name, parsedInput.Value);
        }
        catch (Exception ex) when (ex is IndexOutOfRangeException || ex is FormatException)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
            input = null;
        }
    }

    return parsed;
}

void ExecuteConsoleApp(bool appIsRunning)
{
    ExpressionTree? tree = null;

    while (appIsRunning)
    {
        Console.Write("Enter a menu option: ");
        menuOption = Console.ReadLine() ?? string.Empty;
        switch (menuOption)
        {
            case "1": // Asks user to enter an expression.
                tree = MakeNewTree();
                break;

            case "2": // Sets a variable in the expression tree.
                tree ??= new ExpressionTree();
                Console.WriteLine(tree.Expression);

                (string? Name, double Value) newVar;

                while (true)
                {
                    newVar = GetNewVar();
                    if (newVar.Name != null && tree.IsInTree(newVar.Name))
                    {
                        break;
                    }
                }

                /*
                Console.WriteLine($"{variable.Name} {variable.Value}");
                Console.WriteLine($"{variable.Name?.GetType()} {variable.Value.GetType()}");
                */

                Console.WriteLine("Setting a variable . . .");
                tree.SetVariable(newVar);
                break;

            case "3": // Evaluates the expression tree.
                /*
                 * TODO: Clean up the logic of this case.
                 */
                Console.WriteLine("Evaluating the expression . . .");
                tree ??= new ExpressionTree();
                tree.Evaluate();
                break;

            case "4": // Quits the app.
                appIsRunning = false;
                break;

            default:
                Console.WriteLine("option not implemented.");
                break;
        }
    }
}

DisplayMenu();
ExecuteConsoleApp(true);