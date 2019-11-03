using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3_Pansionat
{
    public partial class button1_Form : Form
    {
        DataSet dataSet;
        DataTable postavshik, gorod, produkt;
        SqlDataAdapter postavshikAdapter, gorodAdapter, produktAdapter;
        DataRelation[] relations;
        BindingSource gorodbinding, postavshikbinding, produktbinding;
        SqlConnection connection = new SqlConnection(Properties.Settings.Default.pansion_metodConnectionString);
        
        public button1_Form()
        {
            InitializeComponent();
        }

        private void button1_Form_Load(object sender, EventArgs e)
        {
            string[] commands = {"SELECT pc, gorod, nazvanie FROM postavshiki",
                "SELECT distinct gorod FROM postavshiki",
                "SELECT postavki.pc, produkt.produkt, SUM(postavki.kol) AS k FROM postavki INNER JOIN produkt ON postavki.pr = produkt.pr GROUP BY postavki.pc, produkt.produkt",
                "select count(pc) from postavshiki"};
            dataSet = new DataSet();
            postavshik = new DataTable();
            gorod = new DataTable();
            produkt = new DataTable();
            dataSet.Tables.Add(postavshik);
            dataSet.Tables.Add(gorod);
            dataSet.Tables.Add(produkt);
            postavshikAdapter = new SqlDataAdapter(commands[0], connection);
            gorodAdapter = new SqlDataAdapter(commands[1], connection);
            produktAdapter = new SqlDataAdapter(commands[2], connection);
            postavshikAdapter.Fill(postavshik);
            gorodAdapter.Fill(gorod);
            produktAdapter.Fill(produkt);
            relations = new[] { new DataRelation("gorodpostavshik", gorod.Columns[0], postavshik.Columns[1]),
            new DataRelation("postavshikprodukt", postavshik.Columns[0], produkt.Columns[0])};
            dataSet.Relations.AddRange(relations);
            try
            {
                connection.Open();
                label1.Text += new SqlCommand(commands[3], connection).ExecuteScalar().ToString();
                connection.Close();
            }
            catch (Exception)
            { 
                throw;
            }
            gorodbinding = new BindingSource();
            gorodbinding.DataSource = gorod;
            comboBox1.DataSource = gorodbinding;
            comboBox1.DisplayMember = "gorod";

            postavshikbinding = new BindingSource();
            postavshikbinding.DataSource = gorodbinding;
            postavshikbinding.DataMember = "gorodpostavshik";
            listBox1.DataSource = postavshikbinding;
            listBox1.DisplayMember = "nazvanie";
            
            produktbinding = new BindingSource();
            produktbinding.DataSource = postavshikbinding;
            produktbinding.DataMember = "postavshikprodukt";
            dataGridView1.DataSource = produktbinding;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Продукт";
            dataGridView1.Columns[2].HeaderText = "Суммарное количество";
        }
    }
}
