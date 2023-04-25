

using Microsoft.EntityFrameworkCore;
using Shop_Asp.Domain.Entities;
using Shop_Asp.Domain.Repositories.Interfaces;


namespace Shop_Asp.Domain.Repositories.EntityFramework
{
    public class ProductsRepository : IProductsRepository
    {


        private readonly ApplicationContext _context;


        public ProductsRepository(ApplicationContext context)
        {
            _context = context;
        }


        public async Task<int> DeleteProduct(int id)
        {
            var item = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            _context.Products.Remove(item);
            return await _context.SaveChangesAsync();
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _context.Products.Include(x => x.Photos_Large).AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
        }

        public List<Product> GetProducts()
        {
            return _context.Products.Include(x => x.Photos_Large).AsNoTracking().ToList();
        }

        public int SaveProduct(Product item)
        {
            if (item.Id == default)
            {
                _context.Products.Add(item);// Entry(item).State = EntityState.Added;
            }
            else
            {
                //var existingOrder = _context.Products.Local.SingleOrDefault(o => o.Id == item.Id);
                //if (existingOrder != null)
                //    _context.Entry(existingOrder).State = EntityState.Detached;

                // _context.Products.Update(item);
               // _context.Entry(item).Property("Photos_Large").IsModified = true;
              

                var foo = _context.Photos.Where(i => i.ProductId == item.Id);
                foreach (var imgDel in foo)
                {
                    _context.Photos.Remove(imgDel);
                }

                _context.Entry(item).State = EntityState.Modified;
                
                foreach (var photo in item.Photos_Large)
                {
                    //  var existingPhoto = _context.Photos.Local.SingleOrDefault(o => o.Id == photo.Id);
                    // if (existingPhoto != null)
                    //  _context.Entry(existingPhoto).State = EntityState.Detached;
                    //   _context.Entry(photo).State = EntityState.Modified;
                    _context.Photos.Add(photo);
                }
            }

            return _context.SaveChanges();
        }

        public async Task<int> SaveProducts(List<Product> products)
        {
            foreach (var item in products)
            {
                if (item.Id == default)
                {
                    _context.Entry(item).State = EntityState.Added;
                }
                else
                {
                    _context.Entry(item).State = EntityState.Modified;
                }
            }

            return await _context.SaveChangesAsync();
        }
    }
}
