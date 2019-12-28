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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < Form1.mac.Length; i++)
            {
                comboBox1.Items.Add(Form1.mac[i][0]);
            }
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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

            listBox1.Items.Clear();
            for (int i = 1; i < Form1.mac[index].Length; i++)
            {
                listBox1.Items.Add(Form1.mac[index][i]);
            }
        }
    }
}
