using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.Dashboard;

public class AdminNavbarNotificationList : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}