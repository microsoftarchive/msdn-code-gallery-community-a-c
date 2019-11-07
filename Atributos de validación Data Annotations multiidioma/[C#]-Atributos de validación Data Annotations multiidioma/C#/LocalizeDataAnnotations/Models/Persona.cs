using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LocalizeDataAnnotations.Models
{
    public class Persona: IPersona
    {

        [Required(ErrorMessage = "Debe introducir un nombre")]
        [DisplayName("Nombre")]
        public string Nombre { get; set; }

        [DisplayName("Apellido")]
        public string Apellido { get; set; }

        [DisplayName("Ciudad")]
        [StringLength(20, MinimumLength=4, ErrorMessage="El nombre de Ciudad debe tener una longitud entre 4 y 20 caracteres")]
        public string Ciudad { get; set; }

        [DisplayName("Correo electrónico")]
        public string Email { get; set; }

    }
}