using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Authorize]
    public class MessageController : Controller
    {
        // GET: MessageController
        public ActionResult Index()
        {
            
            
            return View();
        }

    }
}
