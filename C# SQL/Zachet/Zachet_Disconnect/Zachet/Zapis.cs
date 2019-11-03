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
    public partial class Zapis : Form
    {
        Ed edited;
        public Zapis(DataSet data, Ed ed)
        {
            InitializeComponent();
            dataSet = data;
            edited = ed;
        }

        private void buttons()
        {
            if (zapisBindingSource.Count == 0)
                Editbutton.Enabled = Delbutton.Enabled = false;
            else
                Editbutton.Enabled = Delbutton.Enabled = true;
        }

        private void Zapis_Load(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            zapisBindingSource.DataSource = dataSet;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells["Isp"].Value =
                    dataSet.Ispolnitel.FindBycod_isp
                    (int.Parse(dataGridView1.Rows[i].Cells["codispDataGridViewTextBoxColumn"].Value.ToString()))[1].ToString();
                dataGridView1.Rows[i].Cells["Janr"].Value =
                    dataSet.Janr.FindBycod_janr
                    (int.Parse(dataGridView1.Rows[i].Cells["codjanrDataGridViewTextBoxColumn"].Value.ToString()))[1].ToString();
                var row = dataSet.Sotrudnik.FindBycod_sotr
                    (int.Parse(dataGridView1.Rows[i].Cells["codsotrDataGridViewTextBoxColumn"].Value.ToString()));
                dataGridView1.Rows[i].Cells["Sotr"].Value = row[1].ToString() + " "
                    + row[2].ToString()[0] + "." + row[3].ToString()[0] + ".";
            }
        }

        private void Exitbutton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Delbutton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить?", "Внимание", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    dataSet.Zapis.FindBycod_zap
                        (int.Parse(dataGridView1.CurrentRow.Cells["codzapDataGridViewTextBoxColumn"].Value.ToString()))
                        .Delete();
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
            
            new ZapisEdit(true, zapisBindingSource, dataSet, new int[] {0,0,0}, 
                edited).ShowDialog();
            Zapis_Load(sender, e);
            dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["Isp"];
            buttons();
        }

        private void Editbutton_Click(object sender, EventArgs e)
        {
            var row = dataGridView1.CurrentRow;
            new ZapisEdit(false, zapisBindingSource, dataSet, new int[] {
                (int)row.Cells["codispDataGridViewTextBoxColumn"].Value,
                (int)row.Cells["codjanrDataGridViewTextBoxColumn"].Value,
                (int)row.Cells["codsotrDataGridViewTextBoxColumn"].Value,
                (int)row.Cells["codzapDataGridViewTextBoxColumn"].Value}, edited).ShowDialog();
            Zapis_Load(sender, e);
            buttons();
        }

        private void Viewbutton_Click(object sender, EventArgs e)
        {
            new ZapisView(null, dataSet, false).ShowDialog();
        }
    }
}
