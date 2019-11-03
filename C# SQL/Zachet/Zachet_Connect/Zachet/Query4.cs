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
    public partial class Query4 : Form
    {
        SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString);
        SqlCommand Querycommand;
        public Query4()
        {
            InitializeComponent();
        }

        private void Query4_Load(object sender, EventArgs e)
        {
            Querycommand = new SqlCommand(this.Name, connection);
            Querycommand.CommandType = CommandType.StoredProcedure;
            Querycommand.Parameters.Add("@count_max", SqlDbType.Int);
            Querycommand.Parameters["@count_max"].Direction = ParameterDirection.Output;
            try
            { connection.Open(); }
            catch
            { MessageBox.Show("Нет соединения"); Close(); return; }
            SqlDataReader reader = Querycommand.ExecuteReader();
            try
            {
                listBox1.Items.Clear();
                while (reader.Read())
                {
                    listBox1.Items.Add(reader[0].ToString());
                }
                reader.Close();
                Querycommand.ExecuteNonQuery();
                //MessageBox.Show(Querycommand.Parameters["@count_max"].Value.ToString());
                label2.Text += Querycommand.Parameters["@count_max"].Value.ToString();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                connection.Close();
                Close();
                return;
            }
            //reader.Close();
            connection.Close();
        }
    }
}
