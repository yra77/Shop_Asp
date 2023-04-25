

using Microsoft.EntityFrameworkCore;
using Shop_Asp.Domain.Entities;
using Shop_Asp.Domain.Repositories.Interfaces;


namespace Shop_Asp.Domain.Repositories.EntityFramework
{
    public class ShopRepository : IShopRepository
    {


        private readonly ApplicationContext _context;


        public ShopRepository(ApplicationContext context)
        {
            _context = context;   
        }


        public async Task<int> DeleteShopData(int id)
        {
            _context.ShopModels.Remove(new ShopModel() { Id = id });
           return await _context.SaveChangesAsync();
        }

        public IQueryable<ShopModel> GetShopData()
        {
           return _context.ShopModels;
        }

        public async Task<int> SaveShopData(ShopModel item)
        {
            if (item.Id == default)
            {
                _context.Entry(item).State = EntityState.Added;
            }
            else
            {
                _context.Entry(item).State = EntityState.Modified;
            }

           return await _context.SaveChangesAsync();
        }
    }
}
