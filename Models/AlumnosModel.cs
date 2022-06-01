namespace SistemaEscolar.Models
{
    public class AlumnosModel
    {
        public int IdAlumno { get; set; }
        public string NombreAlumno { get; set; }
        public string ApellidoPaternoAlumno { get; set; }
        public string ApellidoMaternoAlumno { get; set; }
        public string Matricula { get; set; }
        public string Curp { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string FechaBaja { get; set; }
        public string Estatus { get; set; }
        public string GradoEscolar { get; set; }
        public string NivelEducativo { get; set; }

        public int IdContacto { get; set; }
        public string NombreContacto { get; set; }
        public string ApellidoPaternoContacto { get; set; }
        public string ApellidoMaternoContacto { get; set; }
        public string Telefono { get; set; }
        public string Calle { get; set; }
        public string Colonia { get; set; }
        public string NumeroExterior { get; set; }
        public string NumeroInterior { get; set; }
        public string CodigoPostal { get; set; }
        public string Estado { get; set; }
        public string Parentesco { get; set; }
    }
}
