using DIAZ_T3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DIAZ_T3.BD.Maps
{
    public class UsuarioMap:IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(a => a.Id);

            builder.HasMany(a => a.Mascotas).WithOne(a => a.Usuario).HasForeignKey(a=>a.IdUsuario);
        }
    }
}
