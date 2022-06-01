namespace SistemaEscolar.Models
{
    public class ModeloMultiple
    {
        public CrearAlumnoModel CrearAlumnoModel { get; set; }
        public CrearContactoModel CrearContactoModel { get; set; }
        public EditarAlumnoContactoModel EditarAlumnoContactoModel { get; set; }
        public IEnumerable<AlumnosModel> IEnumerableAlumnos { get; set; }
    }
}
