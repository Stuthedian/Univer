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
    public partial class SotrudnikEdit : Form
    {
        bool is_insert;
        const string table_name = " Sotrudnik ", table_key = " cod_sotr ";
        string Famoriginal;
        string Imoriginal;
        string Otchoriginal;
        DateTime Droriginal;
        char Poloriginal;
        DataGridView dataGridView;
        SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString);
        SqlCommand Insertcommand, Updatecommand, Getidentitycommand, Checkcommand;
        public SotrudnikEdit(bool v, DataGridView view)
        {
            InitializeComponent();
            dataGridView = view;
            DataGridViewRow dataGridViewRow = view.CurrentRow;
            is_insert = v;
            if (is_insert)
            {
                FamBox.Text = ImBox.Text = OtchBox.Text = "";
                comboBox1.SelectedIndex = 0;
            }
            else
            {
                Famoriginal = FamBox.Text = dataGridViewRow.Cells["fam"].Value.ToString();
                Imoriginal = ImBox.Text = dataGridViewRow.Cells["im"].Value.ToString();
                Otchoriginal = OtchBox.Text = dataGridViewRow.Cells["otch"].Value.ToString();
                Droriginal = dateTimePicker1.Value = DateTime.Parse(dataGridViewRow.Cells["dr"].Value.ToString());
                Poloriginal = dataGridViewRow.Cells["pol"].Value.ToString()[0];
                comboBox1.SelectedIndex = (Poloriginal == 'м' ? 0 : 1);
            }         
        }

        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Savebutton_Click(object sender, EventArgs e)
        {
            if(FamBox.Text.Trim() == "")
            {
                MessageBox.Show("Не введена фамилия сотрудника");
                return;
            }
            if (ImBox.Text.Trim() == "")
            {
                MessageBox.Show("Не введено имя сотрудника");
                return;
            }
            try
            { connection.Open(); }
            catch
            { MessageBox.Show("Нет соединения"); Close(); return; }
            try
            {
                if (is_insert || (Famoriginal != FamBox.Text.Trim() || Imoriginal != ImBox.Text.Trim()
                    || Otchoriginal != OtchBox.Text.Trim() || Droriginal != dateTimePicker1.Value
                    || comboBox1.SelectedItem.ToString()[0] != Poloriginal))
                {
                    Checkcommand.Parameters["@fam"].Value = FamBox.Text.Trim();
                    Checkcommand.Parameters["@im"].Value = ImBox.Text.Trim();
                    Checkcommand.Parameters["@otch"].Value = OtchBox.Text.Trim();
                    Checkcommand.Parameters["@dr"].Value = dateTimePicker1.Value.ToShortDateString();
                    Checkcommand.Parameters["@pol"].Value = comboBox1.SelectedItem.ToString()[0];
                    if (int.Parse(Checkcommand.ExecuteScalar().ToString()) > 0)
                    {
                        MessageBox.Show("Сотрудник с такими данными уже существует");
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
                    Insertcommand.Parameters["@fam"].Value = FamBox.Text.Trim();
                    Insertcommand.Parameters["@im"].Value = ImBox.Text.Trim();
                    Insertcommand.Parameters["@otch"].Value = OtchBox.Text.Trim();
                    Insertcommand.Parameters["@dr"].Value = dateTimePicker1.Value.ToShortDateString();
                    Insertcommand.Parameters["@pol"].Value = comboBox1.SelectedItem.ToString()[0];
                    Insertcommand.ExecuteNonQuery();
                    dataGridView.Rows.Add(Getidentitycommand.ExecuteScalar(), FamBox.Text.Trim(),
                        ImBox.Text.Trim(), OtchBox.Text.Trim(), dateTimePicker1.Value,
                        comboBox1.SelectedItem.ToString()[0]);
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); Close(); connection.Close(); return; }
            }
            else
            {
                try
                {
                    Updatecommand.Parameters["@cod"].Value = dataGridView.CurrentRow.Cells[table_key.Trim()].Value.ToString();
                    Updatecommand.Parameters["@fam"].Value = FamBox.Text.Trim();
                    Updatecommand.Parameters["@im"].Value = ImBox.Text.Trim();
                    Updatecommand.Parameters["@otch"].Value = OtchBox.Text.Trim();
                    Updatecommand.Parameters["@dr"].Value = dateTimePicker1.Value.ToShortDateString();
                    Updatecommand.Parameters["@pol"].Value = comboBox1.SelectedItem.ToString()[0];
                    Updatecommand.ExecuteNonQuery();
                    dataGridView.CurrentRow.Cells["fam"].Value = FamBox.Text.Trim();
                    dataGridView.CurrentRow.Cells["im"].Value = ImBox.Text.Trim();
                    dataGridView.CurrentRow.Cells["otch"].Value = OtchBox.Text.Trim();
                    dataGridView.CurrentRow.Cells["dr"].Value = dateTimePicker1.Value;
                    dataGridView.CurrentRow.Cells["pol"].Value = comboBox1.SelectedItem.ToString()[0];
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); Close(); connection.Close(); return; }
            }
            connection.Close();
            Close();
            
        }

        private void SotrudnikEdit_Load(object sender, EventArgs e)
        {
            Insertcommand = new SqlCommand("insert into " + table_name + " values " +
                "(@fam, @im, @otch, @dr, @pol)", connection);
            Insertcommand.Parameters.Add("@fam", SqlDbType.VarChar);
            Insertcommand.Parameters.Add("@im", SqlDbType.VarChar);
            Insertcommand.Parameters.Add("@otch", SqlDbType.VarChar);
            Insertcommand.Parameters.Add("@dr", SqlDbType.Date);
            Insertcommand.Parameters.Add("@pol", SqlDbType.VarChar);
            Updatecommand = new SqlCommand("update " + table_name 
                + " set fam = @fam, im = @im, otch = @otch, dr = @dr, pol = @pol " +
                "where " + table_key + " = @cod", connection);
            Updatecommand.Parameters.Add("@cod", SqlDbType.Int);
            Updatecommand.Parameters.Add("@fam", SqlDbType.VarChar);
            Updatecommand.Parameters.Add("@im", SqlDbType.VarChar);
            Updatecommand.Parameters.Add("@otch", SqlDbType.VarChar);
            Updatecommand.Parameters.Add("@dr", SqlDbType.Date);
            Updatecommand.Parameters.Add("@pol", SqlDbType.VarChar);
            //Getidentitycommand = new SqlCommand("SELECT IDENT_CURRENT('"+table_name+"')", connection);
            Getidentitycommand = new SqlCommand("SELECT @@IDENTITY", connection);
            Checkcommand = new SqlCommand("select count(*) from " + table_name +
                "where fam = @fam and im = @im and otch = @otch and " +
                " dr = @dr and pol = @pol", connection);
            Checkcommand.Parameters.Add("@fam", SqlDbType.VarChar);
            Checkcommand.Parameters.Add("@im", SqlDbType.VarChar);
            Checkcommand.Parameters.Add("@otch", SqlDbType.VarChar);
            Checkcommand.Parameters.Add("@dr", SqlDbType.Date);
            Checkcommand.Parameters.Add("@pol", SqlDbType.VarChar);
        }
    }
}
