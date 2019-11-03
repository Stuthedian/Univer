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
    public partial class Main : Form
    {
        Ed edited = new Ed() { Value = false };
        DataSet dataSet = new DataSet();
        DataSetTableAdapters.IspolnitelTableAdapter IspolnitelTableAdapter = new DataSetTableAdapters.IspolnitelTableAdapter();
        DataSetTableAdapters.JanrTableAdapter JanrTableAdapter = new DataSetTableAdapters.JanrTableAdapter();
        DataSetTableAdapters.SotrudnikTableAdapter SotrudnikTableAdapter = new DataSetTableAdapters.SotrudnikTableAdapter();
        DataSetTableAdapters.ZapisTableAdapter ZapisTableAdapter = new DataSetTableAdapters.ZapisTableAdapter();
        public Main()
        {
            InitializeComponent();
        }

        private void исполнительToolStripMenuItem_Click(object sender, EventArgs e)
        {
           new Ispolnitel(dataSet, edited).ShowDialog();
        }

        private void жанрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Janr(dataSet, edited).ShowDialog();
        }

        private void сотрудникToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Sotrudnik(dataSet, edited).ShowDialog();
        }

        private void записьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Zapis(dataSet, edited).ShowDialog();
        }

        private void записиИсполнителя1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Query1(dataSet).ShowDialog();
        }

        private void записиМеждуДатамиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Query2(dataSet).ShowDialog();
        }

        private void сотрудникКварталыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Query3(dataSet).ShowDialog();
        }

        private void максЖанрыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Query4(dataSet).ShowDialog();
        }

        private void максИсполнителиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Query5(dataSet).ShowDialog();
        }

        private void записиПоЖанрамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Query6(dataSet).ShowDialog();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            try
            {
                IspolnitelTableAdapter.Fill(dataSet.Ispolnitel);
                JanrTableAdapter.Fill(dataSet.Janr);
                SotrudnikTableAdapter.Fill(dataSet.Sotrudnik);
                ZapisTableAdapter.Fill(dataSet.Zapis);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (edited.Value)
            {
                if (DialogResult.Yes == MessageBox.Show("Сохранить изменения в БД?", "Внимание", MessageBoxButtons.YesNo))
                {
                    //throw new NotImplementedException();
                    try
                    {
                        IspolnitelTableAdapter.Adapter.ContinueUpdateOnError = true;
                        JanrTableAdapter.Adapter.ContinueUpdateOnError = true;
                        SotrudnikTableAdapter.Adapter.ContinueUpdateOnError = true;
                        ZapisTableAdapter.Adapter.ContinueUpdateOnError = true;
                        DataView zapis = new DataView(dataSet.Zapis);
                        zapis.RowStateFilter = DataViewRowState.Deleted;
                        foreach (DataRowView r in zapis)
                        {
                            ZapisTableAdapter.Update(r.Row);
                        }
                        IspolnitelTableAdapter.Update(dataSet.Ispolnitel);
                        JanrTableAdapter.Update(dataSet.Janr);
                        SotrudnikTableAdapter.Update(dataSet.Sotrudnik);
                        zapis.RowStateFilter = DataViewRowState.ModifiedCurrent |
                                      DataViewRowState.Added;
                        foreach (DataRowView r in zapis)
                        {
                            ZapisTableAdapter.Update(r.Row);
                        }
                        handle_errors();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        handle_errors();
                    }
                }
                else
                {
                    dataSet.RejectChanges();
                    edited.Value = false;
                }
                if (DialogResult.No == MessageBox.Show("Выйти?", "Выход", MessageBoxButtons.YesNo))
                {
                    e.Cancel = true;
                    edited.Value = false;
                }
            }
        }

        private void handle_errors()
        {
            if (!dataSet.HasChanges())
            {
                MessageBox.Show("Изменения сохранены!");
                return;
            }
            else
            {
                DialogResult res = MessageBox.Show("Просмотреть не сохраненные изменения[Да]\n" +
                    "Отменить не сохраненные изменения[Нет]", "Внимание! Присутствуют не сохраненные изменения", 
             MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == res)
                {
                    new SaveView(dataSet).ShowDialog();
                }
                else
                {
                    foreach (DataRow dr in dataSet.Ispolnitel.GetErrors())
                        if (dr.HasErrors)
                        {
                            dr.RejectChanges();
                            dr.ClearErrors();
                        }
                    foreach (DataRow dr in dataSet.Janr.GetErrors())
                        if (dr.HasErrors)
                        {
                            dr.RejectChanges();
                            dr.ClearErrors();
                        }
                    foreach (DataRow dr in dataSet.Sotrudnik.GetErrors())
                        if (dr.HasErrors)
                        {
                            dr.RejectChanges();
                            dr.ClearErrors();
                        }
                    foreach (DataRow dr in dataSet.Zapis.GetErrors())
                        if (dr.HasErrors)
                        {
                            dr.RejectChanges();
                            dr.ClearErrors();
                        }
                }
            }
        }

        private void tESTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SaveView(dataSet).ShowDialog();
        }
    }

    public class Ed
    {
        public bool Value { get; set; }
    }
}
