using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LogViewer
{
    public partial class LogForm : Form
    {
        private static DataGridViewCellStyle defaultStyle;
        private CsvFile file;

        public LogForm(CsvFile file)
        {
            this.file = file;
            InitializeComponent();
        }

        private static DataGridViewCellStyle DefaultStyle
        {
            get
            {
                if (defaultStyle == null)
                {
                    defaultStyle = new DataGridViewCellStyle();
                    defaultStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    defaultStyle.BackColor = System.Drawing.Color.White;
                    defaultStyle.SelectionBackColor = Color.Black;
                    defaultStyle.SelectionForeColor = Color.White;
                }
                return defaultStyle;
            }
        }

        private void LogForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.grid.RowHeadersWidth = 4;
                   
                foreach (string headerName in this.file.Headers)
                {
                    DataGridViewColumn column = new DataGridViewColumn();
                    column.HeaderText = headerName;
                    column.CellTemplate = new DataGridViewTextBoxCell();
                    column.Width = 50;
                    this.grid.Columns.Add(column);
                    
                }

                foreach (ReadOnlyList<string> row in this.file.Rows)
                {
                    DataGridViewRow gridRow = new DataGridViewRow();
                    gridRow.HeaderCell.Value = row[0];
                    this.grid.Rows.Add(gridRow);
                }

                for(int rowIndex = 0; rowIndex < this.grid.Rows.Count; rowIndex++)
                {
                    for (int columnIndex = 0; columnIndex < this.grid.Columns.Count; columnIndex++)
                    {
                        string value = this.file.Rows[rowIndex][columnIndex];
                        this.grid.Rows[rowIndex].Cells[columnIndex].Value = value;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception in Load");
            }
        }

        private void LogForm_Resize(object sender, EventArgs e)
        {
            /*int columnWidth = (this.Width - (4 + (3 * this.file.Headers.Count))) / this.file.Headers.Count;
            columnWidth--;
            foreach (DataGridViewColumn column in this.grid.Columns)
            {
                column.Width = columnWidth;
            }*/
        }

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.grid.Rows[e.RowIndex].Selected = true;
        }
    }
}
