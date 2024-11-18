using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.Dashboard;

public class MessageList : ViewComponent
{
    MessageManager messageManager = new MessageManager(new EfMessageDal());
    public IViewComponentResult Invoke()
    {
        var values = messageManager.TGetList();
        return View(values);
    }
}