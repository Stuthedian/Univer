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
    public partial class button2_Form : Form
    {
        DataSet dataSet;
        DataTable produkt, bludo;
        SqlDataAdapter produktAdapter, bludoAdapter;
        DataRelation produktbludo;
        BindingSource produktbinding, bludobinding;
        SqlConnection connection = new SqlConnection(Properties.Settings.Default.pansion_metodConnectionString);
        public button2_Form()
        {
            InitializeComponent();
        }

        private void button2_Form_Load(object sender, EventArgs e)
        {
            string[] commands = { "SELECT pr, produkt FROM produkt",
                "SELECT bluda.bludo, sostav.pr FROM bluda INNER JOIN sostav ON bluda.bl = sostav.bl" };
            dataSet = new DataSet();
            produkt = new DataTable();
            bludo = new DataTable();
            dataSet.Tables.Add(produkt);
            dataSet.Tables.Add(bludo);
            produktAdapter = new SqlDataAdapter(commands[0], connection);
            bludoAdapter = new SqlDataAdapter(commands[1], connection);
            produktAdapter.Fill(produkt);
            bludoAdapter.Fill(bludo);
            produktbludo = new DataRelation("produktbludo", produkt.Columns[0], bludo.Columns[1]);
            dataSet.Relations.Add(produktbludo);

            produktbinding = new BindingSource();
            produktbinding.DataSource = produkt;
            comboBox1.DataSource = produktbinding;
            comboBox1.DisplayMember = "produkt";

            bludobinding = new BindingSource();
            bludobinding.DataSource = produktbinding;
            bludobinding.DataMember = "produktbludo";
            listBox1.DataSource = bludobinding;
            listBox1.DisplayMember = "bludo";
        }
    }
}
