using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
	public partial class Form1 : Form
	{
		public class knigi_count
		{
			public int cod;
			public int count;
			public knigi_count(int out_cod, int v)
			{
				cod = out_cod;
				count = v;
			}
		};
		bool chitatel_check(string[,] ch)
		{
			int out_cod, kod;
			DateTime out_date;

			int kol = ch.GetLength(0);
			for (int i = 0; i < kol; ++i)
			{
				if (ch[i, 0].Trim() == "")
				{
					MessageBox.Show("Читатели: Отсутствует код читателя в строке "
						+ i.ToString(), "CBEPX Fatal errore!");
					return false;
				}
				if (ch[i, 1].Trim() == "")
				{
					MessageBox.Show("Читатели: Отсутствует фио читателя в строке "
						+ i.ToString(), "CBEPX Fatal errore!");
					return false;
				}
				if (ch[i, 2].Trim() == "")
				{
					MessageBox.Show("Читатели: Отсутствует дата рождения читателя в строке "
						+ i.ToString(), "CBEPX Fatal errore!");
					return false;
				}

				if (int.TryParse(ch[i, 0], out out_cod) == false)
				{
					MessageBox.Show("Читатели: код — не число, в строке "
						+ i.ToString(), "CBEPX Fatal errore!");
					return false;
				}
				if (DateTime.TryParse(ch[i, 2], out out_date) == false)
				{
					MessageBox.Show("Читатели: неправильный тип для дня рождения, ожидается DateTime в строке "
						+ i.ToString(), "CBEPX Fatal errore!");
					return false;
				}
			}

			for (int i = 0; i < kol; ++i)
			{
				kod = int.Parse(ch[i, 0]);
				for (int j = ++i; j < kol; ++j)
				{
					if (int.Parse(ch[j, 0]) == kod)
					{
						MessageBox.Show("Читатели: дублирование кода в строке "
							+ j.ToString(), "CBEPX Fatal errore!");
						return false;
					}
				}
			}
			return true;
		}

		bool knigi_check(string[,] kn)
		{
			int out_cod, kod;

			int kol = kn.GetLength(0);
			for (int i = 0; i < kol; ++i)
			{
				if (kn[i, 0].Trim() == "")
				{
					MessageBox.Show("Книги: Отсутствует код книги в строке "
						+ i.ToString(), "CBEPX Fatal errore!");
					return false;
				}
				if (kn[i, 1].Trim() == "")
				{
					MessageBox.Show("Книги: Отсутствует название книги в строке "
						+ i.ToString(), "CBEPX Fatal errore!");
					return false;
				}
				if (kn[i, 2].Trim() == "")
				{
					MessageBox.Show("Книги: Отсутствует фио автора в строке "
						+ i.ToString(), "CBEPX Fatal errore!");
					return false;
				}
				if (kn[i, 3].Trim() == "")
				{
					MessageBox.Show("Книги: Отсутствует кол-во экземпляров в строке "
						+ i.ToString(), "CBEPX Fatal errore!");
					return false;
				}

				if (int.TryParse(kn[i, 0], out out_cod) == false)
				{
					MessageBox.Show("Книги: код — не число, в строке "
						+ i.ToString(), "CBEPX Fatal errore!");
					return false;
				}
				if (int.TryParse(kn[i, 3], out out_cod) == false)
				{
					MessageBox.Show("Книги: кол-во экземпляров — не число, в строке "
						+ i.ToString(), "CBEPX Fatal errore!");
					return false;
				}
				if (out_cod <= 0)
				{
					MessageBox.Show("Книги: кол-во экземпляров должно <= 0  в строке "
						+ i.ToString(), "CBEPX Fatal errore!");
					return false;
				}
			}

			for (int i = 0; i < kol; ++i)
			{
				kod = int.Parse(kn[i, 0]);
				for (int j = ++i; j < kol; ++j)
				{
					if (int.Parse(kn[j, 0]) == kod)
					{
						MessageBox.Show("Книги: дублирование кода в строке "
							+ j.ToString(), "CBEPX Fatal errore!");
						return false;
					}
				}
			}
			return true;
		}

		bool vydannye_knigi_check(string[,] vd, string[,] ch, string[,] kn)
		{
			int out_cod;
			DateTime out_date;
			bool kn_check = false, ch_check = false, was_in_knigi_count = false;
			//int[,] array_knigi_count = new int[kn.Length(),2]
			List<knigi_count> array_knigi_count = new List<knigi_count>();


			int kol = vd.GetLength(0);

			for (int i = 0; i < kol; ++i)
			{
				if (vd[i, 0].Trim() == "")
				{
					MessageBox.Show("Выданные книги: Отсутствует код  выданные книги в строке "
						+ i.ToString(), "CBEPX Fatal errore!");
					return false;
				}
				if (vd[i, 1].Trim() == "")
				{
					MessageBox.Show("Выданные книги: Отсутствует код читателя в строке "
						+ i.ToString(), "CBEPX Fatal errore!");
					return false;
				}
				if (vd[i, 2].Trim() == "")
				{
					MessageBox.Show("Выданные книги: Отсутствует дата выдачи в строке "
						+ i.ToString(), "CBEPX Fatal errore!");
					return false;
				}

				if (int.TryParse(vd[i, 0], out out_cod) == false)
				{
					MessageBox.Show("Выданные книги: код книги — не число, в строке "
						+ i.ToString(), "CBEPX Fatal errore!");
					return false;
				}

				if (vd[i, 3].Trim() == "")
				{
					for (int k = 0; k < array_knigi_count.Count(); k++)
					{
						if (array_knigi_count[k].cod == out_cod)
						{
							array_knigi_count[k].count++;
							was_in_knigi_count = true;
						}
					}
					if (!was_in_knigi_count)
					{
						array_knigi_count.Add(new knigi_count(out_cod, 1));
					}
					was_in_knigi_count = false;
				}

				if (int.TryParse(vd[i, 1], out out_cod) == false)
				{
					MessageBox.Show("Выданные книги: код читателя  — не число, в строке "
						+ i.ToString(), "CBEPX Fatal errore!");
					return false;
				}
				if (DateTime.TryParse(vd[i, 2], out out_date) == false)
				{
					MessageBox.Show("Выданные книги: неправильный тип для даты выдачи, ожидается DateTime в строке "
						+ i.ToString(), "CBEPX Fatal errore!");
					return false;
				}

				if (vd[i, 3].Trim() != "" && DateTime.TryParse(vd[i, 3], out out_date) == false)
				{
					MessageBox.Show("Выданные книги: неправильный тип для даты возврата, ожидается DateTime в строке "
						+ i.ToString(), "CBEPX Fatal errore!");
					return false;
				}

				for (int j = 0; j < kn.GetLength(0); ++j)
				{
					if (int.Parse(vd[i, 0]) == int.Parse(kn[j, 0]))
					{
						kn_check = true;
						break;
					}
				}
				if (kn_check == false)
				{
					MessageBox.Show("Выданные книги: код книги отсутствует таблице \"книги\", в строке "
					  + i.ToString(), "CBEPX Fatal errore!");
					return false;
				}

				for (int j = 0; j < ch.GetLength(0); ++j)
				{
					if (int.Parse(vd[i, 1]) == int.Parse(ch[j, 0]))
					{
						ch_check = true;
						break;
					}
				}
				if (ch_check == false)
				{
					MessageBox.Show("Выданные книги: код читателя отсутствует таблице \"читатели\", в строке "
					  + i.ToString(), "CBEPX Fatal errore!");
					return false;
				}
			}
			for (int i = 0; i < array_knigi_count.Count(); i++)
			{
				for (int j = 0; j < kn.GetLength(0); j++)
				{
					if (int.Parse(kn[j, 0]) == array_knigi_count[i].cod)
					{
						if (int.Parse(kn[j, 3]) < array_knigi_count[i].count)
						{
							MessageBox.Show("Выданные книги: кол-во выданных экземпляров книги с кодом "
							+ kn[j, 0] + " больше кол-ва экземпляров в библиотеке", "CBEPX Fatal errore!");
							return false;
						}
						break;
					}

				}
			}


			return true;
		}
		void otchet_1(string[,] kn, string[,] vd)
		{
			string str;
			int[,] schetchik = new int[kn.GetLength(0), 2];
			for (int i = 0; i < kn.GetLength(0); i++)
			{
				schetchik[i, 0] = int.Parse(kn[i, 0]);
			}
			for (int i = 0; i < vd.GetLength(0); i++)
			{
				for (int j = 0; j < kn.GetLength(0); j++)
				{
					if (int.Parse(vd[i, 0]) == schetchik[j, 0] && vd[i, 3].Trim() == "")
					{
						schetchik[j, 1]++;
						break;
					}
				}

			}
			str = "Книга:\tКоличество читателей:\n";
			for (int i = 0; i < kn.GetLength(0); i++)
			{
				str += kn[i, 1];
				str += "\t";
				str += schetchik[i, 1];
				str += "\n";
			}
			MessageBox.Show(str, "Отчет:Количество читателей, взявших данную книгу");
		}
		void otchet_2(string[,] vd, string[,] ch)
		{
			string str = "ФИО читателя:\n";
			bool ch_in_vd = false;
			for (int i = 0; i < ch.GetLength(0); i++)
			{
				for (int j = 0; j < vd.GetLength(0); j++)
				{
					if (int.Parse(vd[j, 1]) == int.Parse(ch[i, 0]))
					{
						ch_in_vd = true;
						break;
					}
				}
				if (ch_in_vd == false)
				{
					string[] FIO = ch[i, 1].Split(new Char[] { ' ' }, 3);
					str += FIO[0] + " " + FIO[1][0] + ". " + FIO[2][0] + ".\n";

				}
				else ch_in_vd = false;
			}

			MessageBox.Show(str, "Отчет:Читатели, которые не брали ни одной книги");
		}
		void otchet_3(string[,] kn, string[,] vd)
		{
			string str = "Названия книг:\n";
			bool kn_in_hands = false;
			for (int i = 0; i < kn.GetLength(0); i++)
			{
				for (int j = 0; j < vd.GetLength(0); j++)
				{
					if (int.Parse(vd[j, 0]) == int.Parse(kn[i, 0]) && vd[j, 3].Trim() == "")
					{
						kn_in_hands = true;
						break;
					}
				}
				if (kn_in_hands == true)
				{
					str += kn[i, 1] + "\n";
				}
				kn_in_hands = false;
			}
			MessageBox.Show(str, "Отчет:Книги, которые находятся на руках");
		}
		void otchet_4(string[,] ch, string[,] vd)
		{
			string name, str = "Читатель:\tКоличество книг:\n";
			int books_count = 0;
			for (int i = 0; i < ch.GetLength(0); i++)
			{
				name = ch[i, 1].Split(new Char[] { ' ' }, 3)[1];
				if (name.IndexOfAny(new Char[] { 'А', 'а', 'О', 'о' }) != -1)
				{
					for (int j = 0; j < vd.GetLength(0); j++)
					{
						if (int.Parse(vd[j, 1]) == int.Parse(ch[i, 0]) && vd[j, 3].Trim() == "")
						{
							++books_count;
						}
					}
					if (books_count > 3)
					{
						str += ch[i, 1] + '\t' + books_count + '\n';
					}
					books_count = 0;
				}
			}
			MessageBox.Show(str, "Отчет:Количество невозвращенных книг читалей с А и О в имени");
		}
		void otchet_5(string[,] ch, string[,] vd)
		{
			//Вывести фамилии читателей, которым выдано наибольшее число книг.
			string fam, str = "Фамилии читателей:\n";
			int max = 0;
			int[,] count_books = new int[ch.GetLength(0), 2];
			for (int i = 0; i < ch.GetLength(0); i++)
			{
				count_books[i, 0] = int.Parse(ch[i, 0]);
			}
			for (int i = 0; i < vd.GetLength(0); i++)
			{
				if (vd[i, 3].Trim() == "")
				{
					for (int j = 0; j < count_books.GetLength(0); j++)
					{
						if (count_books[j, 0] == int.Parse(vd[i, 1]))
						{
							++count_books[j, 1];
							break;
						}
					}
				}
			}
			for (int i = 0; i < ch.GetLength(0); i++)
			{
				if (count_books[i, 1] > max)
				{
					max = count_books[i, 1];
				}
			}
			if (max == 0) return;
			for (int i = 0; i < ch.GetLength(0); i++)
			{
				if (count_books[i, 1] == max)
				{
					fam = ch[i, 1].Split(new Char[] { ' ' }, 3)[0];
					str += fam + '\n';
				}
			}
			MessageBox.Show(str, "Отчет:Фамилии читателей, которым выдано наибольшее число книг");
		}
		public Form1()
		{
			InitializeComponent();
		}
		string[,] chitatel = { { "1", "Мыльникова Елена Анатольевна", "28,03.2018" },
									{ "2", "Исаков Александр Иванович", "09.03.2018" },
									{ "3", "Исаков Александр Иванович", "30.03.2018" },
									{ "4", "Курбатова Марина Геннадьевна", "30.03.2018"}};

		string[,] knigi = { { "1", "Теэтет", "Платон", "2" },
								{ "2", "Крыжовник", "Чехов Антон", "45" },
								{ "3", "Герой нашего времени", "Лермонтян", "12" } };
		string[,] vydannye_knigi = { { "1", "1", "12.05.2018", "12.05.2018" },
										{ "1", "1", "12.05.2018", "12.05.2018" },
										{ "1", "1", "12.05.2018", "12.05.2018" },
										{ "1", "1", "12.05.2018", "" },
										{ "2", "2", "13.05.2018", "13.06.2018" },
										{ "3", "3", "15.05.2018", "" },
										{ "2", "3", "13.05.2018", "" },
										{ "2", "3", "14.05.2018", "" },
										{ "1", "3", "15.05.2018", "" }};
		private void Form1_Load(object sender, EventArgs e)
		{
			label1.Text = "";
			if (!(chitatel_check(chitatel)
				&& knigi_check(knigi)
				&& vydannye_knigi_check(vydannye_knigi, chitatel, knigi)))
			{
				Close();
				return;
			}
			/*
            otchet_1(knigi, vydannye_knigi);
            otchet_2(vydannye_knigi, chitatel);
			otchet_3(knigi, vydannye_knigi);
			otchet_4(chitatel, vydannye_knigi);
			otchet_5(chitatel, vydannye_knigi);
			*/
			//Close();
		
		}

		private void button1_Click(object sender, EventArgs e)
		{
			label1.Text = "Отчет:Количество читателей, взявших данную книгу";
			dataGridView1.Rows.Clear();
			dataGridView1.Columns.Clear(); 
			dataGridView1.Columns.Add("Столбец 1", "Книга");
			dataGridView1.Columns.Add("Столбец 2", "Количество читателей");
			int[,] schetchik = new int[knigi.GetLength(0), 2];
			for (int i = 0; i < knigi.GetLength(0); i++)
			{
				schetchik[i, 0] = int.Parse(knigi[i, 0]);
			}
			for (int i = 0; i < vydannye_knigi.GetLength(0); i++)
			{
				for (int j = 0; j < knigi.GetLength(0); j++)
				{
					if (int.Parse(vydannye_knigi[i, 0]) == schetchik[j, 0] && vydannye_knigi[i, 3].Trim() == "")
					{
						schetchik[j, 1]++;
						break;
					}
				}

			}
			for (int i = 0; i < knigi.GetLength(0); i++)
			{
				dataGridView1.Rows.Add(knigi[i, 1], schetchik[i, 1]);
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			label1.Text = "Отчет:Читатели, которые не брали ни одной книги";
			dataGridView1.Rows.Clear();
			dataGridView1.Columns.Clear();
			dataGridView1.Columns.Add("Столбец 1", "ФИО читателя");
			bool ch_in_vd = false;
			for (int i = 0; i < chitatel.GetLength(0); i++)
			{
				for (int j = 0; j < vydannye_knigi.GetLength(0); j++)
				{
					if (int.Parse(vydannye_knigi[j, 1]) == int.Parse(chitatel[i, 0]))
					{
						ch_in_vd = true;
						break;
					}
				}
				if (ch_in_vd == false)
				{
					string[] FIO = chitatel[i, 1].Split(new Char[] { ' ' }, 3);
					dataGridView1.Rows.Add(FIO[0] + " " + FIO[1][0] + ". " + FIO[2][0] + ".\n");

				}
				else ch_in_vd = false;
			}

		}

		private void button3_Click(object sender, EventArgs e)
		{
			label1.Text = "Отчет:Книги, которые находятся на руках";
			dataGridView1.Rows.Clear();
			dataGridView1.Columns.Clear();
			dataGridView1.Columns.Add("Столбец 1", "Названия книг");
			bool kn_in_hands = false;
			for (int i = 0; i < knigi.GetLength(0); i++)
			{
				for (int j = 0; j < vydannye_knigi.GetLength(0); j++)
				{
					if (int.Parse(vydannye_knigi[j, 0]) == int.Parse(knigi[i, 0]) 
						&& vydannye_knigi[j, 3].Trim() == "")
					{
						kn_in_hands = true;
						break;
					}
				}
				if (kn_in_hands == true)
				{
					dataGridView1.Rows.Add(knigi[i, 1]);
				}
				kn_in_hands = false;
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			label1.Text = "Отчет:Количество невозвращенных книг читалей с А и О в имени";
			dataGridView1.Rows.Clear();
			dataGridView1.Columns.Clear();
			dataGridView1.Columns.Add("Столбец 1", "Читатель");
			dataGridView1.Columns.Add("Столбец 2", "Количество книг");
			string name;
			int books_count = 0;
			for (int i = 0; i < chitatel.GetLength(0); i++)
			{
				name = chitatel[i, 1].Split(new Char[] { ' ' }, 3)[1];
				if (name.IndexOfAny(new Char[] { 'А', 'а', 'О', 'о' }) != -1)
				{
					for (int j = 0; j < vydannye_knigi.GetLength(0); j++)
					{
						if (int.Parse(vydannye_knigi[j, 1]) == int.Parse(chitatel[i, 0]) 
							&& vydannye_knigi[j, 3].Trim() == "")
						{
							++books_count;
						}
					}
					if (books_count > 3)
					{
						dataGridView1.Rows.Add(chitatel[i, 1], books_count);
					}
					books_count = 0;
				}
			}
		}

		private void button5_Click(object sender, EventArgs e)
		{
			label1.Text = "Отчет:Фамилии читателей, которым выдано наибольшее число книг";
			dataGridView1.Rows.Clear();
			dataGridView1.Columns.Clear();
			dataGridView1.Columns.Add("Столбец 1", "Фамилии читателей");
			string fam;
			int max = 0;
			int[,] count_books = new int[chitatel.GetLength(0), 2];
			for (int i = 0; i < chitatel.GetLength(0); i++)
			{
				count_books[i, 0] = int.Parse(chitatel[i, 0]);
			}
			for (int i = 0; i < vydannye_knigi.GetLength(0); i++)
			{
				if (vydannye_knigi[i, 3].Trim() == "")
				{
					for (int j = 0; j < count_books.GetLength(0); j++)
					{
						if (count_books[j, 0] == int.Parse(vydannye_knigi[i, 1]))
						{
							++count_books[j, 1];
							break;
						}
					}
				}
			}
			for (int i = 0; i < chitatel.GetLength(0); i++)
			{
				if (count_books[i, 1] > max)
				{
					max = count_books[i, 1];
				}
			}
			if (max == 0) return;
			for (int i = 0; i < chitatel.GetLength(0); i++)
			{
				if (count_books[i, 1] == max)
				{
					fam = chitatel[i, 1].Split(new Char[] { ' ' }, 3)[0];
					dataGridView1.Rows.Add(fam);
				}
			}
		}
	}
}
