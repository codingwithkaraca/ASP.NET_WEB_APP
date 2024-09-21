using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class DashboardController : Controller
    {
        // GET: DashboardController
        public ActionResult Index()
        {
            ViewBag.v1 = "Dashboard";
            ViewBag.v2 = "İstatistikler";
            ViewBag.v3 = "Öne Çıkanlar Sayfası";
            
            return View();
        }
        
        // Tema Değişikliğine gidildi 
        // Dashborada kadar geldim eski temada 

    }
}
