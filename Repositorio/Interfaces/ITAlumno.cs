using SistemaEscolar.Models;

namespace SistemaEscolar.Repositorio.Interfaces
{
    public interface ITAlumno
    {
        public Task<int> AltaAlumno(CrearAlumnoModel crearAlumnoModel);
        public Task<bool> AltaContacto(CrearContactoModel crearContactoModel);
        public Task<bool> CrearCuentaUsuario(CrearCuenta crearCuenta);
        public Task<bool> LoginCuenta(LoginModel loginModel);
        public Task<IEnumerable<AlumnosModel>> ObtenerAlumnos();
        public Task<IEnumerable<AlumnosModel>> FiltroGradoEscolar(string gradoEscolar);
        public Task<IEnumerable<AlumnosModel>> FiltroNIvelEscolar(string nivelEducativo);

        public Task<EditarAlumnoContactoModel> ObtenerAlumnoContacto(int IdAlumno);

        public Task<bool> ActualizarDatosAlumno(EditarAlumnoContactoModel editarAlumnoContactoModel);
    }
}
