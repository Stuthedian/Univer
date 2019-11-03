using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Lab4_Postavki
{
    public partial class TableForm : Form
    {
        DataSet1 dataSet1;
        Ed edited;
        public TableForm(Ed edited, DataSet1 data)
        {
            InitializeComponent();
            dataSet1 = data;
            this.edited = edited;
        }

        private void Exitbutton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Postavshikbutton_Click(object sender, EventArgs e)
        {
           new PostavshikiForm(edited, dataSet1).ShowDialog();
        }

        private void Produktbutton_Click(object sender, EventArgs e)
        {
            new ProduktyForm(edited, dataSet1).ShowDialog();
        }

        private void Postavkibutton_Click(object sender, EventArgs e)
        {
            new PostavkiForm(edited, dataSet1).ShowDialog();
        }
    }
}
