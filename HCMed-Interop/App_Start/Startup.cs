using HCMed_Interop.Data;
using HCMed_Interop.Data.Entities;
using HCMed_Interop.Data.Manager;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using SysHC.Utils.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCMed_Interop
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(AppContext.Create);
            app.CreatePerOwinContext<EstadoManager>(EstadoManager.Create);
            app.CreatePerOwinContext<CidadeManager>(CidadeManager.Create);
            app.CreatePerOwinContext<BairroManager>(BairroManager.Create);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                CookieName = SysHC.Utils.Geral.Aplicacao.CookieName,
                CookieDomain = System.Configuration.ConfigurationManager.AppSettings["DominioApp"],
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                Provider = new CookieAuthenticationProvider { OnApplyRedirect = ApplyRedirect },
                TicketDataFormat = new SysHC.Utils.Geral.CustomJwtDataFormat()
            });

        }

        private static void ApplyRedirect(CookieApplyRedirectContext context)
        {
            Uri absoluteUri;
            if (Uri.TryCreate(context.RedirectUri, UriKind.Absolute, out absoluteUri))
            {
                string domain = System.Configuration.ConfigurationManager.AppSettings["DominioApp"];
                string ambiente = System.Configuration.ConfigurationManager.AppSettings["Ambiente"];
                string appUrl = "localhost";
                ambiente = string.IsNullOrEmpty(ambiente) ? "DESENVOLVIMENTO" : ambiente.ToUpper();

                if (ambiente == "HOMOLOGAÇÃO")
                    appUrl = "sistemashchomolog." + domain;
                else if (ambiente == "PRODUÇÃO")
                    appUrl = "sistemashc." + domain;

                var path = PathString.FromUriComponent(absoluteUri);
                if (path == context.OwinContext.Request.PathBase + context.Options.LoginPath)
                    context.RedirectUri = SysHC.Utils.Geral.Aplicacao.UrlLogin +
                        new QueryString(
                            context.Options.ReturnUrlParameter,
                            context.Request.Uri.AbsoluteUri);
            }

            context.Response.Redirect(context.RedirectUri);
        }
    }
}