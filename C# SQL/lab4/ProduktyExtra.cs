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
    public partial class ProduktyExtra : Form
    {
        Ed edited;
        DataSet1 dataset;
        DataView currentview = new DataView();
        DataView editedview = new DataView();
        public ProduktyExtra(Ed edited, DataSet1 dataset)
        {
            InitializeComponent();
            this.dataset = dataset;
            this.edited = edited;
        }

        private void ProduktyExtra_Load(object sender, EventArgs e)
        {
            currentview.Table = dataset.produkt;
            currentview.RowStateFilter = DataViewRowState.CurrentRows;
            editedview.Table = dataset.produkt;
            editedview.RowStateFilter = DataViewRowState.Added | DataViewRowState.Deleted | DataViewRowState.ModifiedOriginal;
            CurrentGridView.DataSource = currentview;
            CurrentGridView.AutoResizeColumns();
            EditedGridView.DataSource = editedview;
            EditedGridView.Columns.Add("RowState", "RowState");
            EditedGridView.Columns["RowState"].DisplayIndex = 0;
            editedview.Sort = "pr";
            for (int i = 0; i < EditedGridView.Rows.Count; i++)
            {
                EditedGridView.Rows[i].Cells["RowState"].Value 
                    = editedview[editedview.Find(EditedGridView.Rows[i].Cells["pr"].Value)].Row.RowState.ToString();
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
                editedview.Sort = "pr";
                editedview[editedview.Find(c)].Row.RejectChanges();
            }
        }

        private void Delbutton_Click(object sender, EventArgs e)
        {
            if (currentview.Count > 0)
            {
                int c = (int)CurrentGridView.CurrentRow.Cells[0].Value;
                editedview.Sort = "pr";
                if (dataset.postavki.Select("pr='" + c.ToString() + "'").Count() != 0)
                {
                    MessageBox.Show("Удаление не возможно. Продукт есть в поставках.");
                    return;
                }
                else if (dataset.sostav.Select("pr='" + c.ToString() + "'").Count() != 0)
                {
                    MessageBox.Show("Удаление не возможно. Продукт есть в составе.");
                    return;
                }
                else if (dataset.nalishie.Select("pr='" + c.ToString() + "'").Count() != 0)
                {
                    MessageBox.Show("Удаление не возможно. Продукт есть в наличии.");
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
