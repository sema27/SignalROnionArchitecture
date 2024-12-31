using Microsoft.AspNetCore.Mvc;

namespace SignalROnionArchitecture.Presentation.WebUI.Views.ViewComponents.MenuComponents
{
    public class _MenuNavbarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            return View();

        }
    }
}
