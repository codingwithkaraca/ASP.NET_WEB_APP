using BusinessLayer.Concrete;
using DataAccessLayer.Concretes;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    [Authorize(Roles = "Admin")]
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

            bool isSender = value.Receiver == p;
            
            writerMessageManager.TDelete(value);
            // silinen değer Alıcıya ait ise alıcı listesine ger dönsün değilse
            // gönderici listesine gerif dönsün
            if (isSender)
            {
                return RedirectToAction("ReceiverMessageList");
            }
            else
            {
                return RedirectToAction("SenderMessageList");
            }
        }

        [HttpGet]
        public ActionResult AdminMessageSend()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminMessageSend(WriterMessage pa)
        {
            pa.Sender = p;
            pa.SenderName = "Alper Karaca";
            pa.Date = DateTime.Now;
            Context c = new Context();
            var usernamesurname = c.Users.Where(x => x.Email == pa.Receiver).Select(y => y.Name +" "+y.Surname).FirstOrDefault();
            pa.ReceiverName = usernamesurname;
            writerMessageManager.TAdd(pa);
            return RedirectToAction("SenderMessageList");
        }


    }
}
