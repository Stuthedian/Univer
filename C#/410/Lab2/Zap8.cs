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
    public partial class Zap8 : Form
    {
        public Zap8()
        {
            InitializeComponent();
        }

        private void Zap1_Load(object sender, EventArgs e)
        {
            foreach (var item in Main.postavshiki)
            {
                comboBox1.Items.Add(item);
            }

            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string current_postavshik = comboBox1.SelectedItem.ToString();
            List<string> postavki = postavshik_produkts(current_postavshik);
            foreach (var postavshik in Main.postavshiki)
            {
                if (postavshik == current_postavshik)
                    continue;
                if (postavki.All(produkt => postavshik_produkts(postavshik).Contains(produkt)))
                    listBox1.Items.Add(postavshik);
            }

        }

        private List<string> postavshik_produkts(string postavshik)
        {
            List<string> result = new List<string>();
            foreach (var produkt in Main.produkt)
            {
                if (produkt.Contains(postavshik))
                    result.Add(produkt[0]);
            }

            return result;
        }
    }
}
