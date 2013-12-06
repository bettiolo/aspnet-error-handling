using System;
using System.Net;
using System.Web;

namespace AspNetErrorHandling.WebForms
{
	public class Global : HttpApplication
	{
		void Application_Start(object sender, EventArgs e)
		{
			Logger.Log(LogLocation.Application, "Start");
			// throw new Exception("Error in Application Start");
		}

		void Application_End(object sender, EventArgs e)
		{
			Logger.Log(LogLocation.Application, "End");
		}

		void Application_Error(object sender, EventArgs e)
		{
			var lastException = Context.Server.GetLastError().InnerException ?? Context.Server.GetLastError();
			Logger.Log(LogLocation.Application, "Error", lastException.Message);

			// throw new Exception("Error in Application Error");

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
			// throw new Exception("Error in Application BeginRequest");
		}

		void Application_EndRequest(object sender, EventArgs e)
		{
			Logger.Log(LogLocation.Application, "EndRequest");
			// throw new Exception("Error in Application EndRequest");
		}
	}
}
