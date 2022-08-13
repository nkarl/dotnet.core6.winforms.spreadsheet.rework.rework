// <copyright file="Sheet_Cell.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

namespace SpreadSheetEngine.SheetLogic
{
    /// <summary>
    ///     Contains the implementation of BaseCell abstract class.
    /// </summary>
    internal partial class Sheet
    {
        /// <summary>
        ///     Implements the abstract base class BaseCell.
        /// </summary>
        internal class Cell : BaseCell
        {
            /// <summary>
            ///     Initializes a new instance of the <see cref="Cell" /> class.
            /// </summary>
            /// <param name="rowIndex">the cell's row coordinate.</param>
            /// <param name="columnIndex">the cell's column coordinate.</param>
            internal Cell(int rowIndex, int columnIndex)
                : base(rowIndex, columnIndex)
            {
            }

            /// <summary>
            ///     Sets the value of the cell.
            /// </summary>
            /// <param name="expression">the new expression.</param>
            internal new void SetValue(string expression)
            {
                base.SetValue(expression);
            }
        }
    }
}