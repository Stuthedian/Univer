using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3._2
{
    class Produkt
    {
        public string Name { get; set; }
        public int Ves { get; set; }

        public Produkt(string name, int ves)
        {
            Name = name;
            Ves = ves;
        }
    }
}
