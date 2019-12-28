using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Lab2
{
    public partial class BludoEdit : Form
    {
        bool is_insert;
        Form1 parent;
        string old_name;
        List<string> edit_bludo;
        public BludoEdit(bool is_ins, Form1 par)
        {
            InitializeComponent();
            is_insert = is_ins;
            parent = par;
            if(!is_insert)
            {
                old_name = textBox1.Text = parent.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                edit_bludo = Main.bluda.Find(elem => elem[0] == textBox1.Text);
                for (int i = 1; i < edit_bludo.Count; i++)
                {
                    BludoProduktslistBox.Items.Add(edit_bludo[i]);
                }
            }
        }

        private void BludoEdit_Load(object sender, EventArgs e)
        {
            foreach (var produkt in Main.produkt)
            {
                if (!is_insert && edit_bludo.Contains(produkt[0]))
                    continue;
                AllProduktslistBox.Items.Add(produkt[0]);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ToSostavbutton_Click(object sender, EventArgs e)
        {
            object[] a = new object[AllProduktslistBox.SelectedItems.Count];
            AllProduktslistBox.SelectedItems.CopyTo(a, 0);
            foreach (var item in a)
            {
                BludoProduktslistBox.Items.Add(item);
                AllProduktslistBox.Items.Remove(item);
            }
        }

        private void FromSostavbutton_Click(object sender, EventArgs e)
        {
            object[] a = new object[BludoProduktslistBox.SelectedItems.Count];
            BludoProduktslistBox.SelectedItems.CopyTo(a, 0);
            foreach (var item in a)
            {
                AllProduktslistBox.Items.Add(item);
                BludoProduktslistBox.Items.Remove(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
                return;
            if(is_insert || old_name != textBox1.Text.Trim())
                if(Main.bluda.Any(elem => elem[0] == textBox1.Text.Trim()))
                {
                    MessageBox.Show("Такое блюдо уже есть!");
                    return;
                }
            List<string> a;
            if (is_insert)
                a = new List<string>();
            else
            {
                a = Main.bluda.Find(elem => elem[0] == textBox1.Text.Trim());
                a.Clear();
            }
            a.Add(textBox1.Text.Trim());
            foreach (var item in BludoProduktslistBox.Items)
            {
                a.Add(item.ToString());
            }
            if(is_insert)
                Main.bluda.Add(a);
            
            Close();
        }

        private string foo(List<string> source)
        {
            string sostav = "";
            for (int i = 1; i < source.Count; i++)
            {
                sostav += "\'" + source[i] + "\'" + ",";
            }
            sostav = sostav.Substring(0, sostav.Length - 1);
            return sostav;
        }
    }
}
