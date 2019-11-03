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
			command.CommandType = CommandType.Text;
			command.CommandText = "select (select name_ from Tovar where idt = Post.idt) as name_ from Post" +
				" group by idt order by name_";
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
					comboBox1.Items.Add(reader[0].ToString());
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
			command.Connection = connection;
			command.CommandType = CommandType.Text;
			command.CommandText = "select isnull((select idt from Tovar where name_ = @name_),-1)";
			command.Parameters.Add("@name_", SqlDbType.VarChar);
			command.Parameters["@name_"].Value = comboBox1.Text.Trim();
			idt = command.ExecuteScalar().ToString();
			command.Parameters.Clear();
			command.CommandText = "select datename(month, dateadd(month,months.st1,-1)), isnull(sum(ss),0), count(idt) from " +
				"(select * from Post where idt = @idt) as Post right join " +
				"((select 1 as st1 union select 2 union select 3 union select 4 union select 5 union select 6 " +
				"union select 7 union select 8 union select 9 union select 10 union select 11 union select 12)) as months " +
				"on months.st1 = month(Post.dd) group by months.st1";
			command.Parameters.Add("@idt", SqlDbType.Int);
			command.Parameters["@idt"].Value = idt;
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
