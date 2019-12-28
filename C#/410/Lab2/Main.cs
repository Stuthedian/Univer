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

namespace Lab2
{
    public partial class Main : Form
    {
        public static List<List<string>> bluda = new List<List<string>>();
        public static List<List<string>> produkt = new List<List<string>>();
        public static List<string> postavshiki = new List<string>();
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form1().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Form2().ShowDialog();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.Connection);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = @"select bludo, produkt from bluda join sostav on bluda.bl = sostav.bl
                join produkt on sostav.pr = produkt.pr order by bludo";
            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();
            for (int i = 0; reader.Read(); i++)
            {
                int idx = bluda.FindIndex(elem => elem[0] == reader[0].ToString());
                if (idx != -1)
                {
                    bluda[idx].Add(reader[1].ToString());
                }
                else
                    bluda.Add(new List<string>(new string[] { reader[0].ToString(), reader[1].ToString() }));
            }
            reader.Close();

            sqlCommand.CommandText = @"select produkt, nazvanie from produkt join postavki on produkt.pr = postavki.pr
                join postavshiki on postavki.pc =  postavshiki.pc order by produkt";
            reader = sqlCommand.ExecuteReader();
            for (int i = 0; reader.Read(); i++)
            {
                int idx = produkt.FindIndex(elem => elem[0] == reader[0].ToString());
                if (idx != -1)
                {
                    produkt[idx].Add(reader[1].ToString());
                }
                else
                    produkt.Add(new List<string>(new string[] { reader[0].ToString(), reader[1].ToString() }));
            }
            reader.Close();

            sqlCommand.CommandText = @"select nazvanie from postavshiki";
            reader = sqlCommand.ExecuteReader();
            while(reader.Read())
            {
                postavshiki.Add(reader[0].ToString());
            }

            reader.Close();
            sqlConnection.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new ShowBluda().ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new ShowProdukt().ShowDialog();
        }

        private void Zap1button_Click(object sender, EventArgs e)
        {
            new Zap1().ShowDialog();
        }

        private void Zap2button_Click(object sender, EventArgs e)
        {
            new Zap2().ShowDialog();
        }

        private void Zap3button_Click(object sender, EventArgs e)
        {
            new Zap3().ShowDialog();
        }

        private void Zap4button_Click(object sender, EventArgs e)
        {
            new Zap4().ShowDialog();
        }

        private void Zap6button_Click(object sender, EventArgs e)
        {
            new Zap6().ShowDialog();
        }

        private void Zap7button_Click(object sender, EventArgs e)
        {
            new Zap7().ShowDialog();
        }

        private void Zap8button_Click(object sender, EventArgs e)
        {
            new Zap8().ShowDialog();
        }
    }
}
