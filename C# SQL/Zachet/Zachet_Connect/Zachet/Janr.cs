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
    public partial class Janr : Form
    {
        const string table_name = " Janr ", table_key = " cod_janr ";
        SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString);
        SqlCommand Selectcommand, Deletecommand, Checkcommand;
        public Janr()
        {
            InitializeComponent();
        }

        private void buttons()
        {
            if(listBox1.Items.Count == 0)
                Editbutton.Enabled = Delbutton.Enabled = false;
            else
                Editbutton.Enabled = Delbutton.Enabled = true;
        }

        private void Janr_Load(object sender, EventArgs e)
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
                    listBox1.Items.Add(new ListItem()
                    { Cod = reader[0].ToString(), Value = reader[1].ToString() });
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
            listBox1.DisplayMember = "Value";
            //listBox1.ValueMember = "Cod";
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
                    Checkcommand.Parameters["@cod"].Value = ((ListItem)listBox1.SelectedItem).Cod.ToString();
                    if (int.Parse(Checkcommand.ExecuteScalar().ToString()) > 0)
                    {
                        MessageBox.Show("Удаление не возможно. Присутствуют записи с данным жанром.");
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
                    Deletecommand.Parameters["@cod"].Value = ((ListItem)listBox1.SelectedItem).Cod.ToString();
                    Deletecommand.ExecuteNonQuery();
                    listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); Close(); connection.Close(); return; }
                connection.Close();
                buttons();
            }
        }

        private void Addbutton_Click(object sender, EventArgs e)
        {
            new JanrEdit(true, listBox1).ShowDialog();
            buttons();
        }

        private void Editbutton_Click(object sender, EventArgs e)
        {
            new JanrEdit(false, listBox1).ShowDialog();
            buttons();
        }
    }
}
