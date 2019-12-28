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
    public partial class Zap1 : Form
    {
        public Zap1()
        {
            InitializeComponent();
        }

        private void Zap1_Load(object sender, EventArgs e)
        {
            foreach (var item in Main.produkt)
            {
                dataGridView1.Rows.Add(item[0], Main.bluda.Count(bludo => bludo.Contains(item[0])));
            }
        }

        
    }
}
