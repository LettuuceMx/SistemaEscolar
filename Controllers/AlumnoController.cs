using Microsoft.AspNetCore.Mvc;
using SistemaEscolar.Models;
using SistemaEscolar.Repositorio.Interfaces;

namespace SistemaEscolar.Controllers
{
    public class AlumnoController : Controller
    {
        private readonly ITAlumno iTAlumno;

        public AlumnoController(ITAlumno iTAlumno)
        {
            this.iTAlumno = iTAlumno;
        }

        [HttpGet]
        public IActionResult AltaAlumnos()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearAlumno(CrearAlumnoModel crearAlumnoModel
            , CrearContactoModel crearContactoModel)
        {
            ModeloMultiple modeloMultiple = new ModeloMultiple();

            ModelState.Remove("crearContactoModel.NumeroInterior");
            if (!ModelState.IsValid)
            {
                return View("AltaAlumnos", modeloMultiple);
            }

            int idAlum = await iTAlumno.AltaAlumno(crearAlumnoModel);

            var contacto = new CrearContactoModel
            {
                IdAlumno = idAlum,
                Nombre = crearContactoModel.Nombre,
                ApellidoPaterno = crearContactoModel.ApellidoPaterno,
                ApellidoMaterno = crearContactoModel.ApellidoMaterno,
                Telefono = crearContactoModel.Telefono,
                Calle = crearContactoModel.Calle,
                Colonia = crearContactoModel.Colonia,
                NumeroExterior = crearContactoModel.NumeroExterior,
                NumeroInterior = crearContactoModel.NumeroInterior,
                CodigoPostal = crearContactoModel.CodigoPostal,
                Estado = crearContactoModel.Estado,
                Parentesco = crearContactoModel.Parentesco,
            };

            bool resultado = await iTAlumno.AltaContacto(contacto);

            TempData["Exito"] = $"Se a dado de alta con exito el alumno {crearAlumnoModel.Nombre + crearAlumnoModel.ApellidoPaterno + crearAlumnoModel.ApellidoMaterno}";

            //Crear el alumno y despues el contacto
            return RedirectToAction("AltaAlumnos", "Alumno");
        }
    }
}
