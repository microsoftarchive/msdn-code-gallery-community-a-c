#region

using System.IO;
using System.Linq;
using System.Web;

#endregion

namespace BTL.Application.Web.Infrastructure.Themes
{
    public class ThemeProvider : IThemeProvider
    {
        #region IThemeProvider Members

        public string[] GetThemes()
        {
            var themeFolder = new DirectoryInfo(HttpContext.Current.Server.MapPath("~/Themes"));
            var themes = themeFolder.GetDirectories().Select(x => x.Name).OrderBy(x => x).ToArray();
            return themes;
        }

        #endregion
    }
}