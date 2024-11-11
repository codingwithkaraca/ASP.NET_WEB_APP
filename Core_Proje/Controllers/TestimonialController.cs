using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class TestimonialController : Controller
    {
        private TestimonialManager testimonialManager = new TestimonialManager(new EfTestimonialDal());
        // GET: TestimonialController
        public ActionResult Index()
        {
            var values = testimonialManager.TGetList();
            return View(values);
        }

        public ActionResult DeleteTestimonial(int id)
        {
            var value = testimonialManager.TGetById(id);
            testimonialManager.TDelete(value);
            return RedirectToAction("Index", "Testimonial");
        }

        [HttpGet]
        public ActionResult EditTestimonial(int id)
        {
            var value =testimonialManager.TGetById(id);
            return View(value);
        }
        
        [HttpPost]
        public ActionResult EditTestimonial(Testimonial t)
        {
            testimonialManager.TUpdate(t);
            return RedirectToAction("Index","Testimonial");
        }


    }
}
