using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zachet
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void исполнительToolStripMenuItem_Click(object sender, EventArgs e)
        {
           new Ispolnitel().ShowDialog();
        }

        private void жанрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Janr().ShowDialog();
        }

        private void сотрудникToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Sotrudnik().ShowDialog();
        }

        private void записьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Zapis().ShowDialog();
        }

        private void записиИсполнителя1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Query1().ShowDialog();
        }

        private void записиМеждуДатамиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Query2().ShowDialog();
        }

        private void сотрудникКварталыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Query3().ShowDialog();
        }

        private void максЖанрыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Query4().ShowDialog();
        }

        private void максИсполнителиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Query5().ShowDialog();
        }

        private void записиПоЖанрамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Query6().ShowDialog();
        }

    }
}
