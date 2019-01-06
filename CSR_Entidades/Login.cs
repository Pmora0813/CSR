using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSR_Entidades
{
    public class Login
    {
        public string contrasenna { get; set; }
        public string usuario { get; set; }
        public int tipo { get; set; }

        //El tipo hace referencia a:
        //    1. Administrador
        //    2. Coordinador
    }
}
