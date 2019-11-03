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
    public partial class SotrudnikView : Form
    {
        DataSet dataSet;
        DataView mainview, selectedview;
        SaveView parent;
        bool is_error_handling;
        private void SotrudnikView_Load(object sender, EventArgs e)
        {
            textBox1.Visible = is_error_handling;
            MainGridView.RowHeadersVisible = is_error_handling;
            mainview = new DataView(dataSet.Sotrudnik);
            selectedview = new DataView(dataSet.Sotrudnik);

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

            MainGridView.Columns["fam"].HeaderText = "Фамилия";
            MainGridView.Columns["im"].HeaderText = "Имя";
            MainGridView.Columns["otch"].HeaderText = "Отчество";
            MainGridView.Columns["dr"].HeaderText = "День рождения";
            MainGridView.Columns["pol"].HeaderText = "Пол";

            
            MainGridView.Columns["cod_sotr"].Visible = false;
            panel1.Visible = false;
            this.MainGridView.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.MainGridView_CellEnter);
            if (MainGridView.Rows.Count != 0)
                MainGridView.CurrentCell = MainGridView.Rows[0].Cells["fam"];
            else
                button1.Enabled = false;
            MainGridView.Columns.Add("Статус", "Статус");
            MainGridView.AutoResizeColumns();
            MainGridView_DataBindingComplete(new object(), new DataGridViewBindingCompleteEventArgs(ListChangedType.Reset));

        }

        private void MainGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            mainview.Sort = "cod_sotr";
            int cod = (int)MainGridView.CurrentRow.Cells["cod_sotr"].Value;
            DataRow r = mainview[mainview.Find(cod)].Row;
            if (is_error_handling)
                textBox1.Text = r.RowError;
            if (r.RowState == DataRowState.Modified)
            {
                selectedview.RowFilter = "cod_sotr=" + cod;
                SelectedGridView.Columns["cod_sotr"].Visible = false;
                SelectedGridView.Columns["fam"].HeaderText = "Фамилия";
                SelectedGridView.Columns["im"].HeaderText = "Имя";
                SelectedGridView.Columns["otch"].HeaderText = "Отчество";
                SelectedGridView.Columns["dr"].HeaderText = "День рождения";
                SelectedGridView.Columns["pol"].HeaderText = "Пол";
                panel1.Visible = true;
            }
            else panel1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int cod = (int)MainGridView.CurrentRow.Cells["cod_sotr"].Value;
            DataRow r = mainview[mainview.Find(cod)].Row;
            if (r.RowState == DataRowState.Added && dataSet.Zapis.Select("cod_sotr=" + cod).Count() != 0)
            {
                MessageBox.Show("Есть записи с данным сотрудником");
                return;
            }
            r.ClearErrors();
            r.RejectChanges();
            if (MainGridView.RowCount == 0)
                button1.Enabled = false;
        }

        private void MainGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            mainview.Sort = "cod_sotr";
            for (int i = 0; i < MainGridView.Rows.Count; i++)
            {
                int cod = (int)MainGridView.Rows[i].Cells["cod_sotr"].Value;
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

        private void SotrudnikView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (is_error_handling)
                parent.null_child(ViewType.Sotrudnik);
        }

        public SotrudnikView(SaveView p, DataSet ds, bool e)
        {
            InitializeComponent();
            dataSet = ds;
            is_error_handling = e;
            parent = p;
        }
    }
}
