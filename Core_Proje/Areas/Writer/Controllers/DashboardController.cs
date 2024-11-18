using System.Reflection.Metadata;
using System.Xml.Linq;
using DataAccessLayer.Concretes;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("/Writer/[controller]/[action]")]
    public class DashboardController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public DashboardController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }
        
        public async Task<ActionResult> Index()
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.name = value.Name +" "+value.Surname; 
            
            // weather api
            string api = "947837838419f8625cb9befc08e24bbb";
            string city = "Konya";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q="+city+"&mode=xml&lang=tr&units=metric&appid="+api;
            XDocument doc = XDocument.Load(connection);
            ViewBag.v5 = doc.Descendants("temperature").ElementAt(0).Attribute("value").Value;
                
                
            // statistics 
            Context c = new Context();
            // toplam mesaj sayısı
            ViewBag.v1 = c.WriterMessages.Where(x => x.Receiver == value.Email).Count();
            // 
            ViewBag.v2 =  c.Announcements.Count();
            // toplam kullanıcı sayısı
            ViewBag.v3 = c.Users.Count();
            // 
            ViewBag.v4 =  c.Skills.Count();
            return View();
        }

    }
}
