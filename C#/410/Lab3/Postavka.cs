using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Postavka
    {
        string[] status;
        public string Nazvanie
        {
            set 
            { 
                if (nazvanie != null  && nazvanie != value)
                    status[0] = "Нельзя менять название";
                else if(contains_punc_and_numbers(value))
                    status[0] = "Название содержит недопустимые символы";
                else if (is_gt_3_words(value))
                    status[0] = "Название содержит более 3 слов";
                else
                    status[0] = nazvanie = value; 
            }
            get { return nazvanie; }
        }
        private string nazvanie;

        public string Postavshik
        {
            set
            {
                if (postavshik != null && postavshik != value)
                    status[1] = "Нельзя менять название";
                else if (contains_punc_and_numbers(value))
                    status[1] = "Название содержит недопустимые символы";
                else if (is_gt_3_words(value))
                    status[1] = "Название содержит более 3 слов";
                else
                    status[1] = postavshik = value;
            }
            get { return postavshik; }
        }
        private string postavshik;
        public int Kol_vo 
        { 
            set 
            {
                if (value > 0 && value <= 100)
                {
                    kol_vo = value;
                    status[2] = kol_vo.ToString();
                }
                else
                    status[2] = "Количество товара больше 0 и не более 100";
            }
            get { return kol_vo; }
        }
        private int kol_vo;

        public double Stoim
        {
            set 
            { 
                stoim = Math.Round(value, 2);
                status[3] = stoim.ToString();
            }
            get { return stoim; }
        }
        private double stoim;
        public DateTime Data
        {
            set 
            {
                if (value.Year == DateTime.Now.Year)
                {
                    data = value;
                    status[4] = data.ToShortDateString();
                }
                else
                    status[4] = "Дата товара ограничена текущим годом";
            }
            get { return data; }
        }
        private DateTime data;

        public Postavka()
        {
            new Postavka("Товар", "Поставщик", 1, 1.22, DateTime.Now);
        }
        public Postavka(string nazvanie, string postavshik, int kol_vo, double stoim, DateTime data)
        {
            status = new string[5];
            Nazvanie = nazvanie;
            Postavshik = postavshik;
            Kol_vo = kol_vo;
            Stoim = stoim;
            Data = data;
        }

        public string show_status()
        {
            string str = "";
            str += "Название — " + status[0] + "\n";
            str += "Поставшик — " + status[1] + "\n";
            str += "Кол-во — " + status[2] + "\n";
            str += "Стоимость — " + status[3] + "\n";
            str += "Дата — " + status[4] + "\n";
            return str;
        }

        static bool contains_punc_and_numbers(string str)
        {
            string punc = "0123456789,.;:";
            foreach (char chr in str)
            {
                if (punc.Contains(chr))
                        return true;
            }
            return false;
        }

        static bool is_gt_3_words(string str)
        {
            return str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Count() >= 3;
        }
    }
}
