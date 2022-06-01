using Microsoft.AspNetCore.Mvc;
using SistemaEscolar.Models;
using SistemaEscolar.Repositorio.Interfaces;

namespace SistemaEscolar.Controllers
{
    public class LoginController : Controller
    {
        private readonly ITAlumno tAlumno;

        public LoginController(ITAlumno tAlumno)
        {
            this.tAlumno = tAlumno;
        }

        [HttpGet]
        public IActionResult IniciarSesion()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CrearCuenta()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Campos vacios";

                return View("IniciarSesion", loginModel);
            }

            bool resultado = await tAlumno.LoginCuenta(loginModel);

            if (!resultado)
            {
                TempData["Error"] = "Correo o contraseña no existenes";

                return View("IniciarSesion", loginModel);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> CrearCuentaRegistro(CrearCuenta crearCuenta)
        {

            if (!ModelState.IsValid)
            {
                return View("CrearCuenta", crearCuenta);
            }

            if (!crearCuenta.ConfirmarPassword.Equals(crearCuenta.Password))
            {
                TempData["Error"] = "Los campos contraseña no coinciden";

                return View("CrearCuenta", crearCuenta);
            }

            bool resultado = await tAlumno.CrearCuentaUsuario(crearCuenta);

            TempData["Exito"] = "Cuenta creada correctamente";

            return RedirectToAction("IniciarSesion", "Login");
        }
    }
}
