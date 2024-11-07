using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class AdminMessageController : Controller
    {
        private WriterMessageManager writerMessageManager = new WriterMessageManager(new EfWriterMessageDal());
        
        string p = "karacaalper806@gmail.com";
        // alıcısı olduğumuz mesajlar
        public ActionResult ReceiverMessageList()
        {
            
            var values = writerMessageManager.GetListReceiverMessage(p);
            return View(values);
        }
        
        // göndericisi olduğumuz mesajlar
        public ActionResult SenderMessageList()
        {
            var values = writerMessageManager.GetListSenderMessage(p);
            return View(values);
        }

        public ActionResult AdminMessageDetails(int id)
        {
            var value =writerMessageManager.TGetById(id);
            return View(value);
        }
        
        public ActionResult AdminMessageDelete(int id)
        {
            var value =writerMessageManager.TGetById(id);
            writerMessageManager.TDelete(value);
            // silinen değer Alıcıya ait ise alıcı listesine ger dönsün değilse 
            // gönderici listesine gerif dönsün
            return RedirectToAction("SenderMessageList");
        }


    }
}
