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
	public partial class tovar : Form
	{
		bool is_insert = true;
		SqlConnection connection = new SqlConnection();
		SqlCommand command = new SqlCommand();
		public tovar()
		{
			InitializeComponent();
		}

		private void tovar_Load(object sender, EventArgs e)
		{
			connection.ConnectionString = Properties.Settings.Default.connection;
			command.Connection = connection;
			command.CommandType = CommandType.Text;
			command.CommandText = "select * from Tovar order by name_";
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
			panel1.Enabled = false;
			dataGridView1.Enabled = true;
			if(dataGridView1.Rows.Count == 0)
			{
				Edit_button.Enabled = false;
				Delete_button.Enabled = false;
			}
		}

		private void Save_button_Click(object sender, EventArgs e)
		{
			string idt;
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
			if (textBox1.Text.Trim() == "")
			{
				MessageBox.Show("Не введено наименование товара");
				textBox1.Focus();
				connection.Close();
				return;
			}
			if (is_insert)
				command.CommandText = "select isnull((select idt from Tovar where name_ = @name_),-1)";
			else
			{
				command.CommandText = "select isnull((select idt from Tovar where name_ = @name_ and idt != @idt),-1)";
				command.Parameters.Add("@idt", SqlDbType.Int);
				command.Parameters["@idt"].Value = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
			}
			command.Parameters.Add("@name_", SqlDbType.VarChar);
			command.Parameters["@name_"].Value = textBox1.Text.Trim();
			idt = command.ExecuteScalar().ToString();
			//command.Parameters.Clear();
			if (idt == "-1")
			{
				if(is_insert)
				{
					command.CommandText = "insert into Tovar values (@name_)";
					command.ExecuteNonQuery();
					command.CommandText = "select ident_current('Tovar')";
					idt = command.ExecuteScalar().ToString();
					dataGridView1.Rows.Add(idt, textBox1.Text.Trim());
				}
				else
				{
					command.CommandText = "update Tovar set name_ = @name_ where idt = @idt";
					command.ExecuteNonQuery();
					dataGridView1.CurrentRow.Cells[1].Value = textBox1.Text.Trim();
				}
			}
			else
			{
				MessageBox.Show("Товар с данным наименованием уже существует!");
				textBox1.Text = "";
				textBox1.Focus();
				connection.Close();
				command.Parameters.Clear();
				return;
			}
			connection.Close();
			command.Parameters.Clear();
			panel1.Enabled = false;
			panel2.Enabled = true;
			dataGridView1.Enabled = true;
			if(dataGridView1.Rows.Count > 0)
			{
				Edit_button.Enabled = true;
				Delete_button.Enabled = true;
			}
		}

		private void Cancel_button_Click(object sender, EventArgs e)
		{
			panel1.Enabled = false;
			panel2.Enabled = true;
			dataGridView1.Enabled = true;
		}

		private void Add_button_Click(object sender, EventArgs e)
		{
			panel2.Enabled = false;
			panel1.Enabled = true;
			dataGridView1.Enabled = false;
			is_insert = true;
			textBox1.Text = "";
		}

		private void Edit_button_Click(object sender, EventArgs e)
		{
			panel2.Enabled = false;
			panel1.Enabled = true;
			dataGridView1.Enabled = false;
			is_insert = false;
			textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
		}

		private void Delete_button_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("Удалить?", "Удаление", MessageBoxButtons.YesNo);
			if(result == DialogResult.Yes)
			{
				command.CommandText = "delete from Tovar where idt = @idt";
				command.Parameters.Add("@idt", SqlDbType.Int);
				command.Parameters["@idt"].Value = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
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
				try
				{
					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
					connection.Close();
					command.Parameters.Clear();
					Close();
					return;
				}
				connection.Close();
				command.Parameters.Clear();
				dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
				if (dataGridView1.Rows.Count == 0)
				{
					Edit_button.Enabled = false;
					Delete_button.Enabled = false;
				}
			}
		}

		private void Exit_button_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
