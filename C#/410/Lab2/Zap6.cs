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
    public partial class Zap6 : Form
    {
        public Zap6()
        {
            InitializeComponent();
        }

        private void Zap1_Load(object sender, EventArgs e)
        {
            Main.bluda.Sort(sort_bluda);
            foreach (var bludo in Main.bluda)
            {
                dataGridView1.Rows.Add(bludo[0]);
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Style.BackColor = Color.Gray;

                var a = bludo[0];
                bludo.RemoveAt(0);
                bludo.Sort(sort_produkt);
                bludo.Insert(0, a);
                for (int i = 1; i < bludo.Count; i++)
                {
                    dataGridView1.Rows.Add(bludo[i]);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private int sort_bluda(List<string> s1, List<string> s2)
        {
            if(s1.Count < s2.Count || (s1.Count == s2.Count && s1[0].CompareTo(s2[0]) > 0))  
                return 1;  
            else return -1;
        }

        private int sort_produkt(string s1, string s2)
        {
            List<string> a = Main.produkt.Find(elem => elem[0] == s1);
            List<string> b = Main.produkt.Find(elem => elem[0] == s2);

            return sort_bluda(a, b);
        }
    }
}
