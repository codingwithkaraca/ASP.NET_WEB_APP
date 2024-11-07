using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class ContactController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        // GET: ContactController
        public ActionResult Index()
        {
            var values = messageManager.TGetList();
            
            return View(values);
        }

        public ActionResult ContactDetails(int id)
        {
            var value = messageManager.TGetById(id);
            
            return View(value);
        }

        public ActionResult DeleteContact(int id)
        {
            var value = messageManager.TGetById(id);
            messageManager.TDelete(value);

            return RedirectToAction("Index");
        }

    }
}
