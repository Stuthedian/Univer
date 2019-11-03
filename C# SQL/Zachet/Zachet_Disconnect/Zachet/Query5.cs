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
    public partial class Query5 : Form
    {
        public Query5(DataSet data)
        {
            InitializeComponent();
            dataSet1 = data;
        }

        private void Query5_Load(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            DataTable dataTable;
            string janres;
            ispolnitelBindingSource.DataSource = dataSet1;
            for (int i = 0; i < dataSet1.Ispolnitel.Rows.Count; i++)
            {
                janres = "";
                dataSet1.Zapis.DefaultView.RowFilter = "cod_isp=" +
                    dataGridView1.Rows[i].Cells["codispDataGridViewTextBoxColumn"].Value;
                dataTable = dataSet1.Zapis.DefaultView.ToTable(true, "cod_janr");
                for (int j = 0; j < dataTable.Rows.Count; j++)
                {
                   janres += "\n" + dataSet1.Janr.Select("cod_janr=" + dataTable.Rows[j][0])[0][1];
                }
                if(janres != "")
                    dataGridView1.Rows[i].Cells["Janr"].Value = janres.Substring(1);
            }
            dataGridView1.AutoResizeRows();
        }
    }
}
