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
    public partial class JanrView : Form
    {
        DataSet dataSet;
        DataView mainview, selectedview;
        SaveView parent;
        bool is_error_handling;
        private void JanrView_Load(object sender, EventArgs e)
        {
            textBox1.Visible = is_error_handling;
            MainGridView.RowHeadersVisible = is_error_handling;
            mainview = new DataView(dataSet.Janr);
            selectedview = new DataView(dataSet.Janr);

            mainview.RowStateFilter = DataViewRowState.Added | DataViewRowState.ModifiedCurrent | DataViewRowState.Deleted;
            selectedview.RowStateFilter = DataViewRowState.ModifiedOriginal;
            //if (mainview.Count == 0)
            //{
            //    MessageBox.Show("Нет измененных данных");
            //    Close();
            //    return;
            //}
            MainGridView.DataSource = mainview;
            SelectedGridView.DataSource = selectedview;
            
            MainGridView.Columns["naim"].HeaderText = "Жанр";
            MainGridView.Columns["cod_janr"].Visible = false;
            panel1.Visible = false;
            this.MainGridView.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.MainGridView_CellEnter);
            if (MainGridView.Rows.Count != 0)
                MainGridView.CurrentCell = MainGridView.Rows[0].Cells["naim"];
            else
                button1.Enabled = false;
            MainGridView.Columns.Add("Статус", "Статус");
            MainGridView.AutoResizeColumns();
            MainGridView_DataBindingComplete(new object(), new DataGridViewBindingCompleteEventArgs(ListChangedType.Reset));
        }

        private void MainGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            mainview.Sort = "cod_janr";
            int cod = (int)MainGridView.CurrentRow.Cells["cod_janr"].Value;
            DataRow r = mainview[mainview.Find(cod)].Row;
            if (is_error_handling)
                textBox1.Text = r.RowError;
            if (r.RowState == DataRowState.Modified)
            {
                selectedview.RowFilter = "cod_janr=" + cod;
                SelectedGridView.Columns["cod_janr"].Visible = false;
                SelectedGridView.Columns["naim"].HeaderText = "Жанр";
                panel1.Visible = true;
            }
            else panel1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainview.Sort = "cod_janr";
            int cod = (int)MainGridView.CurrentRow.Cells["cod_janr"].Value;
            DataRow r = mainview[mainview.Find(cod)].Row;
            if (r.RowState == DataRowState.Added && dataSet.Zapis.Select("cod_janr=" + cod).Count() != 0)
            {
                MessageBox.Show("Есть записи в данном жанре");
                return;
            }
            r.ClearErrors();
            r.RejectChanges();
            if (MainGridView.RowCount == 0)
                button1.Enabled = false;
        }

        private void MainGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            mainview.Sort = "cod_janr";
            for (int i = 0; i < MainGridView.Rows.Count; i++)
            {
                int cod = (int)MainGridView.Rows[i].Cells["cod_janr"].Value;
                DataRow r = mainview[mainview.Find(cod)].Row;
                switch (r.RowState)
                {
                    case DataRowState.Added:
                        MainGridView.Rows[i].Cells["Статус"].Value = "Добавлен";
                        break;
                    case DataRowState.Deleted:
                        MainGridView.Rows[i].Cells["Статус"].Value = "Удален";
                        break;
                    default:
                        MainGridView.Rows[i].Cells["Статус"].Value = "Изменен";
                        break;
                }
            }
            MainGridView.Columns["Статус"].DisplayIndex = 0;
            this.MainGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.MainGridView_DataBindingComplete);
        }

        private void JanrView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (is_error_handling)
                parent.null_child(ViewType.Janr);
        }

        public JanrView(SaveView p, DataSet ds, bool e)
        {
            InitializeComponent();
            dataSet = ds;
            is_error_handling = e;
            parent = p;
        }
    }
}
