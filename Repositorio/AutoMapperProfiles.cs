using AutoMapper;
using SistemaEscolar.Models;

namespace SistemaEscolar.Repositorio
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CrearAlumnoModel, CrearAlumnoModel>();
        }
    }
}
