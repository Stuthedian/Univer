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
            int kol;
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
            if (is_insert == false && textBox1.Text.Trim() == dataGridView1.CurrentCell.Value.ToString())
            {
                panel1.Enabled = false;
                panel2.Enabled = true;
                dataGridView1.Enabled = true;
                connection.Close();
                return;
            }
            command.Parameters.Clear();
            command.CommandText = "kol_tovar";
            command.Parameters.Add("@name", SqlDbType.VarChar);
            command.Parameters["@name"].Value = textBox1.Text.Trim();
            try
            {
                kol = int.Parse(command.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
                connection.Close();
                return;
            }
            if (kol > 0)
            {
                MessageBox.Show("Товар с данным наименованием уже существует!");
                textBox1.Text = "";
                textBox1.Focus();
                connection.Close();
                command.Parameters.Clear();
                return;
            }
            connection.Close();
            if(is_insert)
            {
                command.Parameters.Clear();
                command.CommandText = "vvod_tovar";
                command.Parameters.Add("@idt", SqlDbType.Int);
                command.Parameters["@idt"].Direction = ParameterDirection.Output;
                command.Parameters.Add("@name", SqlDbType.VarChar);
                command.Parameters["@name"].Value = textBox1.Text.Trim();
                try
                { connection.Open(); }
                catch
                { MessageBox.Show("Нет соединения"); Close(); return; }
                try
                { command.ExecuteNonQuery(); }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); Close(); connection.Close(); return; }
                connection.Close();
                dataGridView1.Rows.Add(command.Parameters["@idt"].Value.ToString(), textBox1.Text);
                textBox1.Text = "";
            }
			else
			{
                command.Parameters.Clear();
                command.CommandText = "update_tovar";
                command.Parameters.Add("@idt", SqlDbType.Int);
                command.Parameters.Add("@name", SqlDbType.VarChar);
                command.Parameters["@idt"].Value = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                command.Parameters["@name"].Value = textBox1.Text;
                connection.Open();
                try
                { command.ExecuteNonQuery(); }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
                connection.Close();
                dataGridView1.CurrentRow.Cells[1].Value = textBox1.Text;
                command.Parameters.Clear();
                textBox1.Text = "";
            }
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
            int kol;
            command.Parameters.Clear();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "kol1_tovar";
            command.Parameters.Add("@idt", SqlDbType.Int);
            command.Parameters["@idt"].Value = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            try
            { connection.Open(); }
            catch
            { MessageBox.Show("Нет соединения"); Close(); return; }
            try
            {
                kol = int.Parse(command.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); Close(); connection.Close(); return; }
            if (kol > 0)
            {
                MessageBox.Show("Удаление не возможно. Есть записи о поставках данного товара");
                connection.Close(); return;
            }
            connection.Close();
            DialogResult result = MessageBox.Show("Удалить?", "Удаление", MessageBoxButtons.YesNo);
			if(result == DialogResult.Yes)
			{
                command.Parameters.Clear();
				command.CommandText = "del_tovar";
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
