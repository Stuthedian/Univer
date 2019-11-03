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
    public partial class Query6 : Form
    {
        public Query6(DataSet data)
        {
            InitializeComponent();
            dataSet = data;
        }

        private void Query6_Load(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            sotrudnikBindingSource.DataSource = dataSet;
            int year = DateTime.Now.Year;
            string records;
            DataTable dataTable;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                var a = dataGridView1.Rows[i].Cells["codsotrDataGridViewTextBoxColumn"].Value;
                for (int j = 1; j <= 12; j++)
                {
                    records = "";
                    dataSet.Zapis.DefaultView.RowFilter = "cod_sotr=" + a
                        + " and (substring(convert(data, System.String), 4, 2))="
                        + (j < 10 ? "0" + j.ToString() : j.ToString())
                        + " and (substring(convert(data, System.String), 7, 4))=" + year;
                    dataTable = dataSet.Zapis.DefaultView.ToTable(true, "naim_zapis");
                    for (int k = 0; k < dataTable.Rows.Count; k++)
                    {
                        records += "\n" + dataTable.Rows[k][0];
                    }
                    if (records != "") 
                        dataGridView1.Rows[i].Cells["m"+j.ToString()].Value = records.Substring(1);
                }
            }
            dataGridView1.AutoResizeRows();
        }
    }
}
