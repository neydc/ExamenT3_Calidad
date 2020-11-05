using DIAZ_T3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIAZ_T3.BD.Maps
{
    public class MascotaMap : IEntityTypeConfiguration<Mascota>
    {
        public void Configure(EntityTypeBuilder<Mascota> builder)
        {
            builder.ToTable("Mascota");
            builder.HasKey(a=>a.Id);

            builder.HasMany(o => o.HistoriaClinicas).WithOne(a=>a.Mascota).HasForeignKey(a=>a.IdMascota);

            builder.HasOne(o => o.Usuario)
                .WithMany(A=>A.Mascotas)
                .HasForeignKey(o => o.IdUsuario);
        }
    }
}
