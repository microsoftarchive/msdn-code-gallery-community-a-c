using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalizeDataAnnotations.Models
{
    public interface IPersona
    {
        string Nombre { get; set; }
        string Apellido { get; set; }
        string Ciudad { get; set; }
        string Email { get; set; }
    }
}
