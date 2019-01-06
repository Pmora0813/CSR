using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSR_Entidades
{
    public class Boveda
    {
        public int id { get; set; }
        public Char cuadro { get; set; }
        public string nun_Boveda { get; set; }
        public int cant_Nichos { get; set; }
        public string nivel { get; set; }
        public List<Fallecido> fallecidos { get; set; }
    }
}
