using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
    public partial class AddPostavshik : Form
    {
        ProduktEdit produktEdit;
        public AddPostavshik(ProduktEdit produktEdit)
        {
            InitializeComponent();
            this.produktEdit = produktEdit;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
                return;
            if (Main.postavshiki.Contains(textBox1.Text.Trim()))
            {
                MessageBox.Show("Такой поставщик уже есть!");
                return;
            }

            Main.postavshiki.Add(textBox1.Text.Trim());
            produktEdit.AllProduktslistBox.Items.Add(textBox1.Text.Trim());
            Close();
        }
    }
}
