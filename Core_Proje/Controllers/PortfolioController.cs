using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class PortfolioController : Controller
    {
        PortfolioManager portfolioManager = new PortfolioManager(new EfPortfolioDal());
        
        // GET: PortfolioController
        public ActionResult Index()
        {
            ViewBag.v1 = "Proje Listesi";
            ViewBag.v2 = "Projeler";
            ViewBag.v3 = "Proje Listesi";
            
            var values = portfolioManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddPortfolio()
        {
            ViewBag.v1 = "Proje Listesi";
            ViewBag.v2 = "Projelerim";
            ViewBag.v3 = "Proje Listesi";
            
            return View();
        }
        
        [HttpPost]
        public IActionResult AddPortfolio(Portfolio portfolio)
        {
            portfolioManager.TAdd(portfolio);
            return RedirectToAction("Index");
        }

        public IActionResult DeletePortfolio(int id)
        {
            var values = portfolioManager.TGetById(id);
            portfolioManager.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditPortfolio(int id)
        {
            ViewBag.v1 = "Porfolyo Düzenleme";
            ViewBag.v2 = "Porfolyoler";
            ViewBag.v3 = "Porfolyo Düzenleme";
            
            var values = portfolioManager.TGetById(id);
            return View(values);
        }
        
        [HttpPost]
        public IActionResult EditPortfolio(Portfolio portfolio)
        {
            portfolioManager.TUpdate(portfolio);
            return RedirectToAction("Index");
        }


    }
}
