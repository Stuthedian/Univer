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
    public partial class Janr : Form
    {
        Ed edited;
        public Janr(DataSet data, Ed ed)
        {
            InitializeComponent();
            dataSet = data;
            edited = ed;
        }

        private void buttons()
        {
            if(janrBindingSource.Count == 0)
                Editbutton.Enabled = Delbutton.Enabled = false;
            else
                Editbutton.Enabled = Delbutton.Enabled = true;
        }

        private void Janr_Load(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            janrBindingSource.DataSource = dataSet;
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
                //throw new NotImplementedException();
                if (dataSet.Zapis.Select("cod_janr='" + listBox1.SelectedValue + "'").Count() != 0)
                {
                    MessageBox.Show("Удаление не возможно. Присутствуют записи с данным жанром.");
                    return;
                }
                try
                {
                    dataSet.Janr.FindBycod_janr((int)listBox1.SelectedValue).Delete();
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
            new JanrEdit(true, dataSet, edited).ShowDialog();
            buttons();
        }

        private void Editbutton_Click(object sender, EventArgs e)
        {
            new JanrEdit(false, janrBindingSource, dataSet, edited).ShowDialog();
            buttons();
        }

        private void Viewbutton_Click(object sender, EventArgs e)
        {
            new JanrView(null, dataSet, false).ShowDialog();
        }
    }
}
