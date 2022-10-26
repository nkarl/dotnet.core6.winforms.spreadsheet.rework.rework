// <copyright file="Form1.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

namespace SpreadSheetApp
{
    using SpreadSheetEngine.SheetLogic;

    /// <summary>
    /// Controls the display of the data grid cells.
    /// </summary>
    public partial class Form1 : Form
    {
        /*
         * TODO: Audit the solution one more time and clean up the code before tagging for HW7 milestone.
         */
        private readonly Sheet sheet;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
            this.InitializeDataGridView();
            this.sheet = new Sheet(50, 'Z' - 'A');  // Initializes sheet dimensions.
        }

        /// <summary>
        ///     Loads the form.
        /// </summary>
        /// <param name="sender">event sender.</param>
        /// <param name="e">event.</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            this.dataGridView1.CellEndEdit += this.OnDataGridViewCellEdited !;
        }

        /// <summary>
        ///     Initializes the dimensions of the data grid.
        /// </summary>
        private void InitializeDataGridView()
        {
            // Initializes the number of columns.
            for (var c = 'A'; c <= 'Z'; ++c)
            {
                var col = new DataGridViewTextBoxColumn();
                col.HeaderText = c.ToString();
                this.dataGridView1.Columns.Add(col);
            }

            // Initializes the number of rows.
            for (var r = 1; r <= 50; ++r)
            {
                var row = new DataGridViewRow();
                row.HeaderCell.Value = r.ToString();
                this.dataGridView1.Rows.Add(row);
            }
        }

        /// <summary>
        ///     Updates the data grid with the new cell content.
        /// </summary>
        /// <param name="sender">event sender.</param>
        /// <param name="e">event.</param>
        private void OnDataGridViewCellEdited(object sender, DataGridViewCellEventArgs e)
        {
            /*
             * TODO: Audit this to test out the event handler for starting and ending CellEdit.
             */
            var currentCell = this.dataGridView1.CurrentCell;
            var sheetCell = this.sheet.GetCell(currentCell.RowIndex, currentCell.ColumnIndex);

            this.sheet.SetCell(currentCell.RowIndex, currentCell.ColumnIndex, currentCell.Value.ToString() !);
            currentCell.Value = sheetCell.Text;

            var debugCellRow = 0;
            var debugCellCol = 'A' - 'A';
            var targetCell = this.dataGridView1[debugCellRow, debugCellCol];  // the target cell for debugging input and display event.
            var currentRow = this.dataGridView1.CurrentRow;
            var currentCol = this.dataGridView1.Columns[currentCell.ColumnIndex];

            if (currentRow != null)
            {
                this.sheet.SetCell(debugCellRow, debugCellCol, $"{currentCell.Value} <- [{currentCol.HeaderText}{currentRow.HeaderCell.Value}]");
            }

            targetCell.Value = this.sheet.GetCell(debugCellRow, debugCellCol).Text;
        }
    }
}