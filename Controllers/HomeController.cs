using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SistemaEscolar.Conexiones;
using SistemaEscolar.Models;
using SistemaEscolar.Repositorio.Interfaces;
using System.Diagnostics;

namespace SistemaEscolar.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITAlumno iTAlumno;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration,
            ITAlumno iTAlumno)
        {
            _logger = logger;
            this.iTAlumno = iTAlumno;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AltaAlumnos()
        {
            return View();
        }
    }
}