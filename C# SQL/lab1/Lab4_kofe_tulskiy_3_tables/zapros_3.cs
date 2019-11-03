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

namespace Lab4_kofe_tulskiy
{
	public partial class zapros_3 : Form
	{
		SqlConnection connection = new SqlConnection();
		SqlCommand command = new SqlCommand();
		public zapros_3()
		{
			InitializeComponent();
		}

		private void zapros_3_Load(object sender, EventArgs e)
		{
			connection.ConnectionString = Properties.Settings.Default.connection;
			command.Connection = connection;
			command.CommandType = CommandType.StoredProcedure;
			command.CommandText = "Zad3";
			try
			{
				connection.Open();
			}
			catch (Exception)
			{
				MessageBox.Show("Нет соединения");
				Close();
				return;
			}
			SqlDataReader reader = command.ExecuteReader();
			while (reader.Read())
			{
				dataGridView1.Rows.Add(reader[0].ToString(), reader[1].ToString(), 
					reader[2].ToString(), reader[3].ToString());
			}
			reader.Close();
			connection.Close();
		}
	}
}
