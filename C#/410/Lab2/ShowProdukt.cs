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
    public partial class ShowProdukt : Form
    {
        public ShowProdukt()
        {
            InitializeComponent();
        }

        private void ShowBluda_Load(object sender, EventArgs e)
        {
            foreach (var produkt in Main.produkt)
            {
                listBox2.Items.Add(produkt[0]);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = Main.produkt.FindIndex(produkt => produkt.Contains(listBox2.SelectedItem.ToString()));
            listBox3.Items.Clear();
            for (int i = 1; i < Main.produkt[idx].Count; i++)
            {
                listBox3.Items.Add(Main.produkt[idx][i]);
            }

            var a = Main.bluda.FindAll(bludo => bludo.Contains(listBox2.SelectedItem.ToString()));
            listBox1.Items.Clear();
            foreach (var item in a)
            {
                listBox1.Items.Add(item[0]);
            }
        }
    }
}
