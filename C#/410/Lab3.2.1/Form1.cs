﻿using System;
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
        //Bludo bludo;
        const string vyhod = "Выход блюда — ";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            var count_vid = from n in Program.vid_Bludas select new { вид_блюда = n.Name, кол_во = n.Bludos.Count };
            dataGridView3.DataSource = count_vid.ToList();

            var count_bluda = from n1 in Program.vid_Bludas from n2 in n1.Bludos select new { блюдо = n2.Name, кол_во = n2.Produkts.Count };
            dataGridView4.DataSource = count_bluda.ToList();

            var bluda_trud_vyhod = from n1 in Program.vid_Bludas from n2 in n1.Bludos 
                             where n2.Trud > 3 && n2.Vyhod > 5
                             select new { блюдо = n2.Name, труд = n2.Trud, выход = n2.Vyhod };
            dataGridView1.DataSource = bluda_trud_vyhod.ToList();

            var all_bluda = from n1 in Program.vid_Bludas from n2 in n1.Bludos select n2;
            var bluda_pair_trud = from n1 in all_bluda
                                  join n2 in all_bluda on n1.Trud equals n2.Trud
                                  where n1.Name.CompareTo(n2.Name) == -1
                                  select new { блюдо = n1.Name, n2.Name, n1.Trud };
            dataGridView2.DataSource = bluda_pair_trud.ToList();

            comboBox1.DataSource = all_bluda.ToList();
            comboBox1.DisplayMember = "Name";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bludo bludo = (Bludo)comboBox1.SelectedItem;
            var produkty = from n in bludo.Produkts 
                           where n.Ves > (bludo.Vyhod / 4)
                           select new { n.Name, n.Ves };
            dataGridView5.DataSource = produkty.ToList();
            label6.Text = vyhod + bludo.Vyhod.ToString();
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
   
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void форма2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //new Form2().ShowDialog();
        }

        private void форма3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //new Form3().ShowDialog();
        }
    }
}
