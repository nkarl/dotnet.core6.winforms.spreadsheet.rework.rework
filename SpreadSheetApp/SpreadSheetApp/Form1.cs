// <copyright file="Form1.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

namespace SpreadSheetApp
{
    using SpreadSheetApp.Form1_Properties;

    /// <summary>
    /// Controls the display of the data grid cells.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Initialize_GridDimensions();
        }

        /// <summary>
        /// Initializes the dimensions of the data grid.
        /// </summary>
        private void Initialize_GridDimensions()
        {
            foreach (var c in GridDimensions.ColumnLabels)
            {
                var col = new DataGridViewTextBoxColumn();
                col.HeaderText = c.ToString();
                this.dataGridView1.Columns.Add(col);
            }

            var maxRows = Enumerable.Range(0, GridDimensions.MaxColumns);
            foreach (var i in maxRows)
            {
                var row = new DataGridViewRow();
                row.HeaderCell.Value = (i + 1).ToString();
                this.dataGridView1.Rows.Add(row);
            }
        }
    }
}