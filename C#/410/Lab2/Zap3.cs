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
    public partial class Zap3 : Form
    {
        public Zap3()
        {
            InitializeComponent();
        }

        private void Zap1_Load(object sender, EventArgs e)
        {
            List<string> postavhsiki_bluda = new List<string>();
            foreach (var bludo in Main.bluda)
            {
                postavhsiki_bluda.Clear();
                for (int i = 1; i < bludo.Count; i++)
                {
                    var a = Main.produkt.Find(produkt => produkt[0] == bludo[i]).ToList();
                    a.RemoveAt(0);
                    postavhsiki_bluda.AddRange(a);
                }
                
                dataGridView1.Rows.Add(bludo[0], postavhsiki_bluda.Distinct().Count());
            }
        }

        
    }
}
