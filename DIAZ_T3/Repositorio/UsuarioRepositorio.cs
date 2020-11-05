using DIAZ_T3.BD;
using DIAZ_T3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DIAZ_T3.Repositorio
{
    public interface IUsuarioRepository
    {
        public Usuario EncontrarUsuario(string username, string password);
        public Usuario UsuarioLogeado(Claim claim);
    }
    public class UsuarioRepositorio : IUsuarioRepository
    {
        private MascotaContext context;

        public UsuarioRepositorio(MascotaContext context)
        {
            this.context = context;
        }

        public Usuario EncontrarUsuario(string username, string password)
        {
            var usuario = context.Usuarios.FirstOrDefault(o => o.Username == username && o.Password == password);
            return usuario;
        }

        public Usuario UsuarioLogeado(Claim claim)
        {
            var user = context.Usuarios.FirstOrDefault(o => o.Username == claim.Value);
            return user;
        }
    }
}
