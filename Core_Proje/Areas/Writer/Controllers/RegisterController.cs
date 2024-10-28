using Core_Proje.Areas.Writer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Areas.Writer.Controllers
{
   [Area("Writer")] 
    public class RegisterController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Index(UserRegisterVM p)
        {
            if (ModelState.IsValid)
            {
                
                
            }

            return View();
        }

    }
}
