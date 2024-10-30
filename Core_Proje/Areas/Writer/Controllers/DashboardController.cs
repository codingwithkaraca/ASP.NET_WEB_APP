using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Authorize]
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
            return View();
        }

    }
}
