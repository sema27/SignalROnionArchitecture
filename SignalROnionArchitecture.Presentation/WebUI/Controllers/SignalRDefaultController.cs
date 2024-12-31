using Microsoft.AspNetCore.Mvc;

namespace SignalROnionArchitecture.Presentation.WebUI.Controllers

{
    public class SignalRDefaultController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

        public IActionResult Index2()
        {
            return View();
        }
    }
}
