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
    public partial class Ispolnitel : Form
    {
        Ed edited;
        public Ispolnitel(DataSet data, Ed ed)
        {
            InitializeComponent();
            dataSet = data;
            edited = ed;
        }

        private void buttons()
        {
            if(ispolnitelBindingSource.Count == 0)
                Editbutton.Enabled = Delbutton.Enabled = false;
            else
                Editbutton.Enabled = Delbutton.Enabled = true;
        }

        private void Ispolnitel_Load(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ispolnitelBindingSource.DataSource = dataSet;
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
                if (dataSet.Zapis.Select("cod_isp='" + listBox1.SelectedValue + "'").Count() != 0)
                {
                    MessageBox.Show("Удаление не возможно. Присутствуют записи с данным исполнителем.");
                    return;
                }
                try
                {
                    dataSet.Ispolnitel.FindBycod_isp((int)listBox1.SelectedValue).Delete();
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
            new IspolnitelEdit(true, dataSet, edited).ShowDialog();
            buttons();
        }

        private void Editbutton_Click(object sender, EventArgs e)
        {
            new IspolnitelEdit(false, ispolnitelBindingSource, dataSet, edited).ShowDialog();
            buttons();
        }

        private void Viewbutton_Click(object sender, EventArgs e)
        {
            new IspolnitelView(null, dataSet, false).ShowDialog();
        }
    }
}
