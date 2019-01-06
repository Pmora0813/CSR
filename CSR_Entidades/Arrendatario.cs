using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSR_Entidades
{
    public class Arrendatario
    {

        public string cedula { get; set; }
        public string nombre { get; set; }
        public string p_Apellido { get; set; }
        public string s_Apellido { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public string direccion { get; set; }
        public string notas { get; set; }
        public List<Coarrendatarios> coarrendatarios { get; set; }

    }
}
