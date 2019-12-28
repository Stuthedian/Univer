using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3._2
{
    public partial class Form1 : Form
    {
        Bludo bludo;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = Program.vid_Bludas;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            comboBox1.DisplayMember = "Name";
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.SelectionChanged -= DataGridView1_SelectionChanged;
            dataGridView1.DataSource = Program.vid_Bludas.Find(v => v.Name == comboBox1.Text).Bludos;
            dataGridView1.Rows[0].Selected = true;
            DataGridView1_SelectionChanged(sender, e);
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            bludo = Program.vid_Bludas.Find(v => v.Name == comboBox1.Text)
                .Bludos.Find(b => b.Name == dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            dataGridView2.DataSource = bludo.Produkts;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = bludo.Produkts;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Produkt> a = bludo.Produkts.ToList();
            a.Sort(Program.produkt_sort_alpha);
            dataGridView2.DataSource = a;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<Produkt> a = bludo.Produkts.ToList();
            a.Sort(Program.produkt_sort_ves_alpha);
            dataGridView2.DataSource = a;
        }

        private void форма2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form2().ShowDialog();
        }

        private void форма3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form3().ShowDialog();
        }
    }
}
