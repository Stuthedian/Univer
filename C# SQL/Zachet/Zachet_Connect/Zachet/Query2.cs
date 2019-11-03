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
    public partial class Query2 : Form
    {
        SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString);
        SqlCommand Querycommand;
        public Query2()
        {
            InitializeComponent();
        }

        private void Query2_Load(object sender, EventArgs e)
        {
            Querycommand = new SqlCommand(this.Name, connection);
            Querycommand.CommandType = CommandType.StoredProcedure;
            Querycommand.Parameters.Add("@d1", SqlDbType.Date);
            Querycommand.Parameters.Add("@d2", SqlDbType.Date);
            dateTimePicker1.Value = DateTime.Today;            
            //dateTimePicker2.MinDate = dateTimePicker1.Value;
        }

        private void refresh_grid()
        {
            try
            { connection.Open(); }
            catch
            { MessageBox.Show("Нет соединения"); Close(); return; }
            Querycommand.Parameters["@d1"].Value = dateTimePicker1.Value.ToShortDateString();
            Querycommand.Parameters["@d2"].Value = dateTimePicker2.Value.ToShortDateString();
            SqlDataReader reader = Querycommand.ExecuteReader();
            try
            {
                dataGridView1.Rows.Clear();
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader[0].ToString(), DateTime.Parse(reader[1].ToString()).ToShortDateString(), 
                        reader[2].ToString(),reader[3].ToString(), reader[4].ToString());
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.MinDate = dateTimePicker1.Value;
            refresh_grid();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            refresh_grid();
        }
    }
}
