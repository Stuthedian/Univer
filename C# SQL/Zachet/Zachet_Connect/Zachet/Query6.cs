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
    public partial class Query6 : Form
    {
        SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString);
        SqlCommand Querycommand;
        public Query6()
        {
            InitializeComponent();

        }

        private void Query6_Load(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            Querycommand = new SqlCommand(this.Name, connection);
            Querycommand.CommandType = CommandType.StoredProcedure;
            try
            { connection.Open(); }
            catch
            { MessageBox.Show("Нет соединения"); Close(); return; }
            SqlDataReader reader = Querycommand.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader[0].ToString(), reader[1].ToString(),
                        reader[2].ToString(), reader[3].ToString(),
                        reader[4].ToString(), reader[5].ToString(),
                        reader[6].ToString(), reader[7].ToString(),
                        reader[8].ToString(), reader[9].ToString(),
                        reader[10].ToString(), reader[11].ToString(),
                        reader[12].ToString());
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
            dataGridView1.AutoResizeRows();
        }
    }
}
