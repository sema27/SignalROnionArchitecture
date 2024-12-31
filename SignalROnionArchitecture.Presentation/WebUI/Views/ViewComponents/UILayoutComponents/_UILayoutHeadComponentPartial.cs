using Microsoft.AspNetCore.Mvc;

namespace SignalROnionArchitecture.Presentation.WebUI.Views.ViewComponents.UILayoutComponents
{
    public class _UILayoutHeadComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
