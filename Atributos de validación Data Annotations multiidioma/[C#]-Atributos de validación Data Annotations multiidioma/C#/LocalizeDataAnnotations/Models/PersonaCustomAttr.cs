using LocalizeDataAnnotations.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocalizeDataAnnotations.Models
{
    public class PersonaCustomAttr : IPersona
    {
        [CustomRequired(ErrorMessageResourceName = "NombreObligatorio")]
        [CustomDisplay("Nombre")]
        public string Nombre { get; set; }

        [CustomDisplay("Apellido")]
        public string Apellido { get; set; }

        [CustomDisplay("Ciudad")]
        [CustomStringLength(20, MinimumLength = 4, ErrorMessageResourceName = "CiudadErrorLongitud")]
        public string Ciudad { get; set; }

        [CustomDisplay("Email")]
        public string Email { get; set; }
    }
}