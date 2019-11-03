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
    public partial class button3_Form : Form
    {
        public button3_Form()
        {
            InitializeComponent();
        }

        private void button3_Form_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.menubludo". При необходимости она может быть перемещена или удалена.
            this.menubludoTableAdapter.Fill(this.dataSet1.menubludo);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.vid_blud". При необходимости она может быть перемещена или удалена.
            this.vid_bludTableAdapter.Fill(this.dataSet1.vid_blud);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.trapezi". При необходимости она может быть перемещена или удалена.
            this.trapeziTableAdapter.Fill(this.dataSet1.trapezi);
            if (trapezBox.SelectedValue != null)
                fKbludab15502E78BindingSource.Filter = "t=" + trapezBox.SelectedValue;
        }

        private void trapezBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            fKbludab15502E78BindingSource.Filter = "t=" + trapezBox.SelectedValue;
        }
    }
}
