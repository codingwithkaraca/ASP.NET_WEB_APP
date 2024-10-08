using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class ServiceController : Controller
    {
        ServiceManager serviceManager = new ServiceManager(new EfServiceDal());
        
        // GET: ServiceController
        public ActionResult Index()
        {
            ViewBag.v1 = "Hizmetler";
            ViewBag.v2 = "Hizmetler";
            ViewBag.v3 = "Hizmetlerim";

            var values = serviceManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddService()
        {
            ViewBag.v1 = "Hizmet Ekle";
            ViewBag.v2 = "Hizmetler";
            ViewBag.v3 = "Hizmet Ekle";
            
            return View();
        }
        
        [HttpPost]
        public IActionResult AddService(Service service)
        {
            
            serviceManager.TAdd(service);
            return RedirectToAction("Index");
        }
        
        //silme işlemi için
        public IActionResult DeleteService(int id)
        {
            var values = serviceManager.TGetById(id);
            serviceManager.TDelete(values);
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public IActionResult EditService(int id)
        {
            ViewBag.v1 = "Hizmetler";
            ViewBag.v2 = "Hizmetler";
            ViewBag.v3 = "Hizmet Güncelle";

            var values = serviceManager.TGetById(id);
            
            return View(values);
        }
        
        [HttpPost]
        public IActionResult EditService(Service service)
        {
            
            serviceManager.TUpdate(service);
            return RedirectToAction("Index");
        }



    }
}
