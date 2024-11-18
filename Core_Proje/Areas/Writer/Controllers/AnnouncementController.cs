using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class AnnouncementController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        

    }
}
