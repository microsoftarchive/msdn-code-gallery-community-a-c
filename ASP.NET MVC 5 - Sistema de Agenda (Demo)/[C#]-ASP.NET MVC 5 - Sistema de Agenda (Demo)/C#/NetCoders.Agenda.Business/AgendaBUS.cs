using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NetCoders.Agenda.Model;
using NetCoders.Agenda.Repository;

namespace NetCoders.Agenda.Business
{
    public sealed class AgendaBUS
    {
        private readonly AgendaREP repository_;

        public Action<string, string> _mensagem;

        public AgendaBUS()
        {
            repository_ = new AgendaREP();
        }

        public void Inserir(AgendaMOD _model)
        {
            try
            {
                repository_.Inserir(_model);
                _mensagem("Evento gravado com sucesso!", "sucesso");
            }
            catch (Exception)
            {
                _mensagem("Ops!, Ocorreu um erro. Entre em contato com o administrador do sistema", "erro");
            }
        }

        public IEnumerable<AgendaMOD> Listar()
        {
            try
            {
                return repository_.Listar();
            }
            catch (Exception)
            {
                _mensagem("Ops!, Ocorreu um erro. Entre em contato com o administrador do sistema", "erro");
                return null;
            }
            
        }

        public AgendaMOD Buscar(int id)
        {
            try
            {
                return repository_.Buscar(id);
            }
            catch (Exception)
            {
                _mensagem("Ops!, Ocorreu um erro. Entre em contato com o administrador do sistema", "erro");
                return new AgendaMOD();
            }


        }
    }
}