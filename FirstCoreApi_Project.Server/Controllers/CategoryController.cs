using FirstCoreApi_Project.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstCoreApi_Project.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly MyDbContext _context; // call the Database

        public CategoryController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet] 
        public IActionResult GetAllCat()
        {

            var cat = _context.Categories.ToList();
            return Ok(cat);
        }
        [HttpGet("{id}")]
        public IActionResult GetCatById(int id)
        {
            var cat = _context.Categories.FirstOrDefault(c => c.CategoryId == id);

            if (cat == null)
                return NotFound();

            return Ok(cat);
        }
        [HttpGet("first-id")]
        public IActionResult GetfirstId(int id)
        {
            var first = _context.Categories.FirstOrDefault();
            if (first == null)
                return NotFound();
            return Ok(first);
        }

        [HttpGet("name")]

        public IActionResult Getname(string name)
        {
            var cataygory = _context.Categories.FirstOrDefault(n => n.CategoryName == name);
            if (cataygory == null)
                return NotFound();
            return Ok(cataygory);
        }
    }
}
