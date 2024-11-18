using System.Net;
using Core_Proje_Api.DAL.ApiContext;
using Core_Proje_Api.DAL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public IActionResult CategoryList()
        {
            Context c = new Context();

            var values = c.Categories.ToList();

            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            using var c = new Context();

            var value = c.Categories.Find(id);
            if (value == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(value);
            }
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            using var c = new Context();

            if (ModelState.IsValid)
            {
                c.Categories.Add(category);
                c.SaveChanges();
                string message = "başarıyla eklendi";
                return Ok(new { Code = HttpStatusCode.OK, message });
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            using var c = new Context();
            var value = c.Categories.Find(id);

            if (value == null)
            {
                return NotFound();
            }
            else
            {
                c.Categories.Remove(value);
                string message = "Başarıyla silindi";
                return Ok(new { Code = 200, message }); // boş göndermek için NoContent gönderilebilir
            }
        }
        
        [HttpPut]
        public IActionResult UpdateCategory(Category category)
        {
            using var c = new Context();
            var value = c.Find<Category>(category.CategoryId);

            if (value == null)
            {
                return NotFound();
            }
            else
            {
                value.CategoryName = category.CategoryName;
                c.Update(value);
                c.SaveChanges();    

                string message = "Güncelleme işlemi başarıyla gerçekleşti";
                return Ok(new {Code = HttpStatusCode.OK,message});
            }
            
        }
        
    }
}
