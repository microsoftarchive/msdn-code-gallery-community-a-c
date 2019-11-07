using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NetCoders.Agenda.Model;

namespace NetCoders.Agenda.UI.Web.Models
{
    public sealed class AgendaVM
    {
        public AgendaMOD Agenda { get; set; }
        public IEnumerable<AgendaMOD> Agendas { get; set; }
    }
}