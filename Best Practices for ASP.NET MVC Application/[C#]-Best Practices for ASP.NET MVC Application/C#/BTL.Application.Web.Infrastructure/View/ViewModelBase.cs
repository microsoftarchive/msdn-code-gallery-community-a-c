#region

using System;

#endregion

namespace BTL.Application.Web.Infrastructure.View
{
    public abstract class ViewModelBase : IViewModelBase
    {
        #region IViewModelBase Members

        public bool ReadOnly { get; set; }

        #endregion
    }

    public interface IViewModelBase
    {
        bool ReadOnly { get; set; }
    }

    public class ErrorViewModel
    {
        public string ErrorMessage { get; set; }

        public Exception TheException { get; set; }
    }
}