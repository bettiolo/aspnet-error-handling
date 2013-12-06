using System;
using System.Diagnostics;
using System.Web;

namespace AspNetErrorHandling.WebForms
{
	public static class Logger
	{
		public static void Log(LogLocation logLocation, string method, string message = "")
		{
			var prefix = logLocation + "." + method;
			var request = GetRequest();
			if (request != null)
			{
				prefix += " [" + request.AppRelativeCurrentExecutionFilePath + "]";
			}
			if (!string.IsNullOrWhiteSpace(message))
			{
				Debug.WriteLine(prefix + " " + message);
			}
			else
			{
				Debug.WriteLine(prefix);
			}
		}

		private static HttpRequest GetRequest()
		{
			var context = HttpContext.Current;
			if (context == null) return null;

			if (!HttpRuntime.UsingIntegratedPipeline)
			{
				// In classic mode the request is always present
				return context.Request;
			}
			try
			{
				// In integrated mode on Application_Start the request throws HttpException
				return context.Request;
			}
			catch (HttpException ex)
			{
				// Do not use message comparison - .NET translates messages for multi-culture environments.
				return null;
			}
		}
	}

	public enum LogLocation
	{
		Master,
		Page,
		Application
	}

}