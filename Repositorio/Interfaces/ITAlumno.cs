using SistemaEscolar.Models;

namespace SistemaEscolar.Repositorio.Interfaces
{
    public interface ITAlumno
    {
        public Task<int> AltaAlumno(CrearAlumnoModel crearAlumnoModel);
        public Task<bool> AltaContacto(CrearContactoModel crearContactoModel);
        public Task<IEnumerable<AlumnosModel>> ObtenerAlumnos();
        public Task<IEnumerable<AlumnosModel>> FiltroGradoEscolar(string gradoEscolar);
        public Task<IEnumerable<AlumnosModel>> FiltroNIvelEscolar(string nivelEducativo);

        public Task<EditarAlumnoContactoModel> ObtenerAlumnoContacto(int IdAlumno);

        public Task<bool> ActualizarDatosAlumno(EditarAlumnoContactoModel editarAlumnoContactoModel);
    }
}
