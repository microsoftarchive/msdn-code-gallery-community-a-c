#region

using System;
using System.Reflection;
using BTL.Infrastructure;
using BTL.Infrastructure.Plugins;

#endregion

namespace BTL.Application.UserAuthoring
{
    public class UserAuthoringModule : IModule
    {
        public string Title
        {
            get { return "User Authoring"; }
        }

        public string Name
        {
            get { return Assembly.GetAssembly(GetType()).GetName().Name; }
        }

        public Version Version
        {
            get { return new Version(1, 0, 0, 0); }
        }

        public string EntryControllerName
        {
            get { return "User"; }
        }
    }
}