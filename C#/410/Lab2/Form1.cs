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
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

            refresh_grid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
	        {
                dataGridView1.Rows.Remove(row);
                var in_list = Main.bluda.Find(elem => elem[0] == row.Cells[0].Value.ToString());
                Main.bluda.Remove(in_list);
	        } 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = Main.bluda.Count;
            new BludoEdit(true, null).ShowDialog();
            if (count != Main.bluda.Count)
            {
                refresh_grid();
                dataGridView1.ClearSelection();
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Selected = true;
                dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;
            }
        }

        private void refresh_grid()
        {
            dataGridView1.Rows.Clear();
            foreach (var bludo in Main.bluda)
            {
                string sostav = "";
                for (int i = 1; i < bludo.Count; i++)
                {
                    sostav += bludo[i] + ",";
                }
                if(sostav != "")
                    sostav = sostav.Substring(0, sostav.Length - 1);
                dataGridView1.Rows.Add(bludo[0], sostav);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Должно быть выбрано лишь одно блюдо для изменения!");
                return;
            }
            
            new BludoEdit(false, this).ShowDialog();
            refresh_grid();
        }
    }
}
