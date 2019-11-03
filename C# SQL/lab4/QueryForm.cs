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
    public partial class QueryForm : Form
    {
        DataSet1 dataSet1;
        public QueryForm(DataSet1 data)
        {
            InitializeComponent();
            dataSet1 = data;
        }

        private void Exitbutton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Query1_Click(object sender, EventArgs e)
        {
            new Query1(dataSet1).ShowDialog();
        }

        private void Query2_Click(object sender, EventArgs e)
        {
            new Query2(dataSet1).ShowDialog();
        }

        private void Query3_Click(object sender, EventArgs e)
        {
            new Query3(dataSet1).ShowDialog();
        }

        private void Query4_Click(object sender, EventArgs e)
        {
            new Query4(dataSet1).ShowDialog();
        }
    }
}
