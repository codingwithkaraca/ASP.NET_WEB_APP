using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.Dashboard;

public class LatestProjects : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}