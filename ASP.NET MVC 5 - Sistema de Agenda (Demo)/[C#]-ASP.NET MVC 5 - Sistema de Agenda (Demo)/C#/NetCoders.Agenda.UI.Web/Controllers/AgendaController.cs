using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NetCoders.Agenda.Model;
using NetCoders.Agenda.UI.Web.Models;
using NetCoders.Agenda.Business;

namespace NetCoders.Agenda.UI.Web.Controllers
{
    public class AgendaController : Controller
    {
        private readonly AgendaBUS business_;
        private static AgendaVM _viewModel;

        public AgendaController()
        {
            business_ = new AgendaBUS();
            _viewModel = new AgendaVM { Agendas = business_.Listar() };
            business_._mensagem += (msg_, tipo_) => CriarTempData(msg_, tipo_);
        }

        [NonAction]
        private void CriarTempData(string msg_, string tipo_)
        {
            TempData[tipo_] = msg_;
        }

        public ViewResult Listar()
        {
            return View(_viewModel);
        }

        public ViewResult Cadastrar()
        {
            return View();
        }

        public ViewResult Detalhes(int id)
        {
            _viewModel.Agenda = business_.Buscar(id);

            return View(_viewModel);
        }

        public ActionResult Inserir(AgendaVM _model)
        {
            business_.Inserir(_model.Agenda);
            return RedirectToAction("Listar");
        }
    }
}