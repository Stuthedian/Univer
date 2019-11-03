using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4_kofe_tulskiy
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void Exit_button_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void Vvod_button_postavki_Click(object sender, EventArgs e)
		{
			vvod v1 = new vvod();
			v1.ShowDialog();
		}

		private void Zapros_1_Click(object sender, EventArgs e)
		{
			zapros_1 z1 = new zapros_1();
			z1.ShowDialog();
		}

		private void Zapros_2_Click(object sender, EventArgs e)
		{
			zapros_2 z2 = new zapros_2();
			z2.ShowDialog();
		}

		private void Zapros_3_Click(object sender, EventArgs e)
		{
			zapros_3 z3 = new zapros_3();
			z3.ShowDialog();
		}

        private void Zapros_4_Click(object sender, EventArgs e)
        {
            zapros_4 z4 = new zapros_4();
            z4.ShowDialog();
        }

		private void Vvod_button_tovar_Click(object sender, EventArgs e)
		{
			tovar t = new tovar();
			t.ShowDialog();
		}

		private void Vvod_button_postavshiki_Click(object sender, EventArgs e)
		{
			postavshik p = new postavshik();
			p.ShowDialog();
		}

    }
}
