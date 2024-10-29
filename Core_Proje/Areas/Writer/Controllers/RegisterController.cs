using System.Net;
using Core_Proje.Areas.Writer.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Areas.Writer.Controllers
{
   [Area("Writer")] 
    public class RegisterController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public RegisterController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }
        
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<ActionResult> Index(UserRegisterVM p)
        {
            if (ModelState.IsValid)
            {
                WriterUser wr = new WriterUser()
                {
                    Name = p.Name,
                    Surname = p.Surname,
                    UserName = p.UserName,
                    Email = p.Mail,
                    ImageUrl = p.ImageUrl,
                };
                
                var result = await _userManager.CreateAsync(wr, p.Password);

                if (result.Succeeded)
                {
                    string message = "kayıt başarıyla eklendi";
                    return Json(new { success = true, message});
                    //return RedirectToAction("Index", "Login");
                }
                else
                {
                    var errorMessages = result.Errors.Select(e => e.Description).ToList();
                    return Json(new { success = false, errors = errorMessages });
                }
            }

            return View();
        }

    }
}
