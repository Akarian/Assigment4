using System.Collections.Generic;

namespace DatabaseService
{
    public interface IDataService
    {
        Category CreateCategory(string namequery, string descriptionquery);
        List<Category> GetCategories();
        Category GetCategory(int categoryId);
        bool DeleteCategory(int categoryId);
        bool UpdateCategory(int idquery, string namequery, string descriptionquery);
        Product GetProduct(int productId);
        List<Product> GetProductByCategory(int categoryId);
        List<Product> GetProductByName(string partstringquery);
        List<Product> GetProducts();
    }
}