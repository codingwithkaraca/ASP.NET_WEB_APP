using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class WriterUserController : Controller
    {
        WriterUserManager writerUserManager = new WriterUserManager(new EfWriterUserDal());
        // GET: WriterUserController
        public ActionResult Index()
        {
            // var values = writerUserManager.TGetList();
            return View();
        }

    }
}
