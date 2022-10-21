// <copyright file="Sheet.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("SpreadSheetApp")]
[assembly: InternalsVisibleTo("SpreadSheetEngineTests")]

namespace SpreadSheetEngine.SheetLogic
{
    using System.ComponentModel;
    using System.Globalization;
    using SpreadSheetEngine.ArithmeticExpressionTree;
    using SpreadSheetEngine.SheetLogic.Components;

    /// <summary>
    ///     The data source controller for the 2D array of cells.
    /// </summary>
    internal sealed class Sheet : INotifyPropertyChanged
    {
        private readonly Cell?[,] table;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Sheet" /> class.
        ///     Lazy loading, cells are created only when they are queried for the first time.
        /// </summary>
        /// <param name="numRows">the number of rows in this sheet.</param>
        /// <param name="numColumns">the number of columns in this sheet.</param>
        public Sheet(int numRows, int numColumns)
        {
            this.table = new Cell[numRows, numColumns];
        }

        /// <inheritdoc/>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        ///     Gets the row count of the sheet.
        /// </summary>
        public int RowCount => this.table.GetLength(0);

        /// <summary>
        ///     Gets the column count of the sheet.
        /// </summary>
        public int ColumnCount => this.table.GetLength(1);

        /// <summary>
        ///     Returns the reference to the cell at the given coordinates.
        ///     Supports lazy loading; creates a new cell if one does not exist.
        /// </summary>
        /// <param name="rowIndex">the row index of the cell.</param>
        /// <param name="columnIndex">the column index of the cell.</param>
        /// <returns>the cell if found.</returns>
        internal Cell GetCell(int rowIndex, int columnIndex)
        {
            return this.table[rowIndex, columnIndex] ??= Cell.CreateInstance(rowIndex, columnIndex);
        }

        /// <summary>
        ///     Sets the content of a cell of given coordinates.
        /// </summary>
        /// <param name="rowIndex">the cell's row index.</param>
        /// <param name="columnIndex">the cell's column index.</param>
        /// <param name="input">the text content of the cell.</param>
        internal void SetCell(int rowIndex, int columnIndex, string input)
        {
            /*
             * NOTE: Here, I need need to capture the reference to CURRENT cell here.
             */
            var cell = this.GetCell(rowIndex, columnIndex);

            string newContent = (input[0] != '=')
                ? input
                : this.Evaluate(input[1..]);
            /*
             * I can modify Evaluate() to accept a string denoting the cell coordinates
             * already converted from rowIndex and columnIndex.
             */

            cell.SetContent(newContent);
            this.OnPropertyChanged();
        }

        /// <summary>
        ///     Sets the variables if the expression contains variables.
        /// </summary>
        /// <param name="tree">the current expression tree.</param>
        private void SetCellValues(ExpressionTree tree)
        {
            /*
             * Assumption: the expression tree is valid, and the coordinates are valid.
             *
             * For key in tree.variables, use key to get the cell value from the sheet.
             * The key should be transformed into a cell coordinates.
             */
            foreach (var entry in tree.VariableDict)
            {
                /*
                 * Translate key to cell coordinates:
                 *      The first character of the key is the column index.
                 *      The rest of the key is the row index.
                 */
                var columnIndex = entry.Key[0] - 'A';
                try
                {
                    int rowIndex = int.Parse(entry.Key[1..]) - 1;
                    double value = double.Parse(this.GetCell(rowIndex, columnIndex).Value);
                    var varName = entry.Key;
                    var varNode = tree.VariableDict[varName];
                    varNode.Value = value;
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        /// <summary>
        ///     Triggers the the expression evaluation.
        /// </summary>
        /// <param name="expression">the input expression.</param>
        /// <returns>the value evaluated as string.</returns>
        private string Evaluate(string expression)
        {
            var tree = new ExpressionTree(expression);
            /*
             * NOTE:
             *  - need a way to translate indices back to cell coordinates in the format
             *  of <char><integer>, such as 'A1' or 'C33'.
             *  - also need to add a current cell in the expression tree.
             * From there, I can use the coordinate to check for circular reference.
             */
            if (!tree.IsEmptyVarDict())
            {
                this.SetCellValues(tree);
            }

            var value = tree.Evaluate();
            return value.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        ///     Raises a notifying event whenever a property is changed.
        /// </summary>
        /// <param name="propertyName">the name of the caller member method.</param>
        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}