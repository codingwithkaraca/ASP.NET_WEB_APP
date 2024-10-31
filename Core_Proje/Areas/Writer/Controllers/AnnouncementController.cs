using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Authorize]
    public class AnnouncementController : Controller
    {
        // GET: AnnouncementController
        public ActionResult Index()
        {
            return View();
        }

    }
}
