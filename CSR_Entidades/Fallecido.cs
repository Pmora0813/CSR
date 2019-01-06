using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSR_Entidades
{
    public class Fallecido
    {
        public string cert_Defuncion { get; set; }
        public DateTime fecha_Entierro { get; set; }
        public string nombre { get; set; }
        public string p_Apellido { get; set; }
        public string s_Apellido { get; set; }
        public string cedula { get; set; }
        public int consecutivo { get; set; }
        public string notas { get; set; }
    }
}
