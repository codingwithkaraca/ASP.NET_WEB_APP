using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.Dashboard;

public class AdminNavbarMessageList : ViewComponent
{
    WriterMessageManager writerMessageManager = new WriterMessageManager(new EfWriterMessageDal());
    
    public IViewComponentResult Invoke()
    {
        string p = "karacaalper806@gmail.com";
        var values = writerMessageManager.GetListReceiverMessage(p)
            .OrderByDescending(x => x.WriterMessageId)
            .Take(3).ToList();
        
        return View(values);
    }
}