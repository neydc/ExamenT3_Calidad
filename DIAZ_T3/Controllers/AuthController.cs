using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using SpotifyProCalidad.Extensions;
using Microsoft.AspNetCore.Authentication.Cookies;
using DIAZ_T3.Repositorio;
using DIAZ_T3.Service;

public class AuthController : Controller
    {
       
        private readonly IUsuarioRepository _usuario;
        private readonly ICookieAuthService _cookieAuthService;
      
        public AuthController(IUsuarioRepository _usuario,ICookieAuthService _cookieAuthService)
        {
          
            this._usuario = _usuario;
            this._cookieAuthService = _cookieAuthService;
            
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var usuario = _usuario.EncontrarUsuario(username, password);
            if (usuario != null)
            {
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, username)
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                _cookieAuthService.SetHttpContext(HttpContext);
                _cookieAuthService.Login(claimsPrincipal);

             
                
                return RedirectToAction("Index", "Mascota");
            }
            
            ViewBag.Validation = "Usuario y/o contraseña incorrecta";
            return View();
        }


        public ActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
