using System;
using System.Configuration;
using System.Net;
using System.Web;
using System.Web.Routing;

namespace AspNetErrorHandling.WebForms
{
	public class Global : HttpApplication
	{
		void Application_Start(object sender, EventArgs e)
		{
			Logger.Log(LogLocation.Application, "Start");
			RouteConfig.RegisterRoutes(RouteTable.Routes);
		}

		void Application_End(object sender, EventArgs e)
		{
			Logger.Log(LogLocation.Application, "End");
		}

		void Application_Error(object sender, EventArgs e)
		{
			var lastException = Context.Server.GetLastError().InnerException ?? Context.Server.GetLastError();

			var message = string.Format("Unhandled exception in API: {0}", Request.Url.PathAndQuery);
			Logger.Log(LogLocation.Application, "Start", message);
			Logger.Log(LogLocation.Application, "Start", lastException.Message);

			Response.Clear();
			Response.WriteFile("~/static/Error.html");
			Response.StatusCode = (int)HttpStatusCode.InternalServerError;
			Response.ContentType = "text/html";
			Server.ClearError();
			Response.End();
		}

		void Application_BeginRequest(object sender, EventArgs e)
		{
			Logger.Log(LogLocation.Application, "BeginRequest");
		}

		void Application_EndRequest(object sender, EventArgs e)
		{
			Logger.Log(LogLocation.Application, "EndRequest");
		}
	}
}
