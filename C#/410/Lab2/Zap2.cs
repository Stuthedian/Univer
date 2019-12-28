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
    public partial class Zap2 : Form
    {
        public Zap2()
        {
            InitializeComponent();
        }

        private void Zap1_Load(object sender, EventArgs e)
        {
            foreach (var item in Main.postavshiki)
            {
                dataGridView1.Rows.Add(item, Main.produkt.Count(produkt => produkt.Contains(item)));
            }
        }

        
    }
}
