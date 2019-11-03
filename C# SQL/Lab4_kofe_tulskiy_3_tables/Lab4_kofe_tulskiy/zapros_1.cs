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
	public partial class zapros_1 : Form
	{
		SqlConnection connection = new SqlConnection();
		SqlCommand command = new SqlCommand();

		public zapros_1()
		{
			InitializeComponent();
		}

		private void zapros_1_Load(object sender, EventArgs e)
		{
			connection.ConnectionString = Properties.Settings.Default.connection;
			command.Connection = connection;
			command.CommandType = CommandType.Text;
			command.CommandText = "select (select name_ from Postavshik where idp = Post.idp) as name_ from Post" +
				" group by idp order by name_";
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
				comboBox1.Items.Add(reader[0].ToString());
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
			string idp;
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
			command.Connection = connection;
			command.CommandType = CommandType.Text;
			command.CommandText = "select isnull((select idp from Postavshik where name_ = @name_),-1)";
			command.Parameters.Add("@name_", SqlDbType.VarChar);
			command.Parameters["@name_"].Value = comboBox1.Text.Trim();
			idp = command.ExecuteScalar().ToString();
			command.Parameters.Clear();
			command.CommandText = "select convert(varchar, dd, 104), sum(ss), count(idp) from Post " +
				"where idp = @idp group by dd";
			command.Parameters.Add("@idp", SqlDbType.Int);
			command.Parameters["@idp"].Value = idp;
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
