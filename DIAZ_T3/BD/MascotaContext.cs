using DIAZ_T3.BD.Maps;
using DIAZ_T3.Models;
using Microsoft.EntityFrameworkCore;

namespace DIAZ_T3.BD
{
    public class MascotaContext : DbContext
    {
        public DbSet<Mascota> Mascotas{ get; set; }
        public DbSet<Usuario> Usuarios{ get; set; }
        public DbSet<Historia> HistoriasClinicas { get; set; }
        
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=MIPC\\SQL; DataBase=DiarsT1;Trusted_Connection=True;MultipleActiveResultSets=true");
        //}

        public MascotaContext(DbContextOptions<MascotaContext> options)
           : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new MascotaMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new HistoriaMap());
        }
    }
 }
