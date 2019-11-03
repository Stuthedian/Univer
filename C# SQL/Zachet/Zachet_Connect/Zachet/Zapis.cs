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
    public partial class Zapis : Form
    {
        SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString);
        SqlCommand Selectcommand, Deletecommand/*, Checkcommand*/;
        public Zapis()
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

        private void Zapis_Load(object sender, EventArgs e)
        {
            Selectcommand = new SqlCommand("select cod_zap, naim_zapis, data, cod_isp, cod_janr, cod_sotr, " +
            "(select naim from Ispolnitel where Ispolnitel.cod_isp = Zapis.cod_isp), " +
            "(select naim from Janr where Janr.cod_janr = Zapis.cod_janr), " +
            "(select fam + ' ' + left(im,1) + '.' + left(otch,1) + '.' " +
            "from Sotrudnik where Sotrudnik.cod_sotr = Zapis.cod_sotr) from Zapis"
            , connection);
            Deletecommand = new SqlCommand("del_zap", connection);
            Deletecommand.CommandType = CommandType.StoredProcedure;
            Deletecommand.Parameters.Add("@cod", SqlDbType.Int);
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
                        (DateTime.Parse(reader[2].ToString())).ToShortDateString(),
                        reader[3].ToString(), reader[4].ToString(),
                        reader[5].ToString(), reader[6].ToString(),
                        reader[7].ToString(), reader[8].ToString());
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
                try
                { connection.Open(); }
                catch
                { MessageBox.Show("Нет соединения"); Close(); return; }
                try
                {
                    Deletecommand.Parameters["@cod"].Value = dataGridView1.CurrentRow.Cells["cod_zap"].Value.ToString();
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
            new ZapisEdit(true, dataGridView1).ShowDialog();
            buttons();//выделить только что добавленный элемент
        }

        private void Editbutton_Click(object sender, EventArgs e)
        {
            new ZapisEdit(false, new int[] { int.Parse(dataGridView1.CurrentRow.Cells["cod_isp"].Value.ToString()),
                int.Parse(dataGridView1.CurrentRow.Cells["cod_janr"].Value.ToString()), int.Parse(dataGridView1.CurrentRow.Cells["cod_sotr"].Value.ToString()),
                int.Parse(dataGridView1.CurrentRow.Cells["cod_zap"].Value.ToString())},
                dataGridView1.CurrentRow.Cells["naim_zapis"].Value.ToString(), DateTime.Parse(dataGridView1.CurrentRow.Cells["data"].Value.ToString()),
                dataGridView1).ShowDialog();
            buttons();
        }
    }
}
