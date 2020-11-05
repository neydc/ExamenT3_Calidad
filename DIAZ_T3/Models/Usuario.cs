using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIAZ_T3.Models
{
    public class Usuario
    {
        public int Id{ get; set; }
        public string Username{ get; set; }
        public string Password{ get; set; }
        public string Nombre { get; set; }

        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public List<Mascota> Mascotas { get; set; }
    }
}
