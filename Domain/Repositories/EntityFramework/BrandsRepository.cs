

using Microsoft.EntityFrameworkCore;
using Shop_Asp.Domain.Entities;
using Shop_Asp.Domain.Repositories.Interfaces;


namespace Shop_Asp.Domain.Repositories.EntityFramework
{
    public class BrandsRepository : IBrandsRepository
    {


        private readonly ApplicationContext _context;


        public BrandsRepository(ApplicationContext context)
        {
            _context = context;
        }


        public List<Brand> GetBrands()
        {
            return _context.Brands.ToList();
        }

        public async Task<int> Add_Update_BrandAsync(Brand item) 
        {
            //await _context.Brands.AddAsync(item);
            //return await _context.SaveChangesAsync();
            if (item.Id == 0)
            {
                _context.Brands.Add(item);// Entry(item).State = EntityState.Added;
            }
            else
            {
                _context.Brands.Update(item);//Entry(item).State = EntityState.Modified;
            }

            return await _context.SaveChangesAsync();
        }

        public async Task<Brand> GetBrandAsync(int id)
        {
            return await _context.Brands.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<int> DeleteBrandAsync(int id)
        {
            var item = await _context.Brands.FirstOrDefaultAsync(x => x.Id == id);
            _context.Brands.Remove(item);
            return await _context.SaveChangesAsync();
        }

    }
}
