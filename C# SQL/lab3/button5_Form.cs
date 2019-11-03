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
    public partial class button5_Form : Form
    {
        DataSet dataSet;
        DataTable bluda, postavshikAny, postavshikAll;
        SqlDataAdapter bludaAdapter, postavshikAnyAdapter, postavshikAllAdapter;
        DataRelation[] relations;
        BindingSource bludabinding, postavshikAnybinding, postavshikAllbinding;
        SqlConnection connection = new SqlConnection(Properties.Settings.Default.pansion_metodConnectionString);
        public button5_Form()
        {
            InitializeComponent();
        }

        private void button5_Form_Load(object sender, EventArgs e)
        {
            string[] commands = { "SELECT bl, bludo FROM bluda",
            "SELECT t.bl, postavshiki.nazvanie FROM postavshiki CROSS JOIN bluda AS t " +
            "WHERE ((SELECT COUNT(distinct pr) AS Expr1 FROM postavki WHERE (pr IN " +
            "(SELECT postavki_3.pr FROM bluda INNER JOIN sostav ON bluda.bl = sostav.bl INNER JOIN " +
            "postavki AS postavki_3 ON sostav.pr = postavki_3.pr WHERE (bluda.bl = t.bl))) AND (pc = postavshiki.pc)) >= 1) AND " +
            "((SELECT COUNT(distinct pr) AS Expr1 FROM postavki AS postavki_2 WHERE(pr IN " +
            "(SELECT postavki_1.pr FROM bluda AS bluda_2 INNER JOIN sostav AS sostav_2 ON bluda_2.bl = sostav_2.bl INNER JOIN " +
            "postavki AS postavki_1 ON sostav_2.pr = postavki_1.pr WHERE (bluda_2.bl = t.bl))) AND (pc = postavshiki.pc)) < " +
            "(SELECT COUNT(sostav_1.pr) AS Expr1 FROM bluda AS bluda_1 INNER JOIN sostav AS sostav_1 ON bluda_1.bl = sostav_1.bl " +
            "WHERE(bluda_1.bl = t.bl)))",
            "select t.bl,nazvanie from postavshiki,bluda as t where (select count(distinct pr) from postavki " +
            "where pr in (select postavki.pr from bluda join sostav on bluda.bl = sostav.bl join postavki on sostav.pr = postavki.pr " +
            "where bluda.bl = t.bl)  and pc = postavshiki.pc) = (select count(pr) from bluda join sostav on bluda.bl = sostav.bl " +
            "where bluda.bl = t.bl)"};
            dataSet = new DataSet();
            bluda = new DataTable();
            postavshikAny = new DataTable();
            postavshikAll = new DataTable();
            dataSet.Tables.Add(bluda);
            dataSet.Tables.Add(postavshikAny);
            dataSet.Tables.Add(postavshikAll);
            bludaAdapter = new SqlDataAdapter(commands[0], connection);
            postavshikAnyAdapter = new SqlDataAdapter(commands[1], connection);
            postavshikAllAdapter = new SqlDataAdapter(commands[2], connection);
            bludaAdapter.Fill(bluda);
            postavshikAnyAdapter.Fill(postavshikAny);
            postavshikAllAdapter.Fill(postavshikAll);
            relations = new[] { new DataRelation("bludapostavshikAny", bluda.Columns[0], postavshikAny.Columns[0]),
            new DataRelation("bludapostavshikAll", bluda.Columns[0], postavshikAll.Columns[0])};
            dataSet.Relations.AddRange(relations);

            bludabinding = new BindingSource();
            bludabinding.DataSource = bluda;
            comboBox1.DataSource = bludabinding;
            comboBox1.DisplayMember = "bludo";
            comboBox1.ValueMember = "bl";

            postavshikAnybinding = new BindingSource();
            postavshikAnybinding.DataSource = bludabinding;
            postavshikAnybinding.DataMember = "bludapostavshikAny";
            AnyBox.DataSource = postavshikAnybinding;
            AnyBox.DisplayMember = "nazvanie";

            postavshikAllbinding = new BindingSource();
            postavshikAllbinding.DataSource = bludabinding;
            postavshikAllbinding.DataMember = "bludapostavshikAll";
            AllBox.DataSource = postavshikAllbinding;
            AllBox.DisplayMember = "nazvanie";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
