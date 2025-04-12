using FirstCoreApi_Project.Server.Models;

namespace FirstCoreApi_Project.Server.IDataServices
{
    public interface IDataServicess
    {
        List<Category> GetAllCategories();
        Category GetCategoryById(int id);
        Category GetCategoryByName(string name);
        void DeleteCategory(int id);

        List<Product> GetAllProducts();
        Product GetProductById(int id);
        Product GetProductByName(string name);
        void DeleteProduct(int id);
    }
}
