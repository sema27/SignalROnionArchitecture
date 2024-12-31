using Microsoft.AspNetCore.Mvc;

namespace SignalROnionArchitecture.Presentation.WebUI.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
