using FirstCoreApi_Project.Server.DTOs;
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

        [HttpPost]
        public IActionResult AddCategory([FromForm] CategoryDTO DTO)
        {
            if (DTO == null)
                return BadRequest();
            bool adedd = _data.AddCat(DTO);
            if (adedd != false)
            {
                return Ok();
            }
            return BadRequest();
        }

        //[HttpPost]
        //public IActionResult AddCategory([FromForm] CategoryDTO DTO)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        bool added = _data.AddCat(DTO);
        //        if (added != false)
        //        {
        //            return Ok();
        //        }
        //        return BadRequest();

        //    }
        //}


        [HttpPut("{id}")]
        public IActionResult UpdateCat(int id, [FromForm] Category category)
        {
            var cat = _data.GetCategoryById(id);
            if (cat == null) return NotFound();

            cat.CategoryName = category.CategoryName;
            _data.UpdateCategory(cat);

            return Ok();
        }

    }
}
