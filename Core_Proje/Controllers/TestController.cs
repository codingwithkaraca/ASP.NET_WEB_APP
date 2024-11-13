using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TestController : Controller
    {
        // GET: TestController
        public ActionResult Index()
        {
            return View();
        }

    }
}
