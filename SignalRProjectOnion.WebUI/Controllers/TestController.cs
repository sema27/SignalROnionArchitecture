using Microsoft.AspNetCore.Mvc;

namespace SignalROnionArchitecture.Presentation.WebUI.Controllers

{
    public class TestController : Controller
    {
        public IActionResult Sepet()
        {
            return View();
        }
    }
}