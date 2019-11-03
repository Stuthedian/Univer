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
    public partial class button3_Form : Form
    {
        DataSet dataSet;
        DataTable trapeza, vid_blud, bludo;
        SqlDataAdapter trapezaAdapter, vid_bludAdapter, bludoAdapter;
        DataRelation vid_bludbludo;
        BindingSource trapezabinding, vid_bludbinding, bludobinding;
        SqlConnection connection = new SqlConnection(Properties.Settings.Default.pansion_metodConnectionString);
        public button3_Form()
        {
            InitializeComponent();
        }

        private void button3_Form_Load(object sender, EventArgs e)
        {
            string[] commands = { "SELECT trapezi.* FROM trapezi",
            "SELECT vid_blud.* FROM vid_blud",
            "SELECT menu.t, menu.b, bluda.bludo FROM menu INNER JOIN bluda ON menu.bl = bluda.bl"};
            dataSet = new DataSet();
            trapeza = new DataTable();
            vid_blud = new DataTable();
            bludo = new DataTable();
            dataSet.Tables.Add(trapeza);
            dataSet.Tables.Add(vid_blud);
            dataSet.Tables.Add(bludo);
            trapezaAdapter = new SqlDataAdapter(commands[0], connection);
            vid_bludAdapter = new SqlDataAdapter(commands[1], connection);
            bludoAdapter = new SqlDataAdapter(commands[2], connection);
            trapezaAdapter.Fill(trapeza);
            vid_bludAdapter.Fill(vid_blud);
            bludoAdapter.Fill(bludo);
            vid_bludbludo = new DataRelation("vid_bludbludo", vid_blud.Columns[0], bludo.Columns[1]);
            dataSet.Relations.Add(vid_bludbludo);

            vid_bludbinding = new BindingSource();
            vid_bludbinding.DataSource = vid_blud;
            vidblBox.DataSource = vid_bludbinding;
            vidblBox.DisplayMember = "vid";

            bludobinding = new BindingSource();
            bludobinding.DataSource = vid_bludbinding;
            bludobinding.DataMember = "vid_bludbludo";
            listBox1.DataSource = bludobinding;
            listBox1.DisplayMember = "bludo";
            //if (trapezBox.SelectedValue != null)
            //    bludobinding.Filter = "t=" + trapezBox.SelectedValue;

            trapezabinding = new BindingSource();
            trapezabinding.DataSource = trapeza;
            trapezBox.DataSource = trapezabinding;
            trapezBox.DisplayMember = "trapeza";
            trapezBox.ValueMember = "t";
        }

        private void trapezBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            bludobinding.Filter = "t=" + trapezBox.SelectedValue;
        }
    }
}
