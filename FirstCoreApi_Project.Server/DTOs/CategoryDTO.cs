using System.ComponentModel.DataAnnotations;

namespace FirstCoreApi_Project.Server.DTOs
{
    public class CategoryDTO
    {
       
        public string CategoryName { get; set; } = null!;

        
        public string? CategoryDescription { get; set; }
    }
}
