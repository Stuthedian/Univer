using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4_Postavki
{
    public partial class PostavshikiExtra : Form
    {
        Ed edited;
        DataSet1 dataset;
        DataView currentview = new DataView();
        DataView editedview = new DataView();
        public PostavshikiExtra(Ed edited, DataSet1 dataset)
        {
            InitializeComponent();
            this.dataset = dataset;
            this.edited = edited;
        }

        private void PostavshikiExtra_Load(object sender, EventArgs e)
        {
            currentview.Table = dataset.postavshiki;
            currentview.RowStateFilter = DataViewRowState.CurrentRows;
            editedview.Table = dataset.postavshiki;
            editedview.RowStateFilter = DataViewRowState.Added | DataViewRowState.Deleted | DataViewRowState.ModifiedOriginal;
            CurrentGridView.DataSource = currentview;
            CurrentGridView.AutoResizeColumns();
            EditedGridView.DataSource = editedview;
            EditedGridView.Columns.Add("RowState", "RowState");
            EditedGridView.Columns["RowState"].DisplayIndex = 0;
            editedview.Sort = "pc";
            for (int i = 0; i < EditedGridView.Rows.Count; i++)
            {
                EditedGridView.Rows[i].Cells["RowState"].Value 
                    = editedview[editedview.Find(EditedGridView.Rows[i].Cells["pc"].Value)].Row.RowState.ToString();
            }
            EditedGridView.AutoResizeColumns();
            if (currentview.Count == 0)
                Delbutton.Enabled = false;
            if (editedview.Count == 0)
                Cancelbutton.Enabled = false;
        }

        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            if(editedview.Count > 0)
            {
                int c = (int)EditedGridView.CurrentRow.Cells[0].Value;
                editedview.Sort = "pc";
                editedview[editedview.Find(c)].Row.RejectChanges();
            }
        }

        private void Delbutton_Click(object sender, EventArgs e)
        {
            if (currentview.Count > 0)
            {
                int c = (int)CurrentGridView.CurrentRow.Cells[0].Value;
                editedview.Sort = "pc";
                if (dataset.postavki.Select("pc='" + c.ToString() + "'").Count() != 0)
                {
                    MessageBox.Show("Удаление не возможно. Поставщик есть в поставках.");
                    return;
                }
                else
                {
                    editedview[editedview.Find(c)].Row.Delete();
                    edited.Value = true;
                }
            }
        }
    }
}
