#region

using System;

#endregion

namespace BTL.Infrastructure.Plugins
{
    public interface IModule
    {
        string Title { get; }

        string Name { get; }

        Version Version { get; }

        string EntryControllerName { get; }
    }
}