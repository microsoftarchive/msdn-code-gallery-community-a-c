using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;

namespace WebApiAuthentication.Modules
{
    public class BasicAuthHttpModule : IHttpModule
    {
        private const string Realm = "WebAPI Authentication";

        public void Init(HttpApplication context)
        {
            // Se registran los manejadores de los eventos
            context.AuthenticateRequest += OnApplicationAuthenticateRequest;
            context.EndRequest += OnApplicationEndRequest;
        }

        private static void SetPrincipal(IPrincipal principal)
        {
            Thread.CurrentPrincipal = principal;
            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = principal;
            }
        }

        private static bool AuthenticateUser(string credentials)
        {
            var encoding = Encoding.GetEncoding("iso-8859-1");
            credentials = encoding.GetString(Convert.FromBase64String(credentials));

            var credentialsArray = credentials.Split(':');
            var username = credentialsArray[0];
            var password = credentialsArray[1];

            /* Aquí se validan las credenciales o el token enviado en el encabezado de la solicitud */
            if (!(username == "test" && password == "test"))
            {
                return false;
            }

            var identity = new GenericIdentity(username);
            SetPrincipal(new GenericPrincipal(identity, null));

            return true;
        }

        private static void OnApplicationAuthenticateRequest(object sender, EventArgs e)
        {
            var request = HttpContext.Current.Request;
            var authHeader = request.Headers["Authorization"];
            if (authHeader != null)
            {
                var authHeaderVal = AuthenticationHeaderValue.Parse(authHeader);

                // Se valida si el esquema de autenticación es básico (Basic Authentication)
                if (authHeaderVal.Scheme.Equals("basic", StringComparison.OrdinalIgnoreCase) && authHeaderVal.Parameter != null)
                {
                    AuthenticateUser(authHeaderVal.Parameter);
                }
            }
        }

        // Si la solicitud no fue aprobada, se agrega el encabezado WWW-Authenticate a la respuesta
        
        private static void OnApplicationEndRequest(object sender, EventArgs e)
        {
            var response = HttpContext.Current.Response;
            if (response.StatusCode == 401)
            {
                response.Headers.Add("WWW-Authenticate", string.Format("Basic realm=\"{0}\"", Realm));
            }
        }

        public void Dispose()
        {
        }
    }
}