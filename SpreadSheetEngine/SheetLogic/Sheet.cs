﻿// <copyright file="Sheet.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("SpreadSheetApp")]
[assembly: InternalsVisibleTo("SpreadSheetEngineTests")]

namespace SpreadSheetEngine.SheetLogic
{
    using System.ComponentModel;
    using SpreadSheetEngine.SheetLogic.Components;

    /// <summary>
    ///     The data source controller for the 2D array of cells.
    /// </summary>
    internal sealed class Sheet : INotifyPropertyChanged
    {
        /*
         * TODO: IMPLEMENT THE EVENT HANDLER LOGIC FOR COMMUNICATION BETWEEN DataGridView AND LOGIC ENGINE.
         */

        // ReSharper disable once InconsistentNaming
        private readonly Cell[,] table;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Sheet" /> class.
        /// </summary>
        /// <param name="numRows">the number of rows in this sheet.</param>
        /// <param name="numColumns">the number of columns in this sheet.</param>
        public Sheet(int numRows, int numColumns)
        {
            this.table = new Cell[numRows, numColumns];

            // Iterates and instantiates all cells in the sheet.
            for (var r = 0; r < numRows; r++)
            {
                for (var c = 0; c < numColumns; c++)
                {
                    this.table[r, c] = new Cell(r, c);

                    // this.table[r, c].PropertyChanged += this.SetCell;
                }
            }

            /*
             * Might not need to instantiate all cells at construction. I can do that for first input, as in
             * doing this whenever a cell is focused, then check if that cell is null. If it is null then
             * create a new cell and assign new text to it.
             */
        }

        /*
         * public event PropertyChangedEventHandler PropertyChanged;
         */

        /// <inheritdoc/>
        public event PropertyChangedEventHandler? PropertyChanged;

        /*
            TODO: Flesh and design a scheme for this Event Handler.
         */

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
        /// </summary>
        /// <param name="rowIndex">the row index of the cell.</param>
        /// <param name="columnIndex">the column index of the cell.</param>
        /// <returns>the cell if found.</returns>
        internal Cell GetCell(int rowIndex, int columnIndex)
        {
            return this.table[rowIndex, columnIndex] ??= new Cell(rowIndex, columnIndex);
        }

        /// <summary>
        ///     Sets the content of a cell of given coordinates.
        /// </summary>
        /// <param name="rowIndex">the cell's row index.</param>
        /// <param name="columnIndex">the cell's column index.</param>
        /// <param name="expression">the text content of the cell.</param>
        internal void SetCell(int rowIndex, int columnIndex, string expression)
        {
            var cell = this.GetCell(rowIndex, columnIndex);

            if (expression[0] == '=')
            {
                expression = this.Evaluate(expression);
            }

            cell.SetValue(expression);
            this.OnPropertyChanged();
        }

        /// <summary>
        /// Trigger the the expression evaluation.
        /// </summary>
        /// <param name="expression">the input expression.</param>
        /// <returns>the value evaluated as string.</returns>
        private string Evaluate(string expression)
        {
            /*
             * TODO:  provides implementation for content that is not cell coordinates.
             *  - Fixes the edge cases where 'A' - 'A'.
             * Supports:
             *  - Pulling the value from another cell. The remaining part after '='
             *    is name of the cell to pull value from.
             *
             */
            expression = expression[1..expression.Length];

            var col = expression[0] - 'A';
            var row = int.Parse(expression[1..expression.Length]);

            return this.table[row - 1, col].Text;
        }

        /// <summary>
        /// Sets the field of the data sheet.
        /// </summary>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <param name="propertyName"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            /*
             * TODO: audit this because I am not sure why it is here.
             */
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return false;
            }

            field = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }

        /// <summary>
        /// Should raise a notifying event whenever a property is changed.
        /// </summary>
        /// <param name="propertyName">the name of the caller member method.</param>
        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}