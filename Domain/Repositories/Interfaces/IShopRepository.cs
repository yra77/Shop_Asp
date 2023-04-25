

using Shop_Asp.Domain.Entities;


namespace Shop_Asp.Domain.Repositories.Interfaces
{
    public interface IShopRepository
    {
        IQueryable<ShopModel> GetShopData();
        Task<int> SaveShopData(ShopModel item);
        Task<int> DeleteShopData(int id);
    }
}
