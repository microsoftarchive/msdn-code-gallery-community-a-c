using System;

namespace BTL.Application.Web.Models
{
    [Serializable]
    public class HomeIndexViewModel
    {
        public HomeIndexViewModel()
        {
            Theme = new ThemeViewModel();
        }

        public ThemeViewModel Theme { get; set; }
    }
}