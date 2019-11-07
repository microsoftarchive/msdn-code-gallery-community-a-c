#region

using System;
using System.Diagnostics;
using System.Web.Mvc;
using Autofac;

#endregion

namespace BTL.Application.Web.Infrastructure.Controller
{
    public class ExControllerFactory : DefaultControllerFactory
    {
        private readonly IContainer _container;

        public ExControllerFactory(IContainer container)
        {
            _container = container;
        }

        [DebuggerStepThrough]
        protected override Type GetControllerType(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            var controller = base.GetControllerType(requestContext, controllerName);
            if (controller == null)
            {
                object x;
                if (_container.TryResolveNamed(controllerName, typeof (IController), out x))
                    controller = x.GetType();
            }

            return controller;
        }
    }
}