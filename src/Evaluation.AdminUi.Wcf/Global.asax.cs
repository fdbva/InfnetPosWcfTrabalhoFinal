using System;
using System.Reflection;
using System.Web;
using Evaluation.Infrastructure.CrossCutting;

namespace Evaluation.AdminUi.Wcf
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            //// Create the container as usual.
            //var container = new Container();
            //container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            //// Register WCF services.
            //container.RegisterWcfServices(Assembly.GetExecutingAssembly());

            //// Register your types, for instance:
            //SimpleInjectorBootstrapper.RegisterServices(container);

            //// Register the container to the SimpleInjectorServiceHostFactory.
            //SimpleInjectorServiceHostFactory.SetContainer(container);
        }

        protected void Session_Start(object sender, EventArgs e)
        {
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
        }

        protected void Application_Error(object sender, EventArgs e)
        {
        }

        protected void Session_End(object sender, EventArgs e)
        {
        }

        protected void Application_End(object sender, EventArgs e)
        {
        }
    }
}