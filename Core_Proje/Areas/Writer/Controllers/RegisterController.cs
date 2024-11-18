using System.Net;
using Core_Proje.Areas.Writer.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Areas.Writer.Controllers
{
    [AllowAnonymous]
    [Area("Writer")]
    [Route("/Writer/[controller]/[action]")]
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
            WriterUser wr = new WriterUser()
            {
                Name = p.Name,
                Surname = p.Surname,
                UserName = p.UserName,
                Email = p.Mail,
                ImageUrl = p.ImageUrl,
            };
            if (p.Password == p.ConfirmPassword)
            {
                var result = await _userManager.CreateAsync(wr, p.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index","Login");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            
            return View(p);
        }
    }
}