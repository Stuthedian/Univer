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
    public partial class ZapisEdit : Form
    {
        bool is_insert;
        int[] keys;
        string origstr;
        DateTime origDate;
        DataGridView dataGridView;
        BindingList<ListItem> IspBinding = new BindingList<ListItem>(), JanrBinding = new BindingList<ListItem>(), SotrBinding = new BindingList<ListItem>();
        SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString);
        SqlCommand Insertcommand, Updatecommand, Checkcommand, SelectIsp, SelectJanr, SelectSotr;

        public ZapisEdit(bool v, DataGridView dat)
        {
            InitializeComponent();
            is_insert = v;
            dataGridView = dat;
        }
        public ZapisEdit(bool v, int[] k, string str, DateTime date, DataGridView dat)
        {
            InitializeComponent();
            is_insert = v;
            keys = k;
            dateTimePicker1.Value = origDate = date;
            textBox1.Text = origstr = str;
            dataGridView = dat;
        }

        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Savebutton_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Trim() == "")
            {
                MessageBox.Show("Не введено наименование записи");
                return;
            }
            try
            { connection.Open(); }
            catch
            { MessageBox.Show("Нет соединения"); Close(); return; }
            try
            {
                if(is_insert || (origDate != dateTimePicker1.Value || keys[0] != int.Parse(Ispcombo.SelectedValue.ToString()) 
                    || keys[1] != int.Parse(Janrcombo.SelectedValue.ToString()) 
                    || keys[2] != int.Parse(Sotrcombo.SelectedValue.ToString()) || textBox1.Text.Trim() != origstr))
                {
                    Checkcommand.Parameters["@cod_isp"].Value = Ispcombo.SelectedValue.ToString();
                    Checkcommand.Parameters["@cod_janr"].Value = Janrcombo.SelectedValue.ToString();
                    Checkcommand.Parameters["@cod_sotr"].Value = Sotrcombo.SelectedValue.ToString();
                    Checkcommand.Parameters["@data"].Value = dateTimePicker1.Value.ToShortDateString();
                    Checkcommand.Parameters["@naim_zapis"].Value = textBox1.Text.Trim();
                    if (int.Parse(Checkcommand.ExecuteScalar().ToString()) > 0)
                    {
                        MessageBox.Show("Такая запись уже присутствует");
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
                    Insertcommand.Parameters["@cod_isp"].Value = Ispcombo.SelectedValue.ToString();
                    Insertcommand.Parameters["@cod_janr"].Value = Janrcombo.SelectedValue.ToString();
                    Insertcommand.Parameters["@cod_sotr"].Value = Sotrcombo.SelectedValue.ToString();
                    Insertcommand.Parameters["@data"].Value = dateTimePicker1.Value.ToShortDateString();
                    Insertcommand.Parameters["@naim_zapis"].Value = textBox1.Text.Trim();
                    Insertcommand.ExecuteNonQuery();
                    dataGridView.Rows.Add(Insertcommand.Parameters["@cod"].Value.ToString(),textBox1.Text.Trim(), 
                        dateTimePicker1.Value.ToShortDateString(),
                        Ispcombo.SelectedValue.ToString(), Janrcombo.SelectedValue.ToString(), Sotrcombo.SelectedValue.ToString(),
                        ((ListItem)Ispcombo.SelectedItem).Value.ToString(), ((ListItem)Janrcombo.SelectedItem).Value.ToString(), 
                        ((ListItem)Sotrcombo.SelectedItem).Value.ToString());
                    dataGridView.CurrentCell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["data"];
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); Close(); connection.Close(); return; }
            }
            else
            {
                try
                {
                    Updatecommand.Parameters["@cod_isp"].Value = Ispcombo.SelectedValue.ToString();
                    Updatecommand.Parameters["@cod_janr"].Value = Janrcombo.SelectedValue.ToString();
                    Updatecommand.Parameters["@cod_sotr"].Value = Sotrcombo.SelectedValue.ToString();
                    Updatecommand.Parameters["@cod"].Value = keys[3].ToString().Clone();
                    Updatecommand.Parameters["@data"].Value = dateTimePicker1.Value.ToShortDateString();
                    Updatecommand.Parameters["@naim_zapis"].Value = textBox1.Text.Trim();
                    Updatecommand.ExecuteNonQuery();
                    dataGridView.CurrentRow.Cells["naim_zapis"].Value = textBox1.Text.Trim();
                    dataGridView.CurrentRow.Cells["data"].Value = dateTimePicker1.Value.ToShortDateString();
                    dataGridView.CurrentRow.Cells["cod_isp"].Value = Ispcombo.SelectedValue.ToString();
                    dataGridView.CurrentRow.Cells["cod_janr"].Value = Janrcombo.SelectedValue.ToString();
                    dataGridView.CurrentRow.Cells["cod_sotr"].Value = Sotrcombo.SelectedValue.ToString();
                    dataGridView.CurrentRow.Cells["Isp"].Value = ((ListItem)Ispcombo.SelectedItem).Value.ToString();
                    dataGridView.CurrentRow.Cells["Janr"].Value = ((ListItem)Janrcombo.SelectedItem).Value.ToString();
                    dataGridView.CurrentRow.Cells["Sotr"].Value = ((ListItem)Sotrcombo.SelectedItem).Value.ToString();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); Close(); connection.Close(); return; }
            }
            connection.Close();
            Close();
        }

        private void ZapisEdit_Load(object sender, EventArgs e)
        {
            SelectIsp = new SqlCommand("select * from Ispolnitel", connection);
            SelectJanr = new SqlCommand("select * from Janr", connection);
            SelectSotr = new SqlCommand("select cod_sotr, fam + " +
                "' ' + left(im,1) + '.' + left(otch,1) + '.' from Sotrudnik", connection);
            Insertcommand = new SqlCommand("ins_zap", connection);
            Insertcommand.CommandType = CommandType.StoredProcedure;
            Insertcommand.Parameters.Add("@cod", SqlDbType.Int);
            Insertcommand.Parameters.Add("@naim_zapis", SqlDbType.VarChar);
            Insertcommand.Parameters.Add("@data", SqlDbType.Date);
            Insertcommand.Parameters.Add("@cod_isp", SqlDbType.Int);
            Insertcommand.Parameters.Add("@cod_janr", SqlDbType.Int);
            Insertcommand.Parameters.Add("@cod_sotr", SqlDbType.Int);
            Insertcommand.Parameters["@cod"].Direction = ParameterDirection.Output;
            Checkcommand = new SqlCommand("select count(*) from Zapis where @cod_isp = cod_isp and @cod_janr = cod_janr "
                + " and @cod_sotr = cod_sotr and @data = data and @naim_zapis = naim_zapis", connection);
            Checkcommand.Parameters.Add("@cod_isp", SqlDbType.Int);
            Checkcommand.Parameters.Add("@cod_janr", SqlDbType.Int);
            Checkcommand.Parameters.Add("@cod_sotr", SqlDbType.Int);
            Checkcommand.Parameters.Add("@data", SqlDbType.Date);
            Checkcommand.Parameters.Add("@naim_zapis", SqlDbType.VarChar);
            Updatecommand = new SqlCommand("upd_zap", connection);
            Updatecommand.CommandType = CommandType.StoredProcedure;
            Updatecommand.Parameters.Add("@cod", SqlDbType.Int);
            Updatecommand.Parameters.Add("@cod_isp", SqlDbType.Int);
            Updatecommand.Parameters.Add("@cod_janr", SqlDbType.Int);
            Updatecommand.Parameters.Add("@cod_sotr", SqlDbType.Int);
            Updatecommand.Parameters.Add("@data", SqlDbType.Date);
            Updatecommand.Parameters.Add("@naim_zapis", SqlDbType.VarChar);
            try
            { connection.Open(); }
            catch
            { MessageBox.Show("Нет соединения"); Close(); return; }
            SqlDataReader reader = SelectIsp.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    IspBinding.Add(new ListItem() { Cod = reader[0].ToString(), Value = reader[1].ToString() });
                }
                reader.Close();
                reader = SelectJanr.ExecuteReader();
                while (reader.Read())
                {
                    JanrBinding.Add(new ListItem() { Cod = reader[0].ToString(), Value = reader[1].ToString() });
                }
                reader.Close();
                reader = SelectSotr.ExecuteReader();
                while (reader.Read())
                {
                    SotrBinding.Add(new ListItem() { Cod = reader[0].ToString(), Value = reader[1].ToString() });
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
            Ispcombo.DisplayMember = "Value";
            Janrcombo.DisplayMember = "Value";
            Sotrcombo.DisplayMember = "Value";
            Ispcombo.ValueMember = "Cod";
            Janrcombo.ValueMember = "Cod";
            Sotrcombo.ValueMember = "Cod";
            Ispcombo.DataSource = IspBinding;
            Janrcombo.DataSource = JanrBinding;
            Sotrcombo.DataSource = SotrBinding;
            if(!is_insert)
            {
                Ispcombo.SelectedValue = keys[0].ToString();
                Janrcombo.SelectedValue = keys[1].ToString();
                Sotrcombo.SelectedValue = keys[2].ToString();
            }
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
