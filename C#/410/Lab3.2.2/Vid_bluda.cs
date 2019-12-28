using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3._2
{
    class Vid_bluda
    {
        public string Name { get; set; }
        public List<Bludo> Bludos { get; set; }

        public Vid_bluda(string name, List<Bludo> bludos)
        {
            Name = name;
            Bludos = bludos;
        }
    }
}
