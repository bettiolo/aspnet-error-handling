using System;
using System.Web.UI;

namespace AspNetErrorHandling.WebForms
{
	public partial class SiteMaster : MasterPage
	{
		protected void Page_Init(object sender, EventArgs e)
		{
			Logger.Log(LogLocation.Master, "Init");
			// throw new Exception("Error in Master Init");
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			Logger.Log(LogLocation.Master, "Load");
			// throw new Exception("Error in Master Init");
		}
	}
}