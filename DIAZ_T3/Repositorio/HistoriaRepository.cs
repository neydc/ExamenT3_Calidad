using DIAZ_T3.BD;
using DIAZ_T3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIAZ_T3.Repositorio
{
    public interface IHistoriaRepository
    {
        public List<Historia> MisHistoriasCLinicas(int IdMascota);
        public void GuardarHistoriaClinica(Historia historiaClinica);
    }
    public class HistoriaRepository : IHistoriaRepository
    {
        private MascotaContext context;

        public HistoriaRepository(MascotaContext context)
        {
            this.context = context;
        }
        public void GuardarHistoriaClinica(Historia historiaClinica)
        {
            Historia nuevaHistoriaClinica = new Historia();
            nuevaHistoriaClinica = historiaClinica;
            var total = context.HistoriasClinicas.Count();
            nuevaHistoriaClinica.codigoRegistro = "A" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + total;
            nuevaHistoriaClinica.FechaRegistro = DateTime.Now;
            context.HistoriasClinicas.Add(nuevaHistoriaClinica);
            context.SaveChanges();
        }

        public List<Historia> MisHistoriasCLinicas(int IdMascota)
        {
            return context.HistoriasClinicas.Where(o => o.IdMascota == IdMascota)
                .ToList();
        }
    }
}
