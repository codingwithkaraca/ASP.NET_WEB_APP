using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Areas.Writer.ViewComponents;

public class Navbar : ViewComponent
{
    private readonly UserManager<WriterUser> _userManager;

    public Navbar(UserManager<WriterUser> userManager)
    {
        _userManager = userManager;
    }
    
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var value = await _userManager.FindByNameAsync(User.Identity.Name);
        ViewBag.profilePic = value.ImageUrl;
        return View();
    }
    
    

}