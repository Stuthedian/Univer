using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Lab4_Postavki
{
    public partial class Form1 : Form
    {
        Ed edited = new Ed() { Value = false };
        private DataSet1 dataSet1;
        private DataSet1TableAdapters.postavkiTableAdapter postavkiTableAdapter;
        private DataSet1TableAdapters.postavshikiTableAdapter postavshikiTableAdapter;
        private DataSet1TableAdapters.produktTableAdapter produktTableAdapter;
        private DataSet1TableAdapters.trapeziTableAdapter trapeziTableAdapter;
        private DataSet1TableAdapters.vid_bludTableAdapter vid_bludTableAdapter;
        private DataSet1TableAdapters.nalishieTableAdapter nalishieTableAdapter;
        private DataSet1TableAdapters.bludaTableAdapter bludaTableAdapter;
        private DataSet1TableAdapters.menuTableAdapter menuTableAdapter;
        private DataSet1TableAdapters.osnovaTableAdapter osnovaTableAdapter;
        private DataSet1TableAdapters.sostavTableAdapter sostavTableAdapter;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Exitbutton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Tablebutton_Click(object sender, EventArgs e)
        {
            new TableForm(edited, dataSet1).ShowDialog();
        }

        private void Querybutton_Click(object sender, EventArgs e)
        {
            new QueryForm(dataSet1).ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataSet1 = new DataSet1();
            postavkiTableAdapter = new DataSet1TableAdapters.postavkiTableAdapter();
            postavshikiTableAdapter = new DataSet1TableAdapters.postavshikiTableAdapter();
            produktTableAdapter = new DataSet1TableAdapters.produktTableAdapter();
            trapeziTableAdapter = new DataSet1TableAdapters.trapeziTableAdapter();
            vid_bludTableAdapter = new DataSet1TableAdapters.vid_bludTableAdapter();
            nalishieTableAdapter = new DataSet1TableAdapters.nalishieTableAdapter();
            bludaTableAdapter = new DataSet1TableAdapters.bludaTableAdapter();
            menuTableAdapter = new DataSet1TableAdapters.menuTableAdapter();
            osnovaTableAdapter = new DataSet1TableAdapters.osnovaTableAdapter();
            sostavTableAdapter = new DataSet1TableAdapters.sostavTableAdapter();
            try
            {
                postavshikiTableAdapter.Fill(dataSet1.postavshiki);
                produktTableAdapter.Fill(dataSet1.produkt);
                postavkiTableAdapter.Fill(dataSet1.postavki);
                trapeziTableAdapter.Fill(dataSet1.trapezi);
                vid_bludTableAdapter.Fill(dataSet1.vid_blud);
                nalishieTableAdapter.Fill(dataSet1.nalishie);
                bludaTableAdapter.Fill(dataSet1.bluda);
                menuTableAdapter.Fill(dataSet1.menu);
                osnovaTableAdapter.Fill(dataSet1.osnova);
                sostavTableAdapter.Fill(dataSet1.sostav);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (edited.Value)
            {
                if (DialogResult.Yes == MessageBox.Show("Сохранить изменения в БД?", "Внимание", MessageBoxButtons.YesNo))
                {
                    try
                    {
                        int kt = 0;
                        int kol = dataSet1.postavki.Count;
                        DataRow[] rows = new DataRow[kol];
                        foreach (DataRow r in dataSet1.postavki)
                        {
                            if (r.RowState == DataRowState.Deleted)
                            { 
                                rows[kt] = r; 
                                kt++; 
                            }
                        }
                        for (int k = 0; k <= kt; k++)
                        {
                            postavkiTableAdapter.Update(rows[k]); 
                        }
                        postavshikiTableAdapter.Update(dataSet1.postavshiki);
                        produktTableAdapter.Update(dataSet1.produkt);

                        kol = dataSet1.postavki.Count; 
                        rows = new DataRow[kol]; 
                        kt = 0;
                        foreach (DataRow r in dataSet1.postavki)
                        {
                            if (r.RowState == DataRowState.Modified || r.RowState == DataRowState.Added)
                            { 
                                rows[kt] = r; 
                                kt++; 
                            }
                        }
                        for (int k = 0; k <= kt; k++)
                        {
                            postavkiTableAdapter.Update(rows[k]);
                        }
                        dataSet1.AcceptChanges();
                        edited.Value = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    dataSet1.RejectChanges();
                    edited.Value = false;
                }
                if (DialogResult.No == MessageBox.Show("Выйти?", "Выход", MessageBoxButtons.YesNo))
                {
                    e.Cancel = true;
                }
            }
        }
    }
    public class Ed
    {
        public bool Value { get; set; }
    }
}
