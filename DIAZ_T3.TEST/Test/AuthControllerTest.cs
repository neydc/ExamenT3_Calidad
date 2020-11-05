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
    class AuthControllerTest
    {
        [Test]
        public void LoginCorrect_RetornRedirecToAction()
        {
            var repositoryMock = new Mock<IUsuarioRepository>();
            repositoryMock.Setup(o => o.EncontrarUsuario("admin", "admin")).Returns(new Usuario { });

            var authMock = new Mock<ICookieAuthService>();


            var controller = new AuthController(repositoryMock.Object, authMock.Object);
            var result = controller.Login("admin", "admin");

            Assert.IsInstanceOf<RedirectToActionResult>(result);
        }

        [Test]
        public void LoginIncorrect_RetornView()
        {
            var repositoryMock = new Mock<IUsuarioRepository>();


            var authMock = new Mock<ICookieAuthService>();


            var controller = new AuthController(repositoryMock.Object, authMock.Object);
            var result = controller.Login("admin", "admin");

            Assert.IsInstanceOf<ViewResult>(result);
        }
    }
}
