// <copyright file="Cell.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

namespace SpreadSheetEngine.SheetLogic.Components
{
    using SpreadSheetEngine.SheetLogic.Components.Abstract;

    /// <summary>
    ///     Contains the implementation of BaseCell abstract class.
    /// </summary>
    internal class Cell : BaseCell
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Cell" /> class.
        /// </summary>
        /// <param name="rowIndex">the cell's row coordinate.</param>
        /// <param name="columnIndex">the cell's column coordinate.</param>
        private Cell(int rowIndex, int columnIndex)
            : base(rowIndex, columnIndex)
        {
        }

        /// <summary>
        ///     Factory method to create a new cell.
        /// </summary>
        /// <param name="rowIndex">the cell's row index.</param>
        /// <param name="columnIndex">the cell's column index.</param>
        /// <returns>a new cell.</returns>
        public static Cell CreateInstance(int rowIndex, int columnIndex)
        {
            return new Cell(rowIndex, columnIndex);
        }

        /// <summary>
        ///     Sets the value of the cell.
        /// </summary>
        /// <param name="expression">the new expression.</param>
        internal new void SetContent(string expression)
        {
            this.SetValue(expression);
        }
    }
}