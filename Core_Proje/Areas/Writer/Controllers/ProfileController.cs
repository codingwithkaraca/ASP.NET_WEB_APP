using Core_Proje.Areas.Writer.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public ProfileController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }
        
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name); 
            UserEditVM userEditModel = new UserEditVM();
            userEditModel.Name = values.Name;
            userEditModel.Surname = values.Surname;
            userEditModel.PictureUrl = values.ImageUrl;
            return View(userEditModel);
        }
        
        [HttpPost]
        public async Task<ActionResult> Index(UserEditVM p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (p.Picture != null)
            {
                // uygulamanın şuanki dizinini al
                // dosyanın uzantısını al
                // benzersiz dosya ismi oluşturma ve uzantıyla birleştirme
                // dosyayı kaydetmek için dizin belirt
                // 
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(p.Picture.FileName);
                var imagename = Guid.NewGuid()+extension;
                var saveLocation = resource+"/wwwroot/userimage/"+imagename;
                var stream = new FileStream(saveLocation, FileMode.Create); 
                await p.Picture.CopyToAsync(stream);
                user.ImageUrl = imagename;
            }
            user.Name = p.Name;
            user.Surname = p.Surname;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, p.Password);
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index","Default");
            }
            
            return View();
        }
    }
}
