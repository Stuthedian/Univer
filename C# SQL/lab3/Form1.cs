using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3_Pansionat
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Exit_button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1_Form button1_Form = new button1_Form();
            button1_Form.ShowDialog();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2_Form button2_Form = new button2_Form();
            button2_Form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3_Form button3_Form = new button3_Form();
            button3_Form.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4_Form button4_Form = new button4_Form();
            button4_Form.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5_Form button5_Form = new button5_Form();
            button5_Form.ShowDialog();
        }
    }
}
