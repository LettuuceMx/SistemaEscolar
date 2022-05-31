using System.ComponentModel.DataAnnotations;

namespace SistemaEscolar.Models
{
    public class CrearContactoModel
    {
        public int IdAlumno { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string ApellidoPaterno { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string ApellidoMaterno { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Calle { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Colonia { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string NumeroExterior { get; set; }
        public string NumeroInterior { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string CodigoPostal { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Parentesco { get; set; }
    }
}
