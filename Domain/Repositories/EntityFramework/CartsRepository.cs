

using Shop_Asp.Domain.Entities;
using Shop_Asp.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Shop_Asp.Domain.Repositories.EntityFramework
{
    public class CartsRepository : ICartsRepository
    {


        private readonly ApplicationContext _context;


        public CartsRepository(ApplicationContext context)
        {
            _context = context;
        }


        public async Task<int> DeleteOrderAsync(int id)
        {
            var item = await _context.Carts.FirstOrDefaultAsync(x => x.Id == id);
            if (item != null)
            {
                _context.Carts.Remove(item);
            }

            return await _context.SaveChangesAsync();
        }

        public async Task<Cart> GetOrderAsync(int id)
        {
            return await _context.Carts.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
        }

        public List<Cart> GetProducts()
        {
            return _context.Carts.AsNoTracking().ToList();
        }

        public int AddUpdateOrder(Cart item)
        {
            if (item.Id == default)
            {
                _context.Carts.Add(item);
                // _context.Entry(item).State = EntityState.Added;
            }
            else
            {
                _context.Entry(item).State = EntityState.Modified;
            }

            return _context.SaveChanges();
        }
    }
}
