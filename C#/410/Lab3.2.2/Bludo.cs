using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3._2
{
    class Bludo
    {
        public string Name { get; set; }
        public double Vyhod { get; set; }
        public int Trud { get; set; }
        public List<Produkt> Produkts { get; set; }

        public Bludo(string name, double vyhod, int trud, List<Produkt> produkts)
        {
            Name = name;
            Vyhod = vyhod;
            Trud = trud;
            Produkts = produkts;
        }
    }
}
