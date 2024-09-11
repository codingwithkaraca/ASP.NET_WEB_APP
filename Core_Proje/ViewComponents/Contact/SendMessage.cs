using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.Contact;

public class SendMessage : ViewComponent
{
    MessageManager messageManager = new MessageManager(new EfMessageDal());
    
    [HttpGet]
    public IViewComponentResult Invoke()
    {
        return View();
    }
    
    /*[HttpPost]
    public IViewComponentResult Invoke(Message p)
    {
        p.Date = Convert.ToDateTime(DateTime.Now.ToString());
        p.Status = true;
        messageManager.TAdd(p);
        return View();
    }*/
    
}