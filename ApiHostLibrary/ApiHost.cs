using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// by CSC
using System.Web.Http;
using Microsoft.Owin.Hosting;
using System.Net.Http;
using Owin;

// external links
// http://www.asp.net/web-api/overview/releases/whats-new-in-aspnet-web-api-22
// http://www.asp.net/web-api/overview/hosting-aspnet-web-api/use-owin-to-self-host-web-api

namespace ApiHostLibrary
{
    public class ApiHost : IDisposable
    {
        private string _baseAddress;
        private IDisposable _app;
        private bool _disposed;

        /// <summary>
        /// Standard C'tor
        /// </summary>
        public ApiHost(int port = 9000)
        {
            _baseAddress = String.Format("http://localhost:{0}/", port);

            // Start OWIN host 
            _app = WebApp.Start<Startup>(url: _baseAddress);

        }

        public string Testquery()
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync(_baseAddress + "api/values").Result;

            var res = response + Environment.NewLine + response.Content.ReadAsStringAsync().Result;

            return res;
        }

        #region DISPOSE
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!_disposed)
            {
                // If disposing equals true, dispose all managed
                // and unmanaged resources.
                if (disposing)
                {
                    _app.Dispose();
                }

                // Call the appropriate methods to clean up
                // unmanaged resources here.

                // Note disposing has been done.
                _disposed = true;
            }
        }

        #endregion
    }

    /// <summary>
    /// Startup Class - Taken from the example code
    /// </summary>
    public class Startup
    {
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            appBuilder.UseWebApi(config);

        }
    }
}
