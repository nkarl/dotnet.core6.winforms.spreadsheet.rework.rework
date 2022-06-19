// <copyright file="Form1.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

namespace SpreadSheetApp
{
    using SpreadSheetApp.Specification;
    using SpreadSheetEngine.SheetLogic;

    /// <summary>
    /// Controls the display of the data grid cells.
    /// </summary>
    public partial class Form1 : Form
    {
        private Sheet sheet;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
            this.InitializeDataGridView();
            this.sheet = new Sheet(GridDimensions.MaxRows, GridDimensions.MaxColumns);  // Initializes sheet dimensions.
            this.dataGridView1.CellEndEdit += new DataGridViewCellEventHandler(this.OnDataGridViewCellEdited !);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Initializes the dimensions of the data grid.
        /// </summary>
        private void InitializeDataGridView()
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

        private void OnDataGridViewCellEdited(object sender, DataGridViewCellEventArgs e)
        {
            var currentCell = this.dataGridView1.CurrentCell;
            var sheetCell = this.sheet.GetCell(currentCell.RowIndex, currentCell.ColumnIndex);

            this.sheet.SetCell(currentCell.RowIndex, currentCell.ColumnIndex, currentCell.Value.ToString() !);
            currentCell.Value = sheetCell.Text;

            var targetCell = this.dataGridView1[0, 0];
            targetCell.Value = $"{currentCell.Value} <- [{this.dataGridView1.CurrentRow.HeaderCell.Value},{this.dataGridView1.Columns[currentCell.ColumnIndex].HeaderText}]";
        }
    }
}