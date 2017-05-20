using Microsoft.Owin;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(LojaAPI.App_Start.API.Startup))]
namespace LojaAPI.App_Start.API {

    public class Startup {

        public void Configuration(IAppBuilder app) {
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
            app.UseWebApi(config);
        }
    }
}