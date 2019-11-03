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
    public partial class ZapisView : Form
    {
        DataSet dataSet;
        DataView mainview, selectedview;
        SaveView parent;
        bool is_error_handling;
        private void ZapisView_Load(object sender, EventArgs e)
        {
            textBox1.Visible = is_error_handling;
            MainGridView.RowHeadersVisible = is_error_handling;
            mainview = new DataView(dataSet.Zapis);
            selectedview = new DataView(dataSet.Zapis);

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
            
            
            MainGridView.Columns["naim_zapis"].HeaderText = "Наименование записи";
            MainGridView.Columns["data"].HeaderText = "Дата";

            MainGridView.Columns["cod_zap"].Visible = false;
            MainGridView.Columns["cod_isp"].Visible = false;
            MainGridView.Columns["cod_janr"].Visible = false;
            MainGridView.Columns["cod_sotr"].Visible = false;
            panel1.Visible = false;
            MainGridView.Columns.Add("Статус", "Статус");
            MainGridView.Columns.Add("Isp", "Исполнитель");
            MainGridView.Columns.Add("Janr", "Жанр");
            MainGridView.Columns.Add("Sotr", "Сотрудник");
            MainGridView.AutoResizeColumns();
            MainGridView_DataBindingComplete(new object(), new DataGridViewBindingCompleteEventArgs(ListChangedType.Reset));
            SelectedGridView.Columns["cod_zap"].Visible = false;
            SelectedGridView.Columns["cod_isp"].Visible = false;
            SelectedGridView.Columns["cod_janr"].Visible = false;
            SelectedGridView.Columns["cod_sotr"].Visible = false;
            SelectedGridView.Columns["naim_zapis"].HeaderText = "Наименование записи";
            SelectedGridView.Columns["data"].HeaderText = "Дата";
            SelectedGridView.Columns.Add("Isp", "Исполнитель");
            SelectedGridView.Columns.Add("Janr", "Жанр");
            SelectedGridView.Columns.Add("Sotr", "Сотрудник");
            this.MainGridView.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.MainGridView_CellEnter);
            if (MainGridView.Rows.Count != 0)
                MainGridView.CurrentCell = MainGridView.Rows[0].Cells["naim_zapis"];
            else
                button1.Enabled = false;

        }

        private void MainGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            mainview.Sort = "cod_zap";
            DataRow r = mainview[mainview.Find(MainGridView.CurrentRow.Cells["cod_zap"].Value)].Row;
            if (is_error_handling)
                textBox1.Text = r.RowError;
            if (r.RowState == DataRowState.Modified)
            {
                selectedview.RowFilter = "cod_zap=" + MainGridView.CurrentRow.Cells["cod_zap"].Value.ToString();
                SelectedGridView.Rows[0].Cells["Isp"].Value = dataSet.Ispolnitel.
                    FindBycod_isp((int)SelectedGridView.CurrentRow.Cells["cod_isp"].Value).naim;
                SelectedGridView.Rows[0].Cells["Janr"].Value = dataSet.Janr.
                    FindBycod_janr((int)SelectedGridView.CurrentRow.Cells["cod_janr"].Value).naim;
                SelectedGridView.Rows[0].Cells["Sotr"].Value = dataSet.Sotrudnik.
                    FindBycod_sotr((int)SelectedGridView.CurrentRow.Cells["cod_sotr"].Value).fam;
                panel1.Visible = true;
            }
            else panel1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataRow r = mainview[mainview.Find(MainGridView.CurrentRow.Cells["cod_zap"].Value)].Row;
            r.ClearErrors();
            r.RejectChanges();
            if (MainGridView.RowCount == 0)
                button1.Enabled = false;
        }

        private void MainGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            mainview.Sort = "cod_zap";
            for (int i = 0; i < MainGridView.Rows.Count; i++)
            {
                DataRow r = mainview[mainview.Find(MainGridView.Rows[i].Cells["cod_zap"].Value)].Row;
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
                MainGridView.Rows[i].Cells["Isp"].Value = dataSet.Ispolnitel.
                    FindBycod_isp((int)MainGridView.CurrentRow.Cells["cod_isp"].Value).naim;
                MainGridView.Rows[i].Cells["Janr"].Value = dataSet.Janr.
                    FindBycod_janr((int)MainGridView.CurrentRow.Cells["cod_janr"].Value).naim;
                MainGridView.Rows[i].Cells["Sotr"].Value = dataSet.Sotrudnik.
                    FindBycod_sotr((int)MainGridView.CurrentRow.Cells["cod_sotr"].Value).fam;
            }
            MainGridView.Columns["Статус"].DisplayIndex = 0;
            this.MainGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.MainGridView_DataBindingComplete);
        }

        private void ZapisView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (is_error_handling)
                parent.null_child(ViewType.Zapis);
        }

        public ZapisView(SaveView p, DataSet ds, bool e)
        {
            InitializeComponent();
            dataSet = ds;
            is_error_handling = e;
            parent = p;
        }
    }
}
