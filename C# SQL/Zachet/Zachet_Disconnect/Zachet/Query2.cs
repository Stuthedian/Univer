using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zachet
{
    public partial class Query2 : Form
    {
        public Query2(DataSet data)
        {
            InitializeComponent();
            dataSet = data;
        }

        private void Query2_Load(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            zapisBindingSource.DataSource = dataSet;
            dateTimePicker2.MinDate = dateTimePicker1.Value;
            refresh_grid();
        }

        private void refresh_grid()
        {
            zapisBindingSource.Filter = "data>='" + dateTimePicker1.Value.Date.ToString()
                + "' and data<='" + dateTimePicker2.Value.Date.ToString() + "'";
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Cells["Isp"].Value =
                    dataSet.Ispolnitel.FindBycod_isp((int)dataGridView1.Rows[i].Cells["codispDataGridViewTextBoxColumn"].Value)["naim"];
                dataGridView1.Rows[i].Cells["Janr"].Value =
                    dataSet.Janr.FindBycod_janr((int)dataGridView1.Rows[i].Cells["codjanrDataGridViewTextBoxColumn"].Value)["naim"];
                dataGridView1.Rows[i].Cells["Sotr"].Value =
                    dataSet.Sotrudnik.FindBycod_sotr((int)dataGridView1.Rows[i].Cells["codsotrDataGridViewTextBoxColumn"].Value)["fam"];
            }
            dataGridView1.AutoResizeColumns();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.MinDate = dateTimePicker1.Value;
            refresh_grid();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            refresh_grid();
        }
    }
}
