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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var group in Form1.mac)
            {
                if(textBox1.Text == group[0])
                {
                    MessageBox.Show("Группа " + group[0] + " уже существует!");
                    return;
                }
            }
            Array.Resize(ref Form1.mac, Form1.mac.Length + 1);
            Form1.mac[Form1.mac.Length - 1] = new string[1];
            Form1.mac[Form1.mac.Length - 1][0] = textBox1.Text;

            Close();
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

        private void Form5_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
        }
    }
}
