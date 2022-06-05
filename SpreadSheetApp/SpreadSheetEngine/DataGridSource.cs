// <copyright file="DataGridSource.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

namespace SpreadSheetEngine
{
    /// <summary>
    /// The source data for DataGrid.
    /// </summary>
    public class DataGridSource
    {
        private string? text;
        private string? value;

        /// <summary>
        /// Gets or sets the text content of the cell.
        /// </summary>
        public string? Text { get => this.text; set => this.text = value; }

        /// <summary>
        /// Gets or sets the evaluated content of the cell.
        /// </summary>
        public string? Value { get => this.value; set => this.value = value; }
    }
}