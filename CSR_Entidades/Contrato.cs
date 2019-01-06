using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSR_Entidades
{
    public class Contrato
    {
        public int id { get; set; }
        public int tipo { get; set; }
        //El tipo de contrato hace referencia a
        //1. Contrato por 50 años
        //2. Alquiler por 5 años
        public string notas { get; set; }
        public DateTime fecha_Vencimiento { get; set; }
        public DateTime fecha_Actual { get; set; }
        public Arrendatario arrendatario { get; set; }
        public List<Boveda> bovedas { get; set; }

    }
}
