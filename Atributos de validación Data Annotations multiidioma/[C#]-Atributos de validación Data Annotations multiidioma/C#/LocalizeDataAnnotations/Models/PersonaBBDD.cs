using LocalizeDataAnnotations.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LocalizeDataAnnotations.Models
{
    public class PersonaBBDD: IPersona
    {
        [Required(ErrorMessageResourceName = "NombreObligatorio"
            , ErrorMessageResourceType = typeof(TextosLoader))]
        [Display(Name = "Nombre", ResourceType = typeof(TextosLoader))]
        public string Nombre { get; set; }

        [Display(Name = "Apellido", ResourceType = typeof(TextosLoader))]
        public string Apellido { get; set; }

        [Display(Name = "Ciudad", ResourceType = typeof(TextosLoader))]
        [StringLength(20, MinimumLength = 4, ErrorMessageResourceName = "CiudadErrorLongitud"
            , ErrorMessageResourceType = typeof(TextosLoader))]
        public string Ciudad { get; set; }

        [Display(Name = "Email", ResourceType = typeof(TextosLoader))]
        public string Email { get; set; }

    }
}