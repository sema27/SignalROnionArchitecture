using Microsoft.AspNetCore.Mvc;

namespace SignalROnionArchitecture.Presentation.WebUI.ViewComponents.MenuComponents
{
    public class _MenuNavbarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            return View();

        }
    }
}
