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

        public async Task<bool> ActualizarDatosAlumno(EditarAlumnoContactoModel editarAlumnoContactoModel)
        {
            using var conexion = new SqlConnection(_cadenaConexion);

            await conexion.ExecuteAsync("update Contactos set nombreContacto = @nombreContacto,apellidoPaternoContacto = @apellidoPaternoContacto," +
                "apellidoMaternoContacto = @apellidoMaternoContacto, telefono = @telefono, colonia = @colonia, numeroExterior = @numeroExterior," +
                "numeroInterior = @numeroInterior, codigoPostal = @codigoPostal, estado = @estado, parentesco = @parentesco" +
                " where idAlumno = @idAlumno", editarAlumnoContactoModel);

            await conexion.ExecuteAsync("update Alumno set gradoEscolar = @gradoEscolar, nivelEducativo = @nivelEducativo, fechaBaja = @fechaBaja " +
                "where Alumno.idAlumno = @idAlumno", editarAlumnoContactoModel);

            return true;
        }

        public async Task<int> AltaAlumno(CrearAlumnoModel crearAlumnoModel)
        {
            using var conexion = new SqlConnection(_cadenaConexion);

            int idAlum = await conexion.QuerySingleAsync<int>(@"INSERT INTO ALUMNO VALUES(@NombreAlumno,@ApellidoPaternoAlumno,
            @ApellidoMaternoAlumno,@Matricula,@Curp,@FechaIngreso,null,@Estatus,@GradoEscolar,@NivelEducativo);
            SELECT SCOPE_IDENTITY();", crearAlumnoModel);

            return idAlum;
        }

        public async Task<bool> AltaContacto(CrearContactoModel crearContactoModel)
        {
            using var conexion = new SqlConnection(_cadenaConexion);

            var idContacto = await conexion.QuerySingleAsync<int>(@"INSERT INTO Contactos VALUES(@IdAlumno,@NombreContacto,@ApellidoPaternoContacto,@ApellidoMaternoContacto,@Telefono,
                @Calle,@Colonia,@NumeroExterior,@NumeroInterior,@CodigoPostal,@Estado,@Parentesco);
                SELECT SCOPE_IDENTITY();", crearContactoModel);

            return true;
        }

        public async Task<EditarAlumnoContactoModel> ObtenerAlumnoContacto(int IdAlumno)
        {
            using var conexion = new SqlConnection(_cadenaConexion);

            return await conexion.QueryFirstOrDefaultAsync<EditarAlumnoContactoModel>("select Alumno.idAlumno,Alumno.NombreAlumno,Alumno.fechaBaja,Alumno.ApellidoPaternoAlumno,Alumno.ApellidoMaternoAlumno, Alumno.gradoEscolar,Alumno.nivelEducativo, " +
                "Contactos.idContacto,Contactos.nombreContacto,Contactos.apellidoPaternoContacto,Contactos.apellidoMaternoContacto, Contactos.calle,Contactos.colonia," +
                "Contactos.numeroExterior,Contactos.numeroInterior, Contactos.telefono,Contactos.codigoPostal,Contactos.estado,Contactos.parentesco " +
                "from Alumno inner join Contactos " +
                "on Alumno.idAlumno = Contactos.idAlumno where Alumno.idAlumno = @IdAlumno", new { IdAlumno });
        }

        public async Task<IEnumerable<AlumnosModel>> ObtenerAlumnos()
        {
            using var conexion = new SqlConnection(_cadenaConexion);
            return await conexion.QueryAsync<AlumnosModel>("SELECT * FROM Alumno inner join Contactos on Alumno.idAlumno = Contactos.idAlumno");
        }

        public async Task<IEnumerable<AlumnosModel>> FiltroGradoEscolar(string gradoEscolar)
        {
            using var conexion = new SqlConnection(_cadenaConexion);
            return await conexion.QueryAsync<AlumnosModel>("SELECT * FROM Alumno inner join Contactos on Alumno.idAlumno = Contactos.idAlumno where Alumno.gradoEscolar = @gradoEscolar", new { gradoEscolar });
        }

        public async Task<IEnumerable<AlumnosModel>> FiltroNIvelEscolar(string nivelEducativo)
        {
            using var conexion = new SqlConnection(_cadenaConexion);
            return await conexion.QueryAsync<AlumnosModel>("SELECT * FROM Alumno inner join Contactos on Alumno.idAlumno = Contactos.idAlumno where Alumno.nivelEducativo = @nivelEducativo", new { nivelEducativo });
        }

        public async Task<bool> CrearCuentaUsuario(CrearCuenta crearCuenta)
        {
            using var conexion = new SqlConnection(_cadenaConexion);

            var resultado = await conexion.QuerySingleAsync<int>("INSERT INTO CUENTAS VALUES (@Correo,@Password);" +
                "SELECT SCOPE_IDENTITY();", crearCuenta);

            return true;
        }

        public async Task<bool> LoginCuenta(LoginModel loginModel)
        {
            using var conexion = new SqlConnection(_cadenaConexion);

            var resultado = await conexion.QueryFirstOrDefaultAsync<bool>(@"select * from Cuentas where Correo = @Correo and Password = @Password", loginModel);

            return resultado;
        }

        //using var conexion = new SqlConnection(_cadenaConexion);
    }
}
