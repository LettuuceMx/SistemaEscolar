using System.ComponentModel.DataAnnotations;

namespace SistemaEscolar.Models
{
    public class EditarAlumnoContactoModel
    {
        //Alumno
        public int IdAlumno { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string NombreAlumno { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string ApellidoPaternoAlumno { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string ApellidoMaternoAlumno { get; set; }

        //[DataType(DataType.Date)]
        public string FechaBaja { get; set; }
        public bool estaDeBaja { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string GradoEscolar { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string NivelEducativo { get; set; }

        //Contacto
        public int IdContacto { get; set; }


        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string NombreContacto { get; set; }


        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string ApellidoPaternoContacto { get; set; }


        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string ApellidoMaternoContacto { get; set; }


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
