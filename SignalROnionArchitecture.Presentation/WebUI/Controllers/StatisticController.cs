using Microsoft.AspNetCore.Mvc;

namespace SignalROnionArchitecture.Presentation.WebUI.Controllers

{
    public class StatisticController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
