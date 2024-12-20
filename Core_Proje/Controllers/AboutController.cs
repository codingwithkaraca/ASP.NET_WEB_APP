using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AboutController : Controller
    {
        private AboutManager aboutManager = new AboutManager(new EfAboutDal());
        
        [HttpGet]
        // GET: AboutController
        public IActionResult Index()
        {
            var values = aboutManager.TGetById(1);
            
            return View(values);
        }

        [HttpPost]
        public IActionResult Index(About about)
        {
            aboutManager.TUpdate(about);
            return RedirectToAction("Index","Dashboard");
        }

    }
}
