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
    public partial class Query3 : Form
    {
        DataSet1 dataSet1;
        DataView trapezidataView = new DataView();
        DataView vid_bluddataView = new DataView();
        DataView menudataView = new DataView();
        bool loaded = false;
        public Query3(DataSet1 data)
        {
            InitializeComponent();
            dataSet1 = data;
        }

        private void Query3_Load(object sender, EventArgs e)
        {
            trapezidataView.Table = dataSet1.trapezi;
            vid_bluddataView.Table = dataSet1.vid_blud;
            menudataView.Table = dataSet1.menu;
            if (!menudataView.Table.Columns.Contains("bludo"))
                menudataView.Table.Columns.Add("bludo", typeof(System.String), "parent(bluda_menu).bludo");
            TrapezBox.DataSource = trapezidataView;
            TrapezBox.DisplayMember = "trapeza";
            TrapezBox.ValueMember = "t";
            VidbludBox.DataSource = vid_bluddataView;
            VidbludBox.DisplayMember = "vid";
            VidbludBox.ValueMember = "b";
            listBox1.DataSource = menudataView;
            listBox1.DisplayMember = "bludo";
            menudataView.RowFilter = "t='" + TrapezBox.SelectedValue
                + "' and b='" + VidbludBox.SelectedValue + "'";
            loaded = true;
        }

        private void TrapezBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loaded)
                menudataView.RowFilter = "t='" + TrapezBox.SelectedValue
                + "' and b='" + VidbludBox.SelectedValue + "'";
        }

        private void VidbludBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loaded)
                menudataView.RowFilter = "t='" + TrapezBox.SelectedValue
                + "' and b='" + VidbludBox.SelectedValue + "'";
        }
    }
}
