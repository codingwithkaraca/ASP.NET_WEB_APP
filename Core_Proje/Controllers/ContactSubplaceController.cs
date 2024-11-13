using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ContactSubplaceController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());
        // GET: ContactSubplaceController
        [HttpGet]
        public ActionResult Index()
        {
            var value = contactManager.TGetById(1);
            return View(value);
        }

        [HttpPost]
        public ActionResult Index(Contact contact)
        {
            contactManager.TUpdate(contact);
            return RedirectToAction("Index", "ContactSubplace");
        }

    }
}
