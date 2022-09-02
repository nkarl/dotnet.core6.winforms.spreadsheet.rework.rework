// <copyright file="Form1.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

namespace SpreadSheetApp
{
    using SpreadSheetEngine.ArithmeticExpressionTree;
    using SpreadSheetEngine.SheetLogic;

    /// <summary>
    /// Controls the display of the data grid cells.
    /// </summary>
    public partial class Form1 : Form
    {
        /*
         * TODO: Creates a method to parse the expression for cell references and set variable values for those references.
         *  - It might be a good idea to query the column index by ASCII char value.
         */
        private readonly Sheet sheet;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
            this.InitializeDataGridView();
            this.sheet = new Sheet(50, 'Z' - 'A');  // Initializes sheet dimensions.
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.dataGridView1.CellEndEdit += this.OnDataGridViewCellEdited !;
        }

        /// <summary>
        /// Initializes the dimensions of the data grid.
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

        private void SetCellValues(ExpressionTree tree)
        {
            /*
             * For key in tree.variables, use key to get the cell value from the sheet.
             * They key should be transformed into a cell coordinates.
             */
            foreach (var entry in tree.VarDictionary)
            {
                /*
                 * TODO: Translate key to cell coordinates.
                 * The first character of the key is the column index.
                 * The rest of the key is the row index.
                 * Also need to check if the expression actually contains variables. This can be done with checking the size of dictionary.
                 */
                var columnIndex = entry.Key[0] - 'A';
                var rowIndex = int.Parse(entry.Key[1..]);

                var value = double.Parse(this.sheet.GetCell(rowIndex, columnIndex).Value);
                tree.VarDictionary[entry.Key].Value = value;
            }
        }

        /// <summary>
        /// Updates the data grid with the new cell value.
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

            var targetCell = this.dataGridView1[0, 'A' - 'A'];  // the target cell for debugging input and display event.
            var currentRow = this.dataGridView1.CurrentRow;
            var currentCol = this.dataGridView1.Columns[currentCell.ColumnIndex];
            if (currentRow != null)
            {
                this.sheet.SetCell(0, 0, $"{currentCell.Value} <- [{currentCol.HeaderText}{currentRow.HeaderCell.Value}]");
            }

            targetCell.Value = this.sheet.GetCell(0, 0).Text;
        }
    }
}