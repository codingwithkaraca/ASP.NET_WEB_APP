using BusinessLayer.Concrete;
using DataAccessLayer.Concretes;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Areas.Writer.Controllers
{
    [Area("Writer")]
    //[Authorize]
    [Route("/Writer/Message")]
    public class MessageController : Controller
    {
        private WriterMessageManager _writerMessageManager = new WriterMessageManager(new EfWriterMessageDal());
        private readonly UserManager<WriterUser> _userManager;

        public MessageController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }
        
        [Route("")]
        [Route("ReceiverMessage")]
        public async Task<ActionResult> ReceiverMessage(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            
            p = values.Email;
            var messageList = _writerMessageManager.GetListReceiverMessage(p);
            
            return View(messageList);
        }
        
        [Route("")]
        [Route("SenderMessage")]
        public async Task<ActionResult> SenderMessage(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            
            p = values.Email;
            var messageList = _writerMessageManager.GetListSenderMessage(p);
            
            return View(messageList);
        }
        
        [Route("")]
        [Route("MessageDetails/{id}")]
        public ActionResult MessageDetails(int id)
        {
            var value = _writerMessageManager.TGetById(id);
            return View(value);
        }
        
        [Route("ReceiverMessageDetails/{id}")]
        public ActionResult ReceiverMessageDetails(int id)
        {
            var value = _writerMessageManager.TGetById(id);
            return View(value);
        }

        [HttpGet]
        [Route("")]
        [Route("SendMessage")]
        public ActionResult SendMessage()
        {
            return View();
        }
        
        [HttpPost]
        [Route("")]
        [Route("SendMessage")]
        public async Task<ActionResult> SendMessage(WriterMessage p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            string mail = values.Email;
            var name = values.Name+" "+values.Surname;
            p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.Sender = mail;
            p.SenderName = name;
            Context c = new Context();
            var usernamesurname = c.Users.Where(x => x.Email == p.Receiver)
                .Select(y => y.Name + " " + y.Surname)
                .FirstOrDefault();
            
            p.ReceiverName = usernamesurname;
            
            _writerMessageManager.TAdd(p);
            
            return RedirectToAction("SenderMessage");
        }

    }
}
