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
    public partial class JanrEdit : Form
    {
        bool is_insert;
        const string table_name = " Janr ", table_key = " cod_janr ";
        string originalName;
        ListBox listBox;
        ListItem listItem;
        SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString);
        SqlCommand Insertcommand, Updatecommand, Getidentitycommand, Checkcommand;
        public JanrEdit(bool v, ListBox box)
        {
            InitializeComponent();
            is_insert = v;
            listBox = box;
            if (is_insert)
            {
                textBox1.Text = "";
            }
            else
            {
                listItem = (ListItem)listBox.SelectedItem;
                textBox1.Text = originalName = listItem.Value.ToString();
            }
        }

        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Savebutton_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Trim() == "")
            {
                MessageBox.Show("Не введено наименование жанра");
                return;
            }
            try
            { connection.Open(); }
            catch
            { MessageBox.Show("Нет соединения"); Close(); return; }
            try
            {
                if (is_insert || (!is_insert && originalName != textBox1.Text.Trim()))
                {
                    Checkcommand.Parameters["@naim"].Value = textBox1.Text.Trim();
                    if (int.Parse(Checkcommand.ExecuteScalar().ToString()) > 0)
                    {
                        MessageBox.Show("Жанр с таким наименованием уже присутствует");
                        connection.Close();
                        return;
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); Close(); connection.Close(); return; }
            connection.Close();
            try
            { connection.Open(); }
            catch
            { MessageBox.Show("Нет соединения"); Close(); return; }
            if (is_insert)
            {
                try
                {
                    Insertcommand.Parameters["@naim"].Value = textBox1.Text.Trim();
                    Insertcommand.ExecuteNonQuery();
                    listBox.Items.Add(new ListItem()
                    {
                        Cod = Getidentitycommand.ExecuteScalar(),
                        Value = textBox1.Text.Trim()
                    });
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); Close(); connection.Close(); return; }
            }
            else
            {
                try
                {
                    Updatecommand.Parameters["@cod"].Value = listItem.Cod.ToString();
                    Updatecommand.Parameters["@naim"].Value = textBox1.Text.Trim();
                    Updatecommand.ExecuteNonQuery();
                    listBox.Items[listBox.SelectedIndex] =
                        new ListItem()
                        {
                            Cod = listItem.Cod.ToString(),
                            Value = textBox1.Text.Trim()
                        };
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); Close(); connection.Close(); return; }
            }
            connection.Close();
            Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                Savebutton_Click(sender, e);
        }

        private void JanrEdit_Load(object sender, EventArgs e)
        {
            Insertcommand = new SqlCommand("insert into " + table_name + " values " +
                "(@naim)", connection);
            Insertcommand.Parameters.Add("@naim", SqlDbType.VarChar);
            Updatecommand = new SqlCommand("update " + table_name + " set naim = @naim " +
                "where " + table_key + " = @cod", connection);
            Updatecommand.Parameters.Add("@cod", SqlDbType.Int);
            Updatecommand.Parameters.Add("@naim", SqlDbType.VarChar);
            //Getidentitycommand = new SqlCommand("SELECT IDENT_CURRENT('" + table_name + "')", connection);
            Getidentitycommand = new SqlCommand("SELECT @@IDENTITY", connection);
            Checkcommand = new SqlCommand("select count(*) from " + table_name +
                "where naim = @naim", connection);
            Checkcommand.Parameters.Add("@naim", SqlDbType.VarChar);
        }
    }
}
