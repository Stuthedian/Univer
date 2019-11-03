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

namespace Lab3_Pansionat
{
    public partial class button4_Form : Form
    {
        DataSet dataSet;
        DataTable Year, Month, postavki;
        SqlDataAdapter YearAdapter, MonthAdapter, postavkiAdapter;
        DataRelation YearMonth;
        BindingSource Yearbinding, Monthbinding, postavkibinding;
        SqlConnection connection = new SqlConnection(Properties.Settings.Default.pansion_metodConnectionString);
        public button4_Form()
        {
            InitializeComponent();
        }

        private void button4_Form_Load(object sender, EventArgs e)
        {
            string[] commands = { "SELECT DISTINCT YEAR(data) AS yearexpr FROM postavki",
            "SELECT YEAR(data) AS yearexpr, DATENAME(month, data) AS monthexpr FROM postavki " +
            "GROUP BY YEAR(data), DATENAME(month, data) ORDER BY monthexpr DESC",
            "SELECT postavshiki.nazvanie, produkt.produkt, SUM(postavki.kol) AS Expr1, YEAR(postavki.data) AS yearexpr, DATENAME(month, postavki.data) AS monthexpr " +
            "FROM postavki INNER JOIN produkt ON postavki.pr = produkt.pr INNER JOIN postavshiki ON postavki.pc = postavshiki.pc " +
            "GROUP BY postavshiki.nazvanie, produkt.produkt, YEAR(postavki.data), DATENAME(month, postavki.data)"};
            dataSet = new DataSet();
            Year = new DataTable();
            Month = new DataTable();
            postavki = new DataTable();
            dataSet.Tables.Add(Year);
            dataSet.Tables.Add(Month);
            dataSet.Tables.Add(postavki);
            YearAdapter = new SqlDataAdapter(commands[0], connection);
            MonthAdapter = new SqlDataAdapter(commands[1], connection);
            postavkiAdapter = new SqlDataAdapter(commands[2], connection);
            YearAdapter.Fill(Year);
            MonthAdapter.Fill(Month);
            postavkiAdapter.Fill(postavki);
            YearMonth = new DataRelation("YearMonth", Year.Columns[0], Month.Columns[0]);
            dataSet.Relations.Add(YearMonth);

            Yearbinding = new BindingSource();
            Yearbinding.DataSource = Year;
            yearBox.DataSource = Yearbinding;
            yearBox.DisplayMember = "yearexpr";
            yearBox.ValueMember = "yearexpr";

            Monthbinding = new BindingSource();
            Monthbinding.DataSource = Yearbinding;
            Monthbinding.DataMember = "YearMonth";
            monthBox.DataSource = Monthbinding;
            monthBox.DisplayMember = "monthexpr";
            monthBox.ValueMember = "monthexpr";

            postavkibinding = new BindingSource();
            postavkibinding.DataSource = postavki;
            dataGridView1.DataSource = postavkibinding;
            dataGridView1.Columns[0].HeaderText = "Поставщик";
            dataGridView1.Columns[1].HeaderText = "Продукт";
            dataGridView1.Columns[2].HeaderText = "Количество";
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            postavkibinding.Filter = "yearexpr=" + yearBox.SelectedValue + " and " +
            " monthexpr='" + monthBox.SelectedValue + "'";
        }

        private void yearBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(postavkibinding != null)
                postavkibinding.Filter = "yearexpr=" + yearBox.SelectedValue + " and " +
                " monthexpr='" + monthBox.SelectedValue + "'";
        }

        private void monthBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (postavkibinding != null)
                postavkibinding.Filter = "yearexpr=" + yearBox.SelectedValue + " and " +
                " monthexpr='" + monthBox.SelectedValue + "'";
        }
    }
}
