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
    public partial class Query3 : Form
    {
        SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString);
        SqlCommand Querycommand;
        public Query3()
        {
            InitializeComponent();
        }

        private void Query3_Load(object sender, EventArgs e)
        {
            Querycommand = new SqlCommand(this.Name, connection);
            Querycommand.CommandType = CommandType.StoredProcedure;
            Querycommand.Parameters.Add("@q", SqlDbType.Int);
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            { connection.Open(); }
            catch
            { MessageBox.Show("Нет соединения"); Close(); return; }
            Querycommand.Parameters["@q"].Value = comboBox1.SelectedItem.ToString();
            SqlDataReader reader = Querycommand.ExecuteReader();
            try
            {
                dataGridView1.Rows.Clear();
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader[0].ToString(), reader[1].ToString());
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
            dataGridView1.AutoResizeColumns();
        }
    }
}
