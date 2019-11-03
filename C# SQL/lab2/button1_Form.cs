using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2_Pansionat
{
    public partial class button1_Form : Form
    {
        public button1_Form()
        {
            InitializeComponent();
        }

        private void button1_Form_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.DataTable1". При необходимости она может быть перемещена или удалена.
            this.dataTable1TableAdapter.Fill(this.dataSet1.DataTable1);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.postavshiki". При необходимости она может быть перемещена или удалена.
            this.postavshikiTableAdapter.Fill(this.dataSet1.postavshiki);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.gorod". При необходимости она может быть перемещена или удалена.
            this.gorodTableAdapter.Fill(this.dataSet1.gorod);

            label1.Text += new DataSet1TableAdapters.QueriesTableAdapter().ScalarQuery();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }

        private void postavshikiBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
