#region

using System;
using System.Linq;
using System.Web.Mvc;
using BTL.Application.UserAuthoring.Models;
using BTL.Application.Web.Infrastructure;
using BTL.DataAccess;
using BTL.Domain.Core.UserManagement;

#endregion

namespace BTL.Application.UserAuthoring.Controllers
{
    [UnitOfWork]
    public class UserController : Controller
    {
        private readonly IRepository<User> _repository;

        public UserController()
            : this(DependencyResolver.Current.GetService<IRepository<User>>())
        {
        }

        public UserController(IRepository<User> repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            var viewModel = new UserListViewModel();
            viewModel.Users = _repository.All().ToList();

            return View(viewModel);
        }
    }
}