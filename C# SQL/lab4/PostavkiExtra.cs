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
    public partial class PostavkiExtra : Form
    {
        Ed edited;
        DataSet1 dataset;
        DataView currentview = new DataView();
        DataView editedview = new DataView();
        public PostavkiExtra(Ed edited, DataSet1 dataset)
        {
            InitializeComponent();
            this.dataset = dataset;
            this.edited = edited;
        }

        private void PostavkiExtra_Load(object sender, EventArgs e)
        {
            currentview.Table = dataset.postavki;
            currentview.RowStateFilter = DataViewRowState.CurrentRows;
            editedview.Table = dataset.postavki;
            editedview.RowStateFilter = DataViewRowState.Added | DataViewRowState.Deleted | DataViewRowState.ModifiedOriginal;
            CurrentGridView.DataSource = currentview;
            CurrentGridView.AutoResizeColumns();
            EditedGridView.DataSource = editedview;
            EditedGridView.Columns.Add("RowState", "RowState");
            EditedGridView.Columns["RowState"].DisplayIndex = 0;
            editedview.Sort = "pc, pr, data";
            for (int i = 0; i < EditedGridView.Rows.Count; i++)
            {
                object[] temp = new object[] {
                    EditedGridView.Rows[i].Cells["pc"].Value,
                    EditedGridView.Rows[i].Cells["pr"].Value,
                    EditedGridView.Rows[i].Cells["data"].Value };
                EditedGridView.Rows[i].Cells["RowState"].Value 
                    = editedview[editedview.Find(temp)].Row.RowState.ToString();
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
                object[] temp = new object[] {
                    EditedGridView.CurrentRow.Cells["pc"].Value,
                    EditedGridView.CurrentRow.Cells["pr"].Value,
                    EditedGridView.CurrentRow.Cells["data"].Value };
                editedview.Sort = "pc, pr, data";
                editedview[editedview.Find(temp)].Row.RejectChanges();
            }
        }

        private void Delbutton_Click(object sender, EventArgs e)
        {
            if (currentview.Count > 0)
            {
                object[] temp = new object[] {
                    EditedGridView.CurrentRow.Cells["pc"].Value,
                    EditedGridView.CurrentRow.Cells["pr"].Value,
                    EditedGridView.CurrentRow.Cells["data"].Value };
                editedview.Sort = "pc, pr, data";
                editedview[editedview.Find(temp)].Row.Delete();
                edited.Value = true;
            }
        }
    }
}
