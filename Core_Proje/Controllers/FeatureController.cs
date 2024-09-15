using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers;

public class FeatureController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}