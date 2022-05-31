using Dapper;
using Microsoft.Data.SqlClient;
using SistemaEscolar.Conexiones;
using SistemaEscolar.Models;
using SistemaEscolar.Repositorio.Interfaces;

namespace SistemaEscolar.Repositorio
{
    public class TAlumnos : ITAlumno
    {
        private readonly string _cadenaConexion;

        public TAlumnos(IConfiguration configuration)
        {
            _cadenaConexion = configuration.GetConnectionString(ConexionSql.conexionBaseDatos);
        }

        public async Task<int> AltaAlumno(CrearAlumnoModel crearAlumnoModel)
        {
            using var conexion = new SqlConnection(_cadenaConexion);

            int idAlum = await conexion.QuerySingleAsync<int>(@"INSERT INTO ALUMNO VALUES(@Nombre,@ApellidoPaterno,
            @ApellidoMaterno,@Matricula,@Curp,@FechaIngreso,@Estatus,@GradoEscolar,@NivelEducativo);
            SELECT SCOPE_IDENTITY();", crearAlumnoModel);

            return idAlum;
        }

        public async Task<bool> AltaContacto(CrearContactoModel crearContactoModel)
        {
            using var conexion = new SqlConnection(_cadenaConexion);

            var idContacto = await conexion.QuerySingleAsync<int>(@"INSERT INTO Contactos VALUES(@IdAlumno,@Nombre,@ApellidoPaterno,@ApellidoMaterno,@Telefono,
@Calle,@Colonia,@NumeroExterior,@NumeroInterior,@CodigoPostal,@Estado);
SELECT SCOPE_IDENTITY();", crearContactoModel);

            return true;
        }

        //using var conexion = new SqlConnection(_cadenaConexion);
    }
}
