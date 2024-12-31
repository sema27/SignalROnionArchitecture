using Microsoft.AspNetCore.Mvc;

namespace SignalROnionArchitecture.Presentation.WebUI.Views.ViewComponents.LayoutComponents
{
	public class _LayoutSidebarPartialComponent:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
