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
	public partial class zapros_2 : Form
	{
		SqlConnection connection = new SqlConnection();
		SqlCommand command = new SqlCommand();

		public zapros_2()
		{
			InitializeComponent();
		}

		private void zapros_2_Load(object sender, EventArgs e)
		{
			connection.ConnectionString = Properties.Settings.Default.connection;
			command.Connection = connection;
			command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "all_tovar";
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
			try
			{
				while (reader.Read())
				{
					comboBox1.Items.Add(reader[1].ToString());
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				connection.Close();
				Close();
				return;
			}
			reader.Close();
			connection.Close();
			if (comboBox1.Items.Count != 0)
			{
				comboBox1.SelectedIndex = 0;
			}
			else
			{
				comboBox1.Text = "";
			}
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			string idt = "";
			dataGridView1.Rows.Clear();
			connection.ConnectionString = Properties.Settings.Default.connection;
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
			command.CommandText = "Zad2";
			command.Parameters.Add("@name", SqlDbType.VarChar);
			command.Parameters["@name"].Value = comboBox1.Text.Trim();
			SqlDataReader reader = command.ExecuteReader();
			while (reader.Read())
			{
				dataGridView1.Rows.Add(reader[0].ToString(), reader[1].ToString(), reader[2].ToString());
			}
			reader.Close();
			connection.Close();
			command.Parameters.Clear();
		}
	}
}
