using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NetCoders.Agenda.Model;
using NetCoders.Agenda.DataAccess;

namespace NetCoders.Agenda.Repository
{
    public sealed class AgendaREP
    {
        private AGENDAEntities DataBase { get; set; }

        public void Inserir(AgendaMOD _model)
        {
            var tbAgenda = new T_AG_AGENDA
            {
                TT_AGENDA = _model.Titulo,
                DS_SIMPLES = _model.DescricaoSimples,
                DS_COMPLETA = _model.DescricaoCompleta,
                DT_AGENDA = _model.Data,
                DT_INSERIDO = DateTime.Now
            };
            using (DataBase = new AGENDAEntities())
            {
                DataBase.T_AG_AGENDA.Add(tbAgenda);
                DataBase.SaveChanges();
            }
        }

        public IEnumerable<AgendaMOD> Listar()
        {
            using (DataBase = new AGENDAEntities())
            {
                return DataBase.T_AG_AGENDA.ToList().ConvertAll(m => new AgendaMOD
                {
                    Codigo = m.ID_AGENDA,
                    Titulo = m.TT_AGENDA,
                    DescricaoSimples = m.DS_SIMPLES,
                    DescricaoCompleta = m.DS_COMPLETA,
                    Data = m.DT_AGENDA,
                    Gravado = m.DT_INSERIDO
                });
            }
        }

        public AgendaMOD Buscar(int id)
        {
            using (DataBase = new AGENDAEntities())
            {
                var query = DataBase.T_AG_AGENDA.Find(id);

                return new AgendaMOD
                {
                    Codigo = query.ID_AGENDA,
                    Titulo = query.TT_AGENDA,
                    DescricaoSimples = query.DS_SIMPLES,
                    DescricaoCompleta = query.DS_COMPLETA,
                    Data = query.DT_AGENDA,
                    Gravado = query.DT_INSERIDO
                };
            }
        }
    }
}
