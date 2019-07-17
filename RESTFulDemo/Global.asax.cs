using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

using System.Web.Routing;
using System.ServiceModel.Activation;

namespace RESTFulDemo
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            // this is where to create the url for UriTemplate
            // So I have http://192.168.170.19:8092/RestService/ or https://192.168.170.19:448/RestService/
            RouteTable.Routes.Add(new ServiceRoute("RestService", new WebServiceHostFactory(), typeof(RESTSerivce)));
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