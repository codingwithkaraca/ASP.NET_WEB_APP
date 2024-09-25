using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class DefaultController : Controller
    {
        // GET: DefaultController
        public ActionResult Index()
        {
            return View();
        }

    }
}
