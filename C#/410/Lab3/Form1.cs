﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(new Postavka(textBox1.Text, textBox2.Text, (int)numericUpDown1.Value, (double)numericUpDown2.Value, dateTimePicker1.Value).show_status());
        }
    }
}
