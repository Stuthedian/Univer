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
    public partial class Query2 : Form
    {
        DataSet1 dataSet1;
        DataView dataView = new DataView();
        public Query2(DataSet1 data)
        {
            InitializeComponent();
            dataSet1 = data;
        }

        private void Query2_Load(object sender, EventArgs e)
        {
            dataView.Table = dataSet1.postavshiki;
            if (!dataSet1.postavki.Columns.Contains("quarter1"))
                dataSet1.postavki.Columns.Add("quarter1", typeof(System.Decimal),
                    "iif(substring(convert(data,System.String),4,2) " +
                    " in ('01','02','03'), kol, 0)");
            if (!dataSet1.postavki.Columns.Contains("quarter2"))
                dataSet1.postavki.Columns.Add("quarter2", typeof(System.Decimal),
                    "iif(substring(convert(data,System.String),4,2) " +
                    " in ('04','05','06'), kol, 0)");
            if (!dataSet1.postavki.Columns.Contains("quarter3"))
                dataSet1.postavki.Columns.Add("quarter3", typeof(System.Decimal),
                    "iif(substring(convert(data,System.String),4,2) " +
                    " in ('07','08','09'), kol, 0)");
            if (!dataSet1.postavki.Columns.Contains("quarter4"))
                dataSet1.postavki.Columns.Add("quarter4", typeof(System.Decimal),
                    "iif(substring(convert(data,System.String),4,2) " +
                    " in ('10','11','12'), kol, 0)");
            if (!dataView.Table.Columns.Contains("quarter1"))
                dataView.Table.Columns.Add("quarter1", typeof(System.Decimal),
                    "sum(child(postavshiki_postavki).quarter1)");
            if (!dataView.Table.Columns.Contains("quarter2"))
                dataView.Table.Columns.Add("quarter2", typeof(System.Decimal),
                    "sum(child(postavshiki_postavki).quarter2)");
            if (!dataView.Table.Columns.Contains("quarter3"))
                dataView.Table.Columns.Add("quarter3", typeof(System.Decimal),
                    "sum(child(postavshiki_postavki).quarter3)");
            if (!dataView.Table.Columns.Contains("quarter4"))
                dataView.Table.Columns.Add("quarter4", typeof(System.Decimal),
                    "sum(child(postavshiki_postavki).quarter4)");
            if (!dataView.Table.Columns.Contains("year"))
                dataView.Table.Columns.Add("year", typeof(System.Decimal),
                    "sum(child(postavshiki_postavki).kol)");

            dataGridView1.DataSource = dataView;
            dataGridView1.Columns.Remove("pc");
            dataGridView1.Columns.Remove("status");
            dataGridView1.Columns.Remove("gorod");
            dataGridView1.Columns.Remove("adres");
            dataGridView1.Columns.Remove("tel");

            dataGridView1.Columns["nazvanie"].HeaderText = "Название";
            dataGridView1.Columns["quarter1"].HeaderText = "За 1-й квартал";
            dataGridView1.Columns["quarter2"].HeaderText = "За 2-й квартал";
            dataGridView1.Columns["quarter3"].HeaderText = "За 3-й квартал";
            dataGridView1.Columns["quarter4"].HeaderText = "За 4-й квартал";
            dataGridView1.Columns["year"].HeaderText = "За год";
            dataGridView1.AutoResizeColumns();
        }
    }
}
