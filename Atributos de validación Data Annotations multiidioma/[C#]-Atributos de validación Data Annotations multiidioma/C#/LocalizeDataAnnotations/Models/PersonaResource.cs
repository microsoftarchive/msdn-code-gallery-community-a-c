using LocalizeDataAnnotations.Content;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LocalizeDataAnnotations.Models
{
    public class PersonaResource: IPersona
    {

        [Required(ErrorMessageResourceName = "NombreObligatorio", ErrorMessageResourceType = typeof(Textos))]
        [Display(Name="Nombre", ResourceType=typeof(Textos))]
        public string Nombre { get; set; }

        [Display(Name = "Apellido", ResourceType = typeof(Textos))]
        public string Apellido { get; set; }

        [Display(Name = "Ciudad", ResourceType = typeof(Textos))]
        [StringLength(20, MinimumLength = 4, ErrorMessageResourceName="CiudadErrorLongitud", ErrorMessageResourceType=typeof(Textos))]
        public string Ciudad { get; set; }

        [Display(Name = "Email", ResourceType = typeof(Textos))]
        public string Email { get; set; }

    }
}