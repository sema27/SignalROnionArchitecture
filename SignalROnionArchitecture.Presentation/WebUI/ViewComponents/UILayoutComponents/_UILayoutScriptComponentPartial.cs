using Microsoft.AspNetCore.Mvc;

namespace SignalROnionArchitecture.Presentation.WebUI.ViewComponents.UILayoutComponents
{
    public class _UILayoutScriptComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
