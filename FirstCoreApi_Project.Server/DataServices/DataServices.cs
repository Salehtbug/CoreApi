using FirstCoreApi_Project.Server.DTOs;
using FirstCoreApi_Project.Server.IDataServices;
using FirstCoreApi_Project.Server.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace FirstCoreApi_Project.Server.DataServices
{
    public class DataServices : IDataServicess
    {
        private readonly MyDbContext _context;

        public DataServices(MyDbContext context)
        {
            _context = context;
        }

       
        public List<Category> GetAllCategories() => _context.Categories.ToList();

        public Category GetCategoryById(int id) =>
            _context.Categories.FirstOrDefault(c => c.CategoryId == id);

        public Category GetCategoryByName(string name) =>
            _context.Categories.FirstOrDefault(c => c.CategoryName == name);





        public void DeleteCategory(int id)
        {
            var cat = GetCategoryById(id);

                _context.Categories.Remove(cat);
                _context.SaveChanges();
            
        }

        public List<Product> GetAllProducts() => _context.Products.ToList();

        public Product? GetProductById(int id) =>
            _context.Products.FirstOrDefault(p => p.ProductId == id);

        public Product? GetProductByName(string name) =>
            _context.Products.FirstOrDefault(p => p.ProductName == name);

        public void DeleteProduct(int id)
        {
            var pro = GetProductById(id);
            if (pro != null)
            {
                _context.Products.Remove(pro);
                _context.SaveChanges();
            }
        }

     public bool AddCat(CategoryDTO DTO)
        {
            var cat = new Category
            {
                CategoryName = DTO.CategoryName,
                CategoryDescription = DTO.CategoryDescription
            };
             _context.Categories.Add(cat);
            _context.SaveChanges();
            return true;

        }

        public void UpdateCategory(Category category)
        {
            var exCategory = GetCategoryById(category.CategoryId);
            if (exCategory != null)
            {
                exCategory.CategoryName = category.CategoryName;
                _context.SaveChanges();
            }
        }
    }
}
    