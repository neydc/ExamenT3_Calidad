using DIAZ_T3.BD;
using DIAZ_T3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIAZ_T3.Repositorio
{
    public interface IMascotaRepository
    {
        public List<Mascota> MisMascotas(Usuario usuario);
        public void GuardarMascota(Usuario usuario, Mascota mascota);
    }
    public class MascotaRepositorio : IMascotaRepository
    {
        private MascotaContext context;
        public MascotaRepositorio(MascotaContext context)
        {
            this.context = context;
        }
        public void GuardarMascota(Usuario usuario, Mascota mascota)
        {
            Mascota nuevaMascota = new Mascota();
            nuevaMascota = mascota;
            nuevaMascota.IdUsuario = usuario.Id;
            nuevaMascota.fechaRegistro = DateTime.Now;
            context.Mascotas.Add(nuevaMascota);
            context.SaveChanges();
        }

        public List<Mascota> MisMascotas(Usuario usuario)
        {
            var a = context.Mascotas.Where(o => o.IdUsuario == usuario.Id).ToList();
            return a;
        }
    }
}
