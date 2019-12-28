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
    public partial class Form1 : Form
    {
        public static string[][] mac;
        public Form1()
        {
            InitializeComponent();
            panel2.Location = panel3.Location;
            panel2.Visible = false;
            panel3.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mac = new string[textBox1.Lines.Length][];
            for (int i = 0; i < mac.Length; i++)
            {
                mac[i] = textBox1.Lines[i].Split(',');
                for (int j = i-1; j >= 0; j--)
                {
                    if(mac[j][0] == mac[i][0])
                    {
                        MessageBox.Show("Группа " + mac[i][0] + " уже была упомянута!");
                        return;
                    }
                }
            }

            panel2.Visible = true;
            panel3.Visible = false;
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            string str = "";
            foreach (var group in mac)
            {
                str += "Группа[" + group[0] + "] — Кол-во студентов:" + (group.Length - 1).ToString() + "\n";
            }
            MessageBox.Show(str);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Form2().ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Form3().ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string str = "Группы, в которых есть студенты, в фамилии "
                + "которых присутствует буква к и не менее двух букв о:\n";
            foreach (var group in mac)
            {
                for (int i = 1; i < group.Length; i++)
                {
                    if(group[i].Contains('к'))
                    {
                        if(group[i].IndexOf('о') != group[i].LastIndexOf('о'))
                        {
                            str += group[0] + "\n";
                            break;
                        }
                    }
                }
            }
            MessageBox.Show(str);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new Form4().ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new Form5().ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int max_len = 0;
            foreach (var group in mac)
            {
                if (group.Length > max_len)
                    max_len = group.Length;
            }
            string str = "Группы с максимальным числом студентов:\n";
            foreach (var group in mac)
            {
                if (group.Length == max_len)
                {
                    str += group[0] + "\n";
                }
            }
            max_len--;
            str += "Максимальное число студентов: " + max_len.ToString();
            MessageBox.Show(str);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            new Form6().ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            new Form7().ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            new FormEditStud().ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            new FormEditGroup().ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "110,Арбузов,Иванов\n210,Печорин,Сидоров";
            button1.PerformClick();
        }
    }
}
