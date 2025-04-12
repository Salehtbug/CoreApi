using FirstCoreApi_Project.Server.IDataServices;
using FirstCoreApi_Project.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstCoreApi_Project.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IDataServicess _data;

        public ProductController(IDataServicess data)
        {
            _data = data;
        }

        [HttpGet]
        public IActionResult GetAllpro()
        {
            var pro = _data.GetAllProducts();
            return Ok(pro);
        }
        [HttpGet("{id}")]
        public IActionResult GetproById(int id)
        {
            var pro = _data.GetProductById(id);
            if (pro == null)
                return NotFound();
            return Ok(pro);
        }
       
        [HttpGet("name")]

        public IActionResult Getname([FromQuery] string name)
        {
            var pro = _data.GetProductByName(name);
            if (pro == null)
                return NotFound();
            return Ok(pro);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletepro(int id)
        {
            var pro = _data.GetProductById(id);
            if (pro == null)
                return NotFound();
            _data.DeleteProduct(id);
            return NoContent();
        }
    }
}
