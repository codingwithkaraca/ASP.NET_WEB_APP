using DataAccessLayer.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.Dashboard;

public class FeatureStatistics : ViewComponent
{
    private Context ctx = new Context();
    
    
    public IViewComponentResult Invoke()
    {
        // Yetenekler sayısı 
        ViewBag.v1 = ctx.Skills.Count();
        
        // Okunmayan mesaj sayısı için 
        ViewBag.v2 = ctx.Messages.Where(x => x.Status == false).Count();
        
        // Okunan mesaj sayısı için
        ViewBag.v3 = ctx.Messages.Where(x => x.Status == true).Count();
        
        // Deneyim sayısı
        ViewBag.v4 = ctx.Experiences.Count();
        

        
        return View();
    }
}