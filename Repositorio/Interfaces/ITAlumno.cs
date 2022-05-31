using SistemaEscolar.Models;

namespace SistemaEscolar.Repositorio.Interfaces
{
    public interface ITAlumno
    {
        public Task<int> AltaAlumno(CrearAlumnoModel crearAlumnoModel);
        public Task<bool> AltaContacto(CrearContactoModel crearContactoModel);
    }
}
