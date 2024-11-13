using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers;

[Authorize(Roles = "Admin")]
public class FeatureController : Controller
{
    FeatureManager featureManager = new FeatureManager(new EfFeatureDal()); 
    
    // GET
    [HttpGet]
    public IActionResult Index()
    {
        var values = featureManager.TGetById(1);
        return View(values);
    }

    [HttpPost]
    public IActionResult Index(Feature feature)
    {
        featureManager.TUpdate(feature);
        return RedirectToAction("Index","Dashboard");
    }
}