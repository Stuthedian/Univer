using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1._1
{
    public partial class FormEditGroup : Form
    {
        public FormEditGroup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Form1.mac.Length; i++)
            {
                if (i !=  comboBox1.SelectedIndex && textBox1.Text == Form1.mac[i][0])
                {
                    MessageBox.Show("Группа " + Form1.mac[i][0] + " уже существует!");
                    return;
                }
            }
            
            //Array.Resize(ref Form1.mac, Form1.mac.Length + 1);
            //Form1.mac[Form1.mac.Length - 1] = new string[1];
            Form1.mac[comboBox1.SelectedIndex][0] = textBox1.Text;

            Close();
        }

        private void FormEditGroup_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < Form1.mac.Length; i++)
            {
                comboBox1.Items.Add(Form1.mac[i][0]);
            }
            comboBox1.SelectedIndex = 0;
            if (textBox1.Text.Trim().Length == 0)
                button1.Enabled = false;
            else
                button1.Enabled = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = comboBox1.SelectedItem.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length == 0)
            {
                button1.Enabled = false;
                return;
            }
            else
                button1.Enabled = true;
            if (textBox1.Text.Trim().All(c => Char.IsDigit(c)))
            {
                Errlabel.Visible = false;
                button1.Enabled = true;
                errorProvider1.SetError(textBox1, "");
            }
            else
            {
                Errlabel.Visible = true;
                button1.Enabled = false;
                errorProvider1.SetError(textBox1, "Разрешён ввод только цифр!");
            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (Errlabel.Visible)
                e.Cancel = true;
        }
    }
}
