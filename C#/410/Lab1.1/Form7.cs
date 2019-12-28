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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        private int index;
        private void Form7_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < Form1.mac.Length; i++)
            {
                comboBox1.Items.Add(Form1.mac[i][0]);
                
            }
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            index = -1;
            for (int i = 0; i < Form1.mac.Length; i++)
            {
                if (comboBox1.SelectedItem.ToString() == Form1.mac[i][0])
                {
                    index = i;
                    break;
                }
            }

            for (int j = 1; j < Form1.mac[index].Length; j++)
            {
                listBox1.Items.Add(Form1.mac[index][j]);
            }
            if (listBox1.Items.Count == 0)
                button7.Enabled = false;
            else
                button7.Enabled = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string[] group = new string[Form1.mac[index].Length - 1];
            group[0] = Form1.mac[index][0];
            for (int i = 1, k = 1; i < Form1.mac[index].Length; i++)
            {
                if(i != (listBox1.SelectedIndex + 1))
                {
                    group[k] = Form1.mac[index][i];
                    k++;
                }
            }
            Form1.mac[index] = group;
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);

            if (listBox1.Items.Count == 0)
                button7.Enabled = false;
            else
                button7.Enabled = true;
        }
    }
}
