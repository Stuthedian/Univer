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
    public partial class Zap7 : Form
    {
        public Zap7()
        {
            InitializeComponent();
        }

        private void Zap1_Load(object sender, EventArgs e)
        {
            foreach (var item in Main.produkt)
            {
                comboBox1.Items.Add(item[0]);
            }

            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            List<string[]> postavshiki_produkta = new List<string[]>();
            for (int i = 1; i < Main.produkt[comboBox1.SelectedIndex].Count; i++)
            {
                string postavshik = Main.produkt[comboBox1.SelectedIndex][i];
                int count = Main.produkt.FindAll(elem => elem.Contains(postavshik)).Count;
                postavshiki_produkta.Add(new string[] { postavshik, count.ToString() });
            }
            int max = postavshiki_produkta.Max(elem => int.Parse(elem[1]));

            foreach (var item in postavshiki_produkta.FindAll(elem => int.Parse(elem[1]) == max))
            {
                listBox1.Items.Add(item[0]);
            }

        }
    }
}
