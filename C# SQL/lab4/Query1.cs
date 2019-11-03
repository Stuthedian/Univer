using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4_Postavki
{
    public partial class Query1 : Form
    {
        DataSet1 dataSet1;
        BindingSource produktBindingSource = new BindingSource();
        BindingSource sostavBindingSource = new BindingSource();
        public Query1(DataSet1 data)
        {
            InitializeComponent();
            dataSet1 = data;
        }

        private void Query1_Load(object sender, EventArgs e)
        {
            produktBindingSource.DataSource = dataSet1.produkt;
            sostavBindingSource.DataSource = produktBindingSource;
            sostavBindingSource.DataMember = "produkt_sostav";

            if(!dataSet1.sostav.Columns.Contains("bludo"))
            {
                dataSet1.sostav.Columns.Add("bludo", typeof(System.String), "Parent(bluda_sostav).bludo");
            }

            comboBox1.DataSource = produktBindingSource;
            comboBox1.DisplayMember = "produkt";
            comboBox1.ValueMember = "pr";
            listBox1.DataSource = sostavBindingSource;
            listBox1.DisplayMember = "bludo";
        }
    }
}
