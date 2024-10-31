using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Areas.Writer.ViewComponents;

public class Notification: ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}