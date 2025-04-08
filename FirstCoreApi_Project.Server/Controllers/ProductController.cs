using FirstCoreApi_Project.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstCoreApi_Project.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly MyDbContext _context; // call the Database

        public ProductController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllpro()
        {

            var cat = _context.Products.ToList();
            return Ok(cat);
        }
        [HttpGet("{id}")]
        public IActionResult GetproById(int id)
        {
            var cat = _context.Products.FirstOrDefault(c => c.ProductId == id);

            if (cat == null)
                return NotFound();

            return Ok(cat);
        }
        [HttpGet("first-id")]
        public IActionResult GetfirstId(int id)
        {
            var first = _context.Products.FirstOrDefault();
            if (first == null)
                return NotFound();
            return Ok(first);
        }

        [HttpGet("name")]

        public IActionResult Getname(string name)
        {
            var Product = _context.Products.FirstOrDefault(n => n.ProductName == name);
            if (Product == null)
                return NotFound();
            return Ok(Product);
        }
    }
}
