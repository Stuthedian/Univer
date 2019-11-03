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
    public partial class Sotrudnik : Form
    {
        Ed edited;
        public Sotrudnik(DataSet data, Ed ed)
        {
            InitializeComponent();
            dataSet = data;
            edited = ed;
        }

        private void buttons()
        {
            if (sotrudnikBindingSource.Count == 0)
                Editbutton.Enabled = Delbutton.Enabled = false;
            else
                Editbutton.Enabled = Delbutton.Enabled = true;
        }

        private void Sotrudnik_Load(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            sotrudnikBindingSource.DataSource = dataSet;
            buttons();
        }

        private void Exitbutton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Delbutton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить?", "Внимание", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (dataSet.Zapis.Select("cod_sotr='" + 
                    dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'").Count() != 0)
                {
                    MessageBox.Show("Удаление не возможно. Присутствуют записи с данным сотрудником.");
                    return;
                }
                try
                {
                    dataSet.Sotrudnik.FindBycod_sotr((int)dataGridView1.CurrentRow.Cells[0].Value).Delete();
                    buttons();
                    edited.Value = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Addbutton_Click(object sender, EventArgs e)
        {
            new SotrudnikEdit(true, dataSet, edited).ShowDialog();
            buttons();
        }

        private void Editbutton_Click(object sender, EventArgs e)
        {
            new SotrudnikEdit(false, sotrudnikBindingSource, dataSet, edited).ShowDialog();
            buttons();
        }

        private void Viewbutton_Click(object sender, EventArgs e)
        {
            new SotrudnikView(null, dataSet, false).ShowDialog();
        }
    }
}
