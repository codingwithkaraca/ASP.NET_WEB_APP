using System.Net;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: DefaultController
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult HeaderPartial()
        {
            return PartialView();
        }

        public PartialViewResult NavbarPartial()
        {
            return PartialView();
        }

        [HttpGet] 
        public PartialViewResult SendMessage()
        {
            
            return PartialView();
        }
        
        [HttpPost] 
        public IActionResult SendMessage([FromBody] Message message)
        {
            if (ModelState.IsValid)
            {
                MessageManager messageManager = new MessageManager(new EfMessageDal());
                message.Date = DateTime.Now;
                message.Status = true;
                messageManager.TAdd(message);

                //return RedirectToAction("Index", "Default");
                string alertMessage = "Mesajınız iletildi :)";
                return Ok(new { Code = HttpStatusCode.OK, alertMessage });
            }
            else
            {
                string alertMessage = "Mesaj Gönderilemedi :(";
                return Ok(new { Code = HttpStatusCode.BadRequest, alertMessage });
            }

            
        }

    }
}
