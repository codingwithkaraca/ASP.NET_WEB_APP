using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Authorize]
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

    }
}
