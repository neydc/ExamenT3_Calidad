using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DIAZ_T3.BD;
using DIAZ_T3.Models;
using DIAZ_T3.Repositorio;
using DIAZ_T3.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DIAZ_T3.Controllers
{
    [Authorize]
    public class MascotaController : Controller
    {
        private readonly IUsuarioRepository _usuario;
        private readonly IMascotaRepository _mascota;
        private readonly IHistoriaRepository _historiaClinica;
        private readonly ICookieAuthService _cookieAuthService;

        public MascotaController(IMascotaRepository _mascota, ICookieAuthService _cookieAuthService, IHistoriaRepository _historiaClinica, IUsuarioRepository _usuario)
        {
            this._usuario = _usuario;
            this._mascota = _mascota;
            this._historiaClinica = _historiaClinica;
            this._cookieAuthService = _cookieAuthService;
        }

        // GET
        public IActionResult Index()
        {
            Usuario user = LoggedUser();

            var ListaMascotas = _mascota.MisMascotas(user);
            ViewBag.usuario = user;
            return View(ListaMascotas);
        }

        public IActionResult HistoriasClinicas(int IdMascota)
        {
            Usuario user = LoggedUser();
            var MisHistoriasClinicas = _historiaClinica.MisHistoriasCLinicas(IdMascota);
            ViewBag.IdMascota = IdMascota;


            return View(MisHistoriasClinicas);
        }

        public IActionResult CrearMascota()
        {

            ViewBag.Sexo = Sexo();
            ViewBag.Raza = Raza();
            ViewBag.Especie = Especie();

            // var ListaHistoriasCLinicas = _historiaClinica.MisHistoriasCLinicas(IdMascota);

            return View();
        }
        public IActionResult GuardarMascota(Mascota mascota)
        {
            Usuario user = LoggedUser();
            _mascota.GuardarMascota(user, mascota);

            return RedirectToAction("Index");
        }
        public IActionResult CrearRegistro(int IdMascota)
        {
            ViewBag.IdMascota = IdMascota;
            return View();
        }
        public IActionResult GuardarRegistro(Historia historiaClinica)
        {
            _historiaClinica.GuardarHistoriaClinica(historiaClinica);
            return RedirectToAction("Index");
        }




        private Usuario LoggedUser()
        {

            _cookieAuthService.SetHttpContext(HttpContext);
            var claim = _cookieAuthService.ObetenerClaim();
            var user = _usuario.UsuarioLogeado(claim);
            return user;
        }

        private List<string> Sexo()
        {
            List<string> sexos = new List<string>();
            sexos.Add("Masculino");
            sexos.Add("Femenino");
            return sexos;
        }
        private List<string> Especie()
        {
            List<string> especie = new List<string>();
            especie.Add("Aves");
            especie.Add("Especie A");
            especie.Add("Mamiferos");
            especie.Add("Especie B");
            especie.Add("Peces");


            return especie;
        }
        private List<string> Raza()
        {
            List<string> raza = new List<string>();
            raza.Add("Alemán");
            raza.Add("Peruana");
            raza.Add("Chileno");
            return raza;
        }
    }
}

