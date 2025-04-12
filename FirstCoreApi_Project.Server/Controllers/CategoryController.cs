using FirstCoreApi_Project.Server.IDataServices;
using FirstCoreApi_Project.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstCoreApi_Project.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IDataServicess _data;

        public CategoryController(IDataServicess data)
        {
            _data = data;
        }

        [HttpGet]
        public IActionResult GetAllcat()
        {
            var cat = _data.GetAllCategories();
            return Ok(cat);
        }

        [HttpGet("{id}")]
        public IActionResult GetCatById(int id)
        {
            var cat = _data.GetCategoryById(id);
            if (cat == null)
                return NotFound();
            return Ok(cat);
        }

        [HttpGet("name")]

        public IActionResult Getname( [FromQuery] string name)
        {
            var cat = _data.GetCategoryByName(name);
            if (cat == null)
                return NotFound();
            return Ok(cat);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCat(int id)
        {
            var cat = _data.GetCategoryById(id);
            if (cat == null)
                return NotFound();
            _data.DeleteCategory(id);
            return NoContent();
        }
    }
}
