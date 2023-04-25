

using Shop_Asp.Domain.Entities;


namespace Shop_Asp.Domain.Repositories.Interfaces
{
    public interface IProductsRepository
    {
        List<Product> GetProducts();
        Task<Product> GetProduct(int id);
        int SaveProduct(Product item);
        Task<int> SaveProducts(List<Product> products);
        Task<int> DeleteProduct(int id);
    }
}
