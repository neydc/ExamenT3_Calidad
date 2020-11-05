using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIAZ_T3.Models
{
    public class Historia
    {
        public int Id { get; set; }
        public string codigoRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }

        public string Descripcion { get; set; }

        public int IdMascota { get; set; }
        public Mascota Mascota { get; set; }
    }
}
