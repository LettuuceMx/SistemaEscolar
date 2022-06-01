using System.ComponentModel.DataAnnotations;

namespace SistemaEscolar.Models
{
    public class CrearAlumnoModel
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string NombreAlumno { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string ApellidoPaternoAlumno { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string ApellidoMaternoAlumno { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Matricula { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Curp { get; set; }

        [Display(Name = "Fecha Ingreso")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public DateTime FechaIngreso { get; set; } = DateTime.Today; 

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Estatus { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string GradoEscolar { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string NivelEducativo { get; set; }
    }
}
