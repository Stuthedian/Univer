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
	public partial class vvod : Form
	{
		bool is_insert = true;
		SqlConnection connection = new SqlConnection();
		SqlCommand command = new SqlCommand();
		public vvod()
		{
			InitializeComponent();
		}

		private void vvod_Load(object sender, EventArgs e)
		{
			#region DataGridView
			connection.ConnectionString = Properties.Settings.Default.connection;
			command.Connection = connection;
			command.CommandType = CommandType.StoredProcedure;
			command.CommandText = "all_post";
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
					dataGridView1.Rows.Add(reader[0].ToString(), reader[1].ToString(), 
						reader[2].ToString(), reader[3].ToString(), reader[4].ToString());
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
			#endregion
			#region ComboBox_postavshik
			command.CommandText = "all_postavshik";
			reader = command.ExecuteReader();
			try
			{
				while (reader.Read())
				{
					comboBox_postavshik.Items.Add(reader[1].ToString());
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
			if (comboBox_postavshik.Items.Count != 0)
			{
				comboBox_postavshik.SelectedIndex = 0;
			}
			else
			{
				MessageBox.Show("Отсутствуют доступные поставщики!");
				connection.Close();
				Close();
				return;
				//comboBox_postavshik.Text = "";
			}
			#endregion
			#region ComboBox_tovar
			command.CommandText = "all_tovar";
			reader = command.ExecuteReader();
			try
			{
				while (reader.Read())
				{
					comboBox_tovar.Items.Add(reader[1].ToString());
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
			if (comboBox_tovar.Items.Count != 0)
			{
				comboBox_tovar.SelectedIndex = 0;
			}
			else
			{
				MessageBox.Show("Отсутствуют доступные товары!");
				connection.Close();
				Close();
				return;
				//comboBox_tovar.Text = "";
			}
			#endregion
			connection.Close();
			panel1.Enabled = false;
			if (dataGridView1.Rows.Count == 0)
			{
				Edit_button.Enabled = false;
				Delete_button.Enabled = false;
			}
		}

		private void Add_button_Click(object sender, EventArgs e)
		{
			is_insert = true;
			panel1.Enabled = true;
			textBox1.Text = "";
			dateTimePicker1.Value = DateTime.Today;
			comboBox_postavshik.SelectedIndex = 0;
			comboBox_tovar.SelectedIndex = 0;
			panel2.Enabled = false;
			dataGridView1.Enabled = false;
		}

		private void Edit_button_Click(object sender, EventArgs e)
		{
			is_insert = false;
			comboBox_postavshik.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
			comboBox_tovar.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
			textBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
			dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
			panel1.Enabled = true;
			panel2.Enabled = false;
			dataGridView1.Enabled = false;
		}

		private void Delete_button_Click(object sender, EventArgs e)
		{

			DialogResult result = MessageBox.Show("Удалить?", "Удаление", MessageBoxButtons.YesNo);
			if (DialogResult.Yes == result)
			{
				command.CommandText = "del_post";
				command.Parameters.Add("@np", SqlDbType.Int);
				command.Parameters["@np"].Value = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
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
		
		private void Save_button_Click(object sender, EventArgs e)
		{
			if (comboBox_postavshik.Text.Trim() == "")
			{
				MessageBox.Show("Не введено наименование поставщика");
				comboBox_postavshik.Focus();
				return;
			}
			if (comboBox_tovar.Text.Trim() == "")
			{
				MessageBox.Show("Не введено наименование товара");
				comboBox_tovar.Focus();
				return;
			}
			if (textBox1.Text.Trim() == "")
			{
				MessageBox.Show("Не задан объем поставки");
				textBox1.Focus();
				return;
			}
			if (is_insert)
			{
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
				string np = "", idp = "", idt = "";
				#region idp
				command.CommandText = "idp_post";
				command.Parameters.Add("@name", SqlDbType.VarChar);
				command.Parameters["@name"].Value = comboBox_postavshik.Text.Trim();
				idp = command.ExecuteScalar().ToString();
				command.Parameters.Clear();
				#endregion
				#region idt
				command.CommandText = "idt_post";
				command.Parameters.Add("@name", SqlDbType.VarChar);
				command.Parameters["@name"].Value = comboBox_tovar.Text.Trim();
				idt = command.ExecuteScalar().ToString();
				command.Parameters.Clear();
				#endregion
				command.CommandText = "vvod_post";
                command.Parameters.Add("@np", SqlDbType.Int);
				command.Parameters.Add("@idt", SqlDbType.Int);
				command.Parameters.Add("@idp", SqlDbType.Int);
				command.Parameters.Add("@ss", SqlDbType.Decimal);
				command.Parameters.Add("@dd", SqlDbType.Date);

                command.Parameters["@np"].Direction = ParameterDirection.Output;
				command.Parameters["@idt"].Value = idt;
				command.Parameters["@idp"].Value = idp;
				command.Parameters["@ss"].Value = textBox1.Text;
				command.Parameters["@dd"].Value = dateTimePicker1.Text;
				try
				{
					command.ExecuteNonQuery();
                    np = command.Parameters["@np"].Value.ToString();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
					connection.Close();
					command.Parameters.Clear();
					//Close();
					return;
				}
				connection.Close();
				dataGridView1.Rows.Add(np, comboBox_tovar.Text, comboBox_postavshik.Text,
					textBox1.Text, dateTimePicker1.Value.ToShortDateString());
				dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[1];
				command.Parameters.Clear();
				textBox1.Text = "";
				dateTimePicker1.Value = DateTime.Today;
			}
			else
			{
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
				string idp = "", idt = "";
                #region idp
                command.Parameters.Clear();
                command.CommandText = "idp_post";
                command.Parameters.Add("@name", SqlDbType.VarChar);
                command.Parameters["@name"].Value = comboBox_postavshik.Text.Trim();
                idp = command.ExecuteScalar().ToString();
                command.Parameters.Clear();
                #endregion
                #region idt
                command.CommandText = "idt_post";
                command.Parameters.Add("@name", SqlDbType.VarChar);
                command.Parameters["@name"].Value = comboBox_tovar.Text.Trim();
                idt = command.ExecuteScalar().ToString();
                command.Parameters.Clear();
                #endregion
                command.CommandText = "update_post";
				command.Parameters.Add("@np", SqlDbType.Int);
				command.Parameters.Add("@idt", SqlDbType.Int);
				command.Parameters.Add("@idp", SqlDbType.Int);
				command.Parameters.Add("@ss", SqlDbType.Decimal);
				command.Parameters.Add("@dd", SqlDbType.Date);

				command.Parameters["@np"].Value = dataGridView1.CurrentRow.Cells[0].Value.ToString();
				command.Parameters["@idt"].Value = idt;
				command.Parameters["@idp"].Value = idp;
				command.Parameters["@ss"].Value = textBox1.Text;
				command.Parameters["@dd"].Value = dateTimePicker1.Text;
				try
				{
					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
					connection.Close();
					//Close();
					return;
				}
				connection.Close();
				dataGridView1.CurrentRow.Cells[1].Value = comboBox_tovar.Text;
				dataGridView1.CurrentRow.Cells[2].Value = comboBox_postavshik.Text;
				dataGridView1.CurrentRow.Cells[3].Value = textBox1.Text;
				dataGridView1.CurrentRow.Cells[4].Value = dateTimePicker1.Value.ToShortDateString();
				command.Parameters.Clear();
			}
			panel1.Enabled = false;
			panel2.Enabled = true;
			dataGridView1.Enabled = true;
			if (dataGridView1.Rows.Count > 0)
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
		
		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			if (textBox1.Text.Trim() != "") 
			{ 
				if (textBox1.Text.Trim() == "-")
				{
					MessageBox.Show("Число отрицательное");
					textBox1.Text = "";
					textBox1.Focus();
					return;
				}
				bool is_double;
                double nn;
				is_double = double.TryParse(textBox1.Text, out nn);
				if (!is_double)
				{
					MessageBox.Show("Не число");
					textBox1.Text = "";
					textBox1.Focus();
					return;
				}
			}
		}

	}
}
