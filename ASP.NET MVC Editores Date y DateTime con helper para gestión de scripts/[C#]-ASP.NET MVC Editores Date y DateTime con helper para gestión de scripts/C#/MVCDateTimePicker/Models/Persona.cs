using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCDateTimePicker.Models
{
    public class Persona
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Ciudad { get; set; }
        [Display(Name="Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }
        [Display(Name="Último Acceso")]
        public DateTime UltimoAcceso { get; set; }
        [Display(Name="Fecha de Registro")]
        [DataType(DataType.Date)]
        public DateTime FechaRegistro { get; set; }
        [Display(Name = "Última Operación")]
        public DateTime UltimaOperacion { get; set; }
    }
}