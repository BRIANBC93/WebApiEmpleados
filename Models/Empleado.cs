using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiEmpleados.Models
{
    public class Empleado
    {
        public int EmpleadoID { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        [StringLength(50, ErrorMessage = "El campo Nombre no puede tener más de 50 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Apellido Paterno es obligatorio.")]
        [StringLength(50, ErrorMessage = "El campo Apellido Paterno no puede tener más de 50 caracteres.")]
        public string ApellidoPaterno { get; set; }

        [Required(ErrorMessage = "El campo Apellido Materno es obligatorio.")]
        [StringLength(50, ErrorMessage = "El campo Apellido Materno no puede tener más de 50 caracteres.")]
        public string ApellidoMaterno { get; set; }

        [Required(ErrorMessage = "El campo Edad es obligatorio.")]
        [Range(18, 99, ErrorMessage = "La Edad debe estar entre 18 y 99 años.")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "El campo FechaNacimiento es obligatorio.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaNacimiento { get; set; }
        [RegularExpression("^(Masculino|Femenino)$", ErrorMessage = "El campo Género debe ser 'Masculino' o 'Femenino'.")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "El campo Estado Civil es obligatorio.")]
        public string EstadoCivil { get; set; }

        [Required(ErrorMessage = "El campo RFC es obligatorio.")]
        [RFCValidation(ErrorMessage = "El RFC no cumple con el formato válido.")]
        public string RFC { get; set; }


        [Required(ErrorMessage = "El campo Direccion es obligatorio.")]
        [StringLength(200, ErrorMessage = "El campo Dirección no debe tener más de 200 caracteres.")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El campo Email es obligatorio.")]
        [EmailAddress(ErrorMessage = "El campo Email debe ser una dirección de correo electrónico válida.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo Teléfono es obligatorio.")]
        [StringLength(15, MinimumLength = 8, ErrorMessage = "El campo Teléfono debe tener entre 8 y 15 caracteres.")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El campo Puesto es obligatorio.")]
        [StringLength(50, ErrorMessage = "El campo Puesto no debe tener más de 50 caracteres.")]
        public string Puesto { get; set; }

        [Required(ErrorMessage = "El campo FechaAlta es obligatorio.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaAlta { get; set; }

        // Permite valores nulos para la fecha de baja
        public DateTime? FechaBaja { get; set; }
    }
}
