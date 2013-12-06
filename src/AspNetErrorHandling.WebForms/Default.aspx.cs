using System;
using System.Web.UI;

namespace AspNetErrorHandling.WebForms
{
	public partial class _Default : Page
	{
		protected void Page_Init(object sender, EventArgs e)
		{
			Logger.Log(LogLocation.Page, "Init");
			// throw new Exception("Error in Page Init");
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			Logger.Log(LogLocation.Page, "Load");
			// throw new Exception("Error in Page Load");
		}
	}
}