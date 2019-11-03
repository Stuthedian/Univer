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
    public partial class Sotrudnik : Form
    {
        const string table_name = " Sotrudnik ", table_key = " cod_sotr ";
        SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString);
        SqlCommand Selectcommand, Deletecommand, Checkcommand;
        public Sotrudnik()
        {
            InitializeComponent();
        }

        private void buttons()
        {
            if (dataGridView1.Rows.Count == 0)
                Editbutton.Enabled = Delbutton.Enabled = false;
            else
                Editbutton.Enabled = Delbutton.Enabled = true;
        }

        private void Sotrudnik_Load(object sender, EventArgs e)
        {
            Selectcommand = new SqlCommand("select * from " + table_name + "", connection);
            Deletecommand = new SqlCommand("delete from " + table_name + "where " + table_key + "= @cod", connection);
            Deletecommand.Parameters.Add("@cod", SqlDbType.Int);
            Checkcommand = new SqlCommand("select count(*) from Zapis " +
                "where " + table_key + " = @cod", connection);
            Checkcommand.Parameters.Add("@cod", SqlDbType.Int);
            try
            { connection.Open(); }
            catch
            { MessageBox.Show("Нет соединения"); Close(); return; }
            SqlDataReader reader = Selectcommand.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader[0].ToString(), reader[1].ToString(),
                        reader[2].ToString(), reader[3].ToString(),
                        (DateTime.Parse(reader[4].ToString())).ToShortDateString(), reader[5].ToString());
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
            buttons();
        }

        private void Exitbutton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Delbutton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить?", "Внимание", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //throw new NotImplementedException();
                try
                { connection.Open(); }
                catch
                { MessageBox.Show("Нет соединения"); Close(); return; }
                try
                {
                    Checkcommand.Parameters["@cod"].Value = dataGridView1.CurrentRow.Cells[table_key.Trim()].Value.ToString();
                    if (int.Parse(Checkcommand.ExecuteScalar().ToString()) > 0)
                    {
                        MessageBox.Show("Удаление не возможно. Присутствуют записи с данным сотрудником.");
                        connection.Close();
                        return;
                    }
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); Close(); connection.Close(); return; }
                connection.Close();
                try
                { connection.Open(); }
                catch
                { MessageBox.Show("Нет соединения"); Close(); return; }
                try
                {
                    Deletecommand.Parameters["@cod"].Value = dataGridView1.CurrentRow.Cells[table_key.Trim()].Value.ToString();
                    Deletecommand.ExecuteNonQuery();
                    dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); Close(); connection.Close(); return; }
                connection.Close();
                buttons();
            }
        }

        private void Addbutton_Click(object sender, EventArgs e)
        {
            new SotrudnikEdit(true, dataGridView1).ShowDialog();
            buttons();
        }

        private void Editbutton_Click(object sender, EventArgs e)
        {
            new SotrudnikEdit(false, dataGridView1).ShowDialog();
            buttons();
        }
    }
}
