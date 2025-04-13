using FirstCoreApi_Project.Server.DTOs;
using FirstCoreApi_Project.Server.Models;

namespace FirstCoreApi_Project.Server.IDataServices
{
    public interface IDataServicess
    {
        List<Category> GetAllCategories();
        Category GetCategoryById(int id);
        Category GetCategoryByName(string name);
        void DeleteCategory(int id);
        public bool AddCat(CategoryDTO DTO);
        void UpdateCategory(Category category);




        List<Product> GetAllProducts();
        Product GetProductById(int id);
        Product GetProductByName(string name);
        void DeleteProduct(int id);
    }
}
