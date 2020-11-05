using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIAZ_T3.Models
{
    public class Mascota
    {
        public int Id{ get; set; }
        public DateTime fechaRegistro { get; set; }
        public string nombreMascota { get; set; }
        public string fechaNacimientoMascota { get; set; }
        public string Sexo { get; set; }
        public string Especie { get; set; }
        public string Raza{ get; set; }
        public string Tamanio{ get; set; }
        public string datosParticulares{ get; set; }
        public int IdUsuario { get; set; }
        public Usuario Usuario{ get; set; }

        public List<Historia> HistoriaClinicas { get; set; }

    }
}
