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

namespace Lab1._1
{
    public partial class Form6 : Form
    {
        string[][] bludo;
        string[][] produkt;
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.Connection);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "select count(bl) from bluda";
            sqlConnection.Open();

            int kol = int.Parse(sqlCommand.ExecuteScalar().ToString());
            bludo = new string[kol][];
            
            sqlCommand.CommandText = "select bl, bludo from bluda";
            SqlDataReader reader = sqlCommand.ExecuteReader();
            for (int i = 0; reader.Read(); i++)
            {
                bludo[i] = new string[2];
                bludo[i][0] = reader[0].ToString();
                bludo[i][1] = reader[1].ToString();

                comboBox1.Items.Add(bludo[i][1]);
            }
            reader.Close();
            sqlCommand.Parameters.Add("@bl", SqlDbType.Int);
            sqlCommand.CommandText = "select produkt from sostav join produkt on sostav.pr = produkt.pr "
                + " where bl = @bl";
            IEnumerable<string> a = Enumerable.Empty<string>();
            for (int i = 0; i < bludo.Length; i++)
            {
                sqlCommand.Parameters["@bl"].Value = bludo[i][0];
                reader = sqlCommand.ExecuteReader();
                while(reader.Read())
                {
                    Array.Resize(ref bludo[i], bludo[i].Length + 1);
                    bludo[i][bludo[i].Length - 1] = reader[0].ToString();
                }
                reader.Close();
                a = a.Concat(bludo[i].Skip(2));
            }
            var b = a.Distinct().ToArray();
            produkt = new string[b.Count()][];
            for (int i = 0; i < produkt.Length; i++)
            {
                produkt[i] = new string[1];
                produkt[i][0] = b[i];
                comboBox2.Items.Add(produkt[i][0]);
                for (int j = 0; j < bludo.Length; j++)
                {
                    if(bludo[j].Contains(produkt[i][0]))
                    {
                        Array.Resize(ref produkt[i], produkt[i].Length + 1);
                        produkt[i][produkt[i].Length - 1] = bludo[j][1];
                    }
                }
                for (int k = 1; k < produkt[i].Length; k++)
                {
                    listBox2.Items.Add(produkt[i][k]);
                }
            }
            reader.Close();
            sqlConnection.Close();

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            int index = -1;
            for (int i = 0; i < bludo.Length; i++)
            {
                if (comboBox1.SelectedItem.ToString() == bludo[i][1])
                {
                    index = i;
                    break;
                }
            }

            for (int i = 2; i < bludo[index].Length; i++)
            {
                listBox1.Items.Add(bludo[index][i]);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            int index = -1;
            for (int i = 0; i < produkt.Length; i++)
            {
                if (comboBox2.SelectedItem.ToString() == produkt[i][0])
                {
                    index = i;
                    break;
                }
            }

            for (int i = 1; i < produkt[index].Length; i++)
            {
                listBox2.Items.Add(produkt[index][i]);
            }
        }
    }
}
