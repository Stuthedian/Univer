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
    public partial class Form2 : Form
    {
        
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            refresh_grid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                if(Main.bluda.Any(bludo => bludo.Contains(row.Cells[0].Value.ToString())))
                {
                    MessageBox.Show("Продукт [" + row.Cells[0].Value.ToString() + "] используется в блюде!");
                    return;
                }
                dataGridView1.Rows.Remove(row);
                var in_list = Main.produkt.Find(elem => elem[0] == row.Cells[0].Value.ToString());
                Main.produkt.Remove(in_list);
            }
        }

        private void refresh_grid()
        {
            dataGridView1.Rows.Clear();
            foreach(var produkt_ in Main.produkt)
            {
                string sostav = "";
                for (int i = 1; i < produkt_.Count; i++)
                {
                    sostav += produkt_[i] + ",";
                }
                if (sostav != "")
                    sostav = sostav.Substring(0, sostav.Length - 1);
                dataGridView1.Rows.Add(produkt_[0], sostav);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Должен быть выбран лишь один продукт для изменения!");
                return;
            }
            new ProduktEdit(false, this).ShowDialog();
            refresh_grid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = Main.bluda.Count;
            new ProduktEdit(true, null).ShowDialog();
            refresh_grid();
            if (count != Main.bluda.Count)
            {
                refresh_grid();
                dataGridView1.ClearSelection();
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Selected = true;
                dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;
            }
        }
    }
}
