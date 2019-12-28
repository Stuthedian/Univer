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
    public partial class Form2 : Form
    {
        List<Bludo> Bludos;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("kol_vo", "kol_vo");
            dataGridView1.Columns.Add("sum_ves", "sum_ves");
            comboBox1.DataSource = Program.vid_Bludas;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            comboBox1.DisplayMember = "Name";
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Bludos = Program.vid_Bludas.Find(v => v.Name == comboBox1.Text).Bludos;
            filler();
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Bludos;
            filler();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Bludo> a = Bludos.ToList();
            a.Sort(Program.bludo_sort_kol_vo_produktov_alpha);
            dataGridView1.DataSource = a;
            filler();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<Bludo> a = Bludos.ToList();
            a.Sort(Program.bludo_sort_vyhod_ubyv_trud_alpha);
            dataGridView1.DataSource = a;
            filler();
        }

        private void filler()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells["kol_vo"].Value = Program.kol_vo_produktov
                    (Bludos.Find(b => b.Name == row.Cells["Name"].Value.ToString()));
                row.Cells["sum_ves"].Value = Program.sum_ves_produktov
                    (Bludos.Find(b => b.Name == row.Cells["Name"].Value.ToString()));
            }
        }
    }
}
