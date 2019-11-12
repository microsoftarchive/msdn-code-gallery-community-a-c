#region

using System;
using System.Collections.Generic;

#endregion

namespace BTL.Application.Web.Models
{
    [Serializable]
    public class ThemeViewModel
    {
        public ThemeViewModel()
        {
            Themes = new List<string>();
        }

        public string SelectedTheme { get; set; }

        public List<string> Themes { get; set; }
    }
}