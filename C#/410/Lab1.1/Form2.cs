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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            int max_len = 0;
            for (int i = 0; i < Form1.mac.Length; i++)
            {
                dataGridView1.Columns.Add(i.ToString(), Form1.mac[i][0]);
                Array.Sort(Form1.mac[i], 1, Form1.mac[i].Length - 1);
                if (max_len < Form1.mac[i].Length)
                    max_len = Form1.mac[i].Length;
            }
            dataGridView1.Rows.Add(max_len);
            for (int i = 0; i < Form1.mac.Length; i++)
            {
                for (int j = 1; j < Form1.mac[i].Length; j++)
                {
                    dataGridView1.Rows[j - 1].Cells[i].Value = Form1.mac[i][j];
                }
                dataGridView1.Rows[max_len - 1].Cells[i].Value = (Form1.mac[i].Length - 1).ToString();
                //310,a,b 210,a
            }
        }
    }
}
