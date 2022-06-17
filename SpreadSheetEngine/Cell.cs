// <copyright file="Cell.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

namespace SpreadSheetEngine;

using SpreadSheetEngine.Abstract;

/// <summary>
/// Contains the implementation of BaseCell abstract class.
/// </summary>
internal partial class Sheet
{
    /// <summary>
    /// Implements the abstract base class BaseCell.
    /// </summary>
    internal class Cell : BaseCell
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Cell"/> class.
        /// </summary>
        /// <param name="rowIndex">the cell's row coordinate.</param>
        /// <param name="columnIndex">the cell's column coordinate.</param>
        public Cell(int rowIndex, int columnIndex)
            : base(rowIndex, columnIndex)
        {
        }
    }
}