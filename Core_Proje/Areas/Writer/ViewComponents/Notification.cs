using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Areas.Writer.ViewComponents;

public class Notification: ViewComponent
{
    private AnnouncementManager _announcementManager = new AnnouncementManager(new EfAnnouncementDal());
    public IViewComponentResult Invoke()
    {
        var values = _announcementManager.TGetList().Take(5).ToList();
        return View(values);
    }
}