using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Web;

namespace LocalizeDataAnnotations.Infrastructure
{
    public static class TextosBBDD
    {

        private static DataTable _textos;

        public static string Recuperar(string textoID)
        {
            if (_textos == null)
            {
                _textos = new DataTable();
                _textos.ReadXml(HttpContext.Current.Server.MapPath("~/Content/Textos.xml"));
            }
            string idioma = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;
            if (idioma != "en") idioma = "es";
            DataRow row = _textos.Rows.Find(new object[] { textoID, idioma });
            if (row != null)
                return row["Texto"].ToString();
            else
                return null;
        }

    }
}