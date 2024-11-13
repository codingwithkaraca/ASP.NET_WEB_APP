using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class ErrorPageController : Controller
    {
        // GET: ErrorPageController
        public ActionResult Index()
        {
            return View();
        }

    }
}
