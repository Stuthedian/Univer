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
    public partial class ShowBluda : Form
    {
        public ShowBluda()
        {
            InitializeComponent();
        }

        private void ShowBluda_Load(object sender, EventArgs e)
        {
            foreach (var bludo in Main.bluda)
            {
                listBox1.Items.Add(bludo[0]);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = Main.bluda.FindIndex(bludo => bludo.Contains(listBox1.SelectedItem.ToString()));
            listBox2.Items.Clear();
            for (int i = 1; i < Main.bluda[idx].Count; i++)
            {
                listBox2.Items.Add(Main.bluda[idx][i]);
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = Main.produkt.FindIndex(produkt => produkt.Contains(listBox2.SelectedItem.ToString()));
            listBox3.Items.Clear();
            for (int i = 1; i < Main.produkt[idx].Count; i++)
            {
                listBox3.Items.Add(Main.produkt[idx][i]);
            }
        }
    }
}
