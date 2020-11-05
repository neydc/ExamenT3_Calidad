using DIAZ_T3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIAZ_T3.BD.Maps
{
    public class HistoriaMap : IEntityTypeConfiguration<Historia>
    {
       
        public void Configure(EntityTypeBuilder<Historia> builder)
        {
            builder.ToTable("Historia");
            builder.HasKey(o => o.Id);

            builder.HasOne(o => o.Mascota).WithMany(o => o.HistoriaClinicas).HasForeignKey(o => o.IdMascota);

        }
    }
}
