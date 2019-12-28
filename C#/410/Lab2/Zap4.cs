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
    public partial class Zap4 : Form
    {
        public Zap4()
        {
            InitializeComponent();
        }

        private void Zap1_Load(object sender, EventArgs e)
        {
            foreach (var item in Main.bluda)
            {
                comboBox1.Items.Add(item[0]);
            }

            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            List<string> postavhsiki_bluda = new List<string>();
            List<string> bludo = Main.bluda.Find(elem => elem[0] == comboBox1.SelectedItem.ToString());
            for (int i = 1; i < bludo.Count; i++)
            {
                var a = Main.produkt.Find(produkt => produkt[0] == bludo[i]).ToList();
                a.RemoveAt(0);
                postavhsiki_bluda.AddRange(a);
            }

            listBox1.Items.AddRange(postavhsiki_bluda.Distinct().ToArray());

            listBox2.Items.Clear();
            postavhsiki_bluda.Clear();
            for (int i = 1; i < bludo.Count; i++)
            {
                var a = Main.produkt.Find(produkt => produkt[0] == bludo[i]).ToList();
                a.RemoveAt(0);
                if (i == 1)
                    postavhsiki_bluda.AddRange(a);
                else
                    postavhsiki_bluda = postavhsiki_bluda.Intersect(a).ToList();
            }

            listBox2.Items.AddRange(postavhsiki_bluda.ToArray());
        }
    }
}
