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
    [Route("/Writer/[controller]/[action]]")]
    public class MessageController : Controller
    {
        private WriterMessageManager _writerMessageManager = new WriterMessageManager(new EfWriterMessageDal());
        private readonly UserManager<WriterUser> _userManager;

        public MessageController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }
        
        // GET: MessageController
        public async Task<ActionResult> ReceiverMessage(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            
            p = values.Email;
            var messageList = _writerMessageManager.GetListReceiverMessage(p);
            
            return View(messageList);
        }
        
        public async Task<ActionResult> SenderMessage(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            
            p = values.Email;
            var messageList = _writerMessageManager.GetListSenderMessage(p);
            
            return View(messageList);
        }
        
        public ActionResult MessageDetails(int id)
        {
            var value = _writerMessageManager.TGetById(id);
            return View(value);
        }
        
        public ActionResult ReceiverMessageDetails(int id)
        {
            var value = _writerMessageManager.TGetById(id);
            return View(value);
        }

        [HttpGet]
        public ActionResult SendMessage()
        {
            return View();
        }
        
        [HttpPost]
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
