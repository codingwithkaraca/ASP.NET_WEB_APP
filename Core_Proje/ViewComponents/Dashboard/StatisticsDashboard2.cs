using DataAccessLayer.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.Dashboard;

public class StatisticsDashboard2 : ViewComponent
{
    private Context ctx = new Context();
    
    public IViewComponentResult Invoke()
    {
        ViewBag.v1 = ctx.Portfolios.Count();
        ViewBag.v2 = ctx.Messages.Count();
        ViewBag.v3 = ctx.Services.Count();
        
        return View();
    }

}