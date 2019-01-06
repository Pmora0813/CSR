using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSR_Entidades
{
    class Mantenimiento
    {
        public int num_Resivo { get; set; }
        public DateTime fecha_Actual { get; set; }
        public int anno_Pagado { get; set; }
        public Boveda boveda { get; set; }
        public double monto { get; set; }
        public string nombre { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public string notas { get; set; }
        public int cuo_Morosas { get; set; }
        public int cuo_Pendientes { get; set; }


        //Tenemos que pensar la forma en que si un cliente
        //tiene más de una boveda a su nombre
        //cuando quiera hacer el pago de UNA sola boveda
        //    seleccionar a cual es la que se le esta pagando
        //    o cuando tiene cuotas atrazadas en las 2 bovedas
        //    por ejemplo 
        //    tiene 2 años pendientes en cada una de las bovedas
        //    y solo quiere para UN año de cada una de las bovedas

    }
}
