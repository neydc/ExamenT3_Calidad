using DIAZ_T3.Controllers;
using DIAZ_T3.Models;
using DIAZ_T3.Repositorio;
using DIAZ_T3.Service;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DIAZ_T3.TEST.Test
{
    class MascotaControllerTest
    {
        [Test]
        public void IndexReturnView()
        {
            Usuario nuevo = new Usuario();
            var CookieAuthService = new Mock<ICookieAuthService>();
            var UsuarioRepositoryMock = new Mock<IUsuarioRepository>();
            UsuarioRepositoryMock.Setup(o => o.UsuarioLogeado(null)).Returns(nuevo);


            List<Mascota> misMascotas = new List<Mascota>();
            var MascotaRepositoryMock = new Mock<IMascotaRepository>();
            MascotaRepositoryMock.Setup(o => o.MisMascotas(nuevo)).Returns(misMascotas);
            var controller = new MascotaController(MascotaRepositoryMock.Object, CookieAuthService.Object, null, UsuarioRepositoryMock.Object);
            var view = controller.Index();
            Assert.IsInstanceOf<ViewResult>(view);
        }

        [Test]
        public void HistoriasReturnView()
        {
            Usuario nuevo = new Usuario();
            var CookieAuthService = new Mock<ICookieAuthService>();
            var UsuarioRepositoryMock = new Mock<IUsuarioRepository>();
            UsuarioRepositoryMock.Setup(o => o.UsuarioLogeado(null)).Returns(nuevo);


            List<Historia> historiaClinicas = new List<Historia>();
            var HistoriaClinicaRepositoryMock = new Mock<IHistoriaRepository>();
            HistoriaClinicaRepositoryMock.Setup(o => o.MisHistoriasCLinicas(2)).Returns(historiaClinicas);
            var controller = new MascotaController(null, CookieAuthService.Object, HistoriaClinicaRepositoryMock.Object, UsuarioRepositoryMock.Object);
            var view = controller.HistoriasClinicas(2);
            Assert.IsInstanceOf<ViewResult>(view);
        }

        [Test]
        public void CrearMascota()
        {
            var controller = new MascotaController(null, null, null, null);
            var view = controller.CrearMascota();
            Assert.IsInstanceOf<ViewResult>(view);
        }

        [Test]
        public void GuardarMascotaCorrect_ReturnRedirecToView()
        {
            Usuario nuevo = new Usuario();
            var CookieAuthService = new Mock<ICookieAuthService>();
            var UsuarioRepositoryMock = new Mock<IUsuarioRepository>();
            UsuarioRepositoryMock.Setup(o => o.UsuarioLogeado(null)).Returns(nuevo);


            List<Mascota> misMascotas = new List<Mascota>();
            var MascotaRepositoryMock = new Mock<IMascotaRepository>();
            MascotaRepositoryMock.Setup(o => o.GuardarMascota(new Usuario(), new Mascota()));
            var controller = new MascotaController(MascotaRepositoryMock.Object, CookieAuthService.Object, null, UsuarioRepositoryMock.Object);
            var view = controller.GuardarMascota(new Mascota());
            Assert.IsInstanceOf<RedirectToActionResult>(view);
        }

        [Test]
        public void CrearRegistroReturnView()
        {
            var controller = new MascotaController(null, null, null, null);
            var view = controller.CrearRegistro(2);
            Assert.IsInstanceOf<ViewResult>(view);
        }

        [Test]
        public void GuardarRegistroReturnRedirecToView()
        {
            Usuario nuevo = new Usuario();
            var CookieAuthService = new Mock<ICookieAuthService>();
            var UsuarioRepositoryMock = new Mock<IUsuarioRepository>();
            UsuarioRepositoryMock.Setup(o => o.UsuarioLogeado(null)).Returns(nuevo);


            List<Mascota> misMascotas = new List<Mascota>();
            var HistoriaClinicaRepositoryMock = new Mock<IHistoriaRepository>();
            HistoriaClinicaRepositoryMock.Setup(o => o.GuardarHistoriaClinica(new Historia()));
            var controller = new MascotaController(null, CookieAuthService.Object, HistoriaClinicaRepositoryMock.Object, UsuarioRepositoryMock.Object);
            var view = controller.GuardarRegistro(new Historia());
            Assert.IsInstanceOf<RedirectToActionResult>(view);
        }
    }
}

