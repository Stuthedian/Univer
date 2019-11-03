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
    public partial class Query3 : Form
    {
        public Query3(DataSet data)
        {
            InitializeComponent();
            dataSet = data;
        }

        private void Query3_Load(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            sotrudnikBindingSource.DataSource = dataSet;
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Cells["Col"].Value = dataSet.Zapis.Select("cod_sotr="
                    + dataGridView1.Rows[i].Cells["codsotrDataGridViewTextBoxColumn"].Value.ToString()
                    + " and (substring(convert(data, System.String), 4, 2)) in " 
                    + (comboBox1.SelectedIndex + 1 == 1? "('01','02','03')" :
                       comboBox1.SelectedIndex + 1 == 2 ? "('04','05','06')" :
                       comboBox1.SelectedIndex + 1 == 3 ? "('07','08','09')" : 
                       "('10','11','12')")).Count();
            }
        }
    }
}
