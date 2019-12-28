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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < Form1.mac.Length; i++)
            {
                comboBox1.Items.Add(Form1.mac[i][0]);
            }
            comboBox1.SelectedIndex = 0;
            button1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = -1;
            for (int i = 0; i < Form1.mac.Length; i++)
            {
                if (comboBox1.SelectedItem.ToString() == Form1.mac[i][0])
                {
                    index = i;
                    break;
                }
            }
            Array.Resize(ref Form1.mac[index], Form1.mac[index].Length + 1);
            Form1.mac[index][Form1.mac[index].Length - 1] = textBox1.Text;
            Array.Sort(Form1.mac[index], 1, Form1.mac[index].Length - 1);

            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //if (textBox1.Text.Trim().All(c => Char.IsLetter(c)))
            if (textBox1.Text.Trim().Length == 0)
                button1.Enabled = false;
            else
                button1.Enabled = true;
            if (textBox1.Text.Trim().All(c => (c >= 'А' && c <= 'Я') || (c >= 'а' && c <= 'я') || c == 'ё' || c == 'Ё'))
            {
                Errlabel.Visible = false;
                button1.Enabled = true;
                errorProvider1.SetError(textBox1, "");
            }
            else
            {
                Errlabel.Visible = true;
                button1.Enabled = false;
                errorProvider1.SetError(textBox1, "Разрешён ввод только русских букв!");
            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if(Errlabel.Visible)
                e.Cancel = true;
        }
    }
}
