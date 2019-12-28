using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3._2
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            listBox1.DataSource = Program.bludo_max_produkt();
            listBox1.DisplayMember = "Name";

            comboBox1.DataSource = Program.all_produkt();

            listBox3.DataSource = Program.produkt_max_bludo();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.DataSource = Program.bluda_produkta(comboBox1.Text);
            listBox2.DisplayMember = "Name";
        }
    }
}
