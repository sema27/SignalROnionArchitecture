using Microsoft.AspNetCore.Mvc;

namespace SignalROnionArchitecture.Presentation.WebUI.Controllers

{
    public class ProgressBarsController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
