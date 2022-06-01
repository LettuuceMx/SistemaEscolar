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

        [HttpGet, Route("IdAlumno={IdAlumno}")]
        public async Task<IActionResult> EditarAlumno([FromRoute] int IdAlumno)
        {
            ModeloMultiple modeloMultiple = new ModeloMultiple();

            var coleccion = await iTAlumno.ObtenerAlumnoContacto(IdAlumno);

            if (coleccion is null)
            {
                return RedirectToAction("AlumnosSeguimiento", "Alumno");
            }

            TempData["idAlumno"] = IdAlumno.ToString();
            modeloMultiple.EditarAlumnoContactoModel = coleccion;

            return View(modeloMultiple);
        }

        [HttpGet]
        public async Task<IActionResult> AlumnosSeguimiento()
        {
            ModeloMultiple modeloMultiple = new ModeloMultiple();
            modeloMultiple.IEnumerableAlumnos = await iTAlumno.ObtenerAlumnos();
            return View(modeloMultiple);
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
                NombreContacto = crearContactoModel.NombreContacto,
                ApellidoPaternoContacto = crearContactoModel.ApellidoPaternoContacto,
                ApellidoMaternoContacto = crearContactoModel.ApellidoMaternoContacto,
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

            TempData["Exito"] = $"Se a dado de alta con exito el alumno {crearAlumnoModel.NombreAlumno + crearAlumnoModel.ApellidoPaternoAlumno + crearAlumnoModel.ApellidoMaternoAlumno}";

            //Crear el alumno y despues el contacto
            return RedirectToAction("AltaAlumnos", "Alumno");
        }

        [HttpPost]
        public async Task<IActionResult> ActualizarDatosAlumno(EditarAlumnoContactoModel editarAlumnoContactoModel)
        {
            ModeloMultiple modeloMultiple = new ModeloMultiple();
            string idAlumno = TempData["idAlumno"].ToString();
            editarAlumnoContactoModel.IdAlumno = int.Parse(idAlumno);
            ModelState.Remove("editarAlumnoContactoModel.NumeroInterior");
            ModelState.Remove("editarAlumnoContactoModel.NombreAlumno");
            ModelState.Remove("editarAlumnoContactoModel.ApellidoMaternoAlumno");
            ModelState.Remove("editarAlumnoContactoModel.ApellidoPaternoAlumno");

            if (!editarAlumnoContactoModel.estaDeBaja)
            {
                ModelState.Remove("editarAlumnoContactoModel.FechaBaja");
                editarAlumnoContactoModel.FechaBaja = "-";
            }

            if (!ModelState.IsValid)
            {
                modeloMultiple.EditarAlumnoContactoModel = editarAlumnoContactoModel;
                TempData["idAlumno"] = idAlumno;
                return View("EditarAlumno", modeloMultiple);
                //return RedirectToAction("EditarAlumno", "Alumno", new { IdAlumno = idAlumno });
            }

            bool resultado = await iTAlumno.ActualizarDatosAlumno(editarAlumnoContactoModel);

            return RedirectToAction("AlumnosSeguimiento", "Alumno");
        }

        [HttpPost]
        public async Task<IActionResult> FiltroGradoEscolar(string gradoEscolar)
        {
            ModeloMultiple modeloMultiple = new ModeloMultiple();

            if (string.IsNullOrEmpty(gradoEscolar))
            {
                return RedirectToAction("AlumnosSeguimiento", "Alumno");
            }

            var coleccion = await iTAlumno.FiltroGradoEscolar(gradoEscolar);

            if (coleccion is null)
            {
                return RedirectToAction("AlumnosSeguimiento", "Alumno");
            }

            modeloMultiple.IEnumerableAlumnos = coleccion;

            return View("AlumnosSeguimiento", modeloMultiple);
        }

        public async Task<IActionResult> FiltroNivelEducativo(string nivelEducativo)
        {
            ModeloMultiple modeloMultiple = new ModeloMultiple();

            if (string.IsNullOrEmpty(nivelEducativo))
            {
                return RedirectToAction("AlumnosSeguimiento", "Alumno");
            }

            var coleccion = await iTAlumno.FiltroNIvelEscolar(nivelEducativo);

            if (coleccion is null)
            {
                return RedirectToAction("AlumnosSeguimiento", "Alumno");
            }

            modeloMultiple.IEnumerableAlumnos = coleccion;

            return View("AlumnosSeguimiento", modeloMultiple);
        }
    }
}
