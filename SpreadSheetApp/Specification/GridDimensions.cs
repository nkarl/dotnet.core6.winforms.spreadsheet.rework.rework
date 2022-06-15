// <copyright file="GridDimensions.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

namespace SpreadSheetApp.Specification
{
    /// <summary>
    /// Controls the dimensions of the data grid, i.e. how many rows and columns to show.
    /// </summary>
    internal static class GridDimensions
    {
        /// <summary>
        /// The array of characters used for labeling columns.
        /// </summary>
        public static readonly char[] ColumnLabels = (
            from c in Enumerable.Range('A', 'Z' - 'A' + 1)
            select (char)c).ToArray();

        /*
        /// <summary>
        /// The maximum number of rows allowed.
        /// </summary>
        public static readonly int MaxRows = 50;
        */

        /// <summary>
        /// The maximum number of columns allowed.
        /// </summary>
        public static readonly int MaxColumns = GridDimensions.ColumnLabels.Length;
    }
}
