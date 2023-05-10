

using Shop_Asp.Domain.Entities;


namespace Shop_Asp.Domain.Repositories.Interfaces
{
    public interface ICartsRepository
    {
        Task<Cart> GetOrderAsync(int id);
        Task<int> DeleteOrderAsync(int id);
        List<Cart> GetProducts();
        int AddUpdateOrder(Cart item);
    }
}
