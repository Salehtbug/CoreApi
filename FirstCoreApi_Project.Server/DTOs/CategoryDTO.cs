using System.ComponentModel.DataAnnotations;

namespace FirstCoreApi_Project.Server.DTOs
{
    public class CategoryDTO
    {
        [Required(ErrorMessage = " Name Required")]
        public string CategoryName { get; set; } = null!;

        [Required(ErrorMessage = " Description Required")]
        public string? CategoryDescription { get; set; }
    }
}
