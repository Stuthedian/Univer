using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Lab3._2
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        /// 

        static SqlConnection sqlConnection;
        public static List<Vid_bluda> vid_Bludas;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            vid_Bludas = get_vid_bluda();
            Application.Run(new Form1());
        }

        static List<Vid_bluda> get_vid_bluda()
        {
            sqlConnection = new SqlConnection(Properties.Settings.Default.Connection);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = @"select * from vid_blud ";
            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();

            List<Vid_bluda> vid_Bludas = new List<Vid_bluda>();
            while(reader.Read())
            {
                vid_Bludas.Add(new Vid_bluda(reader[1].ToString(), get_bluda(reader[0].ToString())));
            }

            reader.Close();
            sqlConnection.Close();
            return vid_Bludas;
        }

        static List<Bludo> get_bluda(string vid_bluda)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = @"select bl, bludo, vihod, trud from bluda 
                where b = @b";
            sqlCommand.Parameters.Add("@b", SqlDbType.Char);
            sqlCommand.Parameters["@b"].Value = vid_bluda;

            SqlDataReader reader = sqlCommand.ExecuteReader();

            List<Bludo> bludos = new List<Bludo>();
            while(reader.Read())
            {
                bludos.Add(new Bludo(reader[1].ToString(), double.Parse(reader[2].ToString()),
                    int.Parse(reader[3].ToString()), get_produkt(reader[0].ToString())));
            }

            reader.Close();
            return bludos;
        }

        static List<Produkt> get_produkt(string bludo)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = @"select produkt, vec from sostav join produkt 
                on sostav.pr = produkt.pr where bl = @bl";
            sqlCommand.Parameters.Add("@bl", SqlDbType.Int);
            sqlCommand.Parameters["@bl"].Value = bludo;

            SqlDataReader reader = sqlCommand.ExecuteReader();

            List<Produkt> produkts = new List<Produkt>();
            while (reader.Read())
            {
                produkts.Add(new Produkt(reader[0].ToString(), int.Parse(reader[1].ToString())));
            }

            reader.Close();
            return produkts;
        }

        static public int produkt_sort_alpha(Produkt produkt1, Produkt produkt2)
        {
            return produkt1.Name.CompareTo(produkt2.Name);
        }

        static public int produkt_sort_ves_alpha(Produkt produkt1, Produkt produkt2)
        {
            int by_ves = produkt1.Ves.CompareTo(produkt2.Ves);
            return by_ves == 0 ? produkt_sort_alpha(produkt1, produkt2) : by_ves;
        }

        static public int kol_vo_produktov(Bludo bludo)
        {
            return bludo.Produkts.Count;
        }

        static public int sum_ves_produktov(Bludo bludo)
        {
            return bludo.Produkts.Sum(p => p.Ves);
        }

        static public int bludo_sort_vyhod_ubyv_trud_alpha(Bludo bludo1, Bludo bludo2)
        {
            int by_vyhod_ubyv = bludo2.Vyhod.CompareTo(bludo1.Vyhod);
            if (by_vyhod_ubyv != 0)
                return by_vyhod_ubyv;
            else
            {
                int by_trud = bludo1.Trud.CompareTo(bludo2.Trud);
                if (by_trud != 0)
                    return by_trud;
                else
                    return bludo1.Name.CompareTo(bludo2.Name);
            }
        }

        static public int bludo_sort_kol_vo_produktov_alpha(Bludo bludo1, Bludo bludo2)
        {
            int by_kol_vo_produktov = kol_vo_produktov(bludo1).CompareTo(kol_vo_produktov(bludo2));
            return by_kol_vo_produktov == 0 ? bludo1.Name.CompareTo(bludo2.Name) : by_kol_vo_produktov;
        }

        static public List<Bludo> all_bluda()
        {
            List<Bludo> bludos = new List<Bludo>();
            foreach (Vid_bluda item in vid_Bludas)
            {
                bludos.AddRange(item.Bludos);
            }

            return bludos;
        }

        static public List<Bludo> bludo_max_produkt()
        {
            List<Bludo> bludos = all_bluda();
            int max = bludos.Max(b => kol_vo_produktov(b));
            return bludos.FindAll(b => kol_vo_produktov(b) == max);
        }

        static public List<Bludo> bluda_produkta(string produkt)
        {
            return all_bluda().FindAll(b => b.Produkts.Any(p => p.Name == produkt));
        }

        static public List<string> all_produkt()
        {
            List<Bludo> bludos = all_bluda();
            List<string> produkts = new List<string>();

            foreach (Bludo bludo in bludos)
            {
                foreach (var produkt in bludo.Produkts)
                {
                    produkts.Add(produkt.Name);
                }
            }

            return produkts.Distinct().ToList();
        }

        static public List<string> produkt_max_bludo()
        {
            List<string> produkts = all_produkt();
            int max = produkts.Max(p => bluda_produkta(p).Count);
            return produkts.FindAll(p => bluda_produkta(p).Count == max);
        }
    }
}
