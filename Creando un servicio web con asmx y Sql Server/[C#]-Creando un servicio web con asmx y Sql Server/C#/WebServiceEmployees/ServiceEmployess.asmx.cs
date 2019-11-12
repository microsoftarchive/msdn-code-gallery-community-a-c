using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

using System.Xml.Serialization;

namespace WebServiceEmployees
{
    /// <summary>
    /// Descripción breve de ServiceEmployess
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, 
    //usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class ServiceEmployess : System.Web.Services.WebService
    {
        DataEmployeesModel dataEmployess = new DataEmployeesModel();
        [WebMethod]
        public DataSet getEmployees()
        {
            return dataEmployess.getEmployees();
        }
    }
}
