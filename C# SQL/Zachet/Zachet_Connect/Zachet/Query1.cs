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

namespace Zachet
{
    public partial class Query1 : Form
    {
        SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString);
        BindingList<ListItem> IspBinding = new BindingList<ListItem>();
        SqlCommand SelectIsp, Querycommand;
        public Query1()
        {
            InitializeComponent();
        }

        private void Query1_Load(object sender, EventArgs e)
        {
            SelectIsp = new SqlCommand("select * from Ispolnitel", connection);
            Querycommand = new SqlCommand(this.Name, connection);
            Querycommand.CommandType = CommandType.StoredProcedure;
            Querycommand.Parameters.Add("@cod", SqlDbType.Int);
            try
            { connection.Open(); }
            catch
            { MessageBox.Show("Нет соединения"); Close(); return; }
            SqlDataReader reader = SelectIsp.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    IspBinding.Add(new ListItem() { Cod = reader[0].ToString(), Value = reader[1].ToString() });
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                connection.Close();
                Close();
                return;
            }
            reader.Close();
            connection.Close();
            comboBox1.DisplayMember = "Value";
            comboBox1.ValueMember = "Cod";
            comboBox1.DataSource = IspBinding;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            { connection.Open(); }
            catch
            { MessageBox.Show("Нет соединения"); Close(); return; }
            Querycommand.Parameters["@cod"].Value = comboBox1.SelectedValue.ToString();
            SqlDataReader reader = Querycommand.ExecuteReader();
            try
            {
                listBox1.Items.Clear();
                while (reader.Read())
                {
                    listBox1.Items.Add(reader[0].ToString());
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                connection.Close();
                Close();
                return;
            }
            reader.Close();
            connection.Close();
        }
    }
}
