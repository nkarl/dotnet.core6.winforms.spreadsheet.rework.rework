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

(string? Name, double Value) GetVarNameAndValue()
{
    string?[]? input = null;
    (string? Name, double Value) parsed = (string.Empty, 0);
    while (input is null)
    {
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
    ExpressionTree? tree = null; // initialize the first tree on app start up.

    while (appIsRunning)
    {
        DisplayMenu();
        Console.Write("Enter a menu option: ");
        menuOption = Console.ReadLine() ?? string.Empty;
        switch (menuOption)
        {
            // Asks user to enter an expression.
            case "1":
                tree = MakeNewTree();
                break;

            // Sets a variable in the expression tree.
            case "2":
                tree ??= new ExpressionTree();
                Console.WriteLine(tree.Expression);

                (string? Name, double Value) var;

                while (true)
                {
                    Console.Write("Enter the variable name and its new value: ");
                    var = GetVarNameAndValue();
                    if (var.Name != null && tree.HasVariable(var.Name))
                    {
                        break;
                    }

                    Console.WriteLine("There is no variable with that name.");
                }

                /*
                Console.WriteLine($"{variable.Name} {variable.Value}");
                Console.WriteLine($"{variable.Name?.GetType()} {variable.Value.GetType()}");
                */

                Console.WriteLine("Setting a variable . . .");
                tree.SetVariable(var);
                break;

            // Evaluates the expression tree.
            case "3":
                Console.WriteLine("Evaluating the expression . . .");
                tree ??= new ExpressionTree();
                var result = tree.Evaluate();
                Console.WriteLine($"The result of {tree.Expression} = {result}");
                break;

            // Quits the app.
            case "4":
                appIsRunning = false;
                break;

            default:
                Console.WriteLine("option not implemented.");
                break;
        }
    }
}

ExecuteConsoleApp(true);