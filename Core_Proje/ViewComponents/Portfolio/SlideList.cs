using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.Dashboard;

public class SlideList : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}