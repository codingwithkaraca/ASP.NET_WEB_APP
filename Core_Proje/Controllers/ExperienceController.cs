using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class ExperienceController : Controller
    {
        ExperienceManager experienceManager = new ExperienceManager(new EfExperienceDal()); 
        // GET: ExperienceController
        public ActionResult Index()
        {
            ViewBag.v1 = "Deneyimler";
            ViewBag.v2 = "Deneyim Listesi";
            
            var values = experienceManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddExperience()
        {
            ViewBag.v1 = "Deneyimler";
            ViewBag.v2 = "Deneyim Ekleme";
            
            return View();
        }
        
        [HttpPost]
        public IActionResult AddExperience(Experience experience)
        {
            
            experienceManager.TAdd(experience);
            return RedirectToAction("Index");
        }


        public IActionResult DeleteExperience(int id)
        {
            var values = experienceManager.TGetById(id);
            experienceManager.TDelete(values);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult EditExperience(int id)
        {
            ViewBag.v1 = "Deneyimler";
            ViewBag.v2 = "Deneyim Güncelleme";
            
            var values = experienceManager.TGetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditExperience(Experience experience)
        {
            experienceManager.TUpdate(experience);
            return RedirectToAction("Index");
        }

    }
}
