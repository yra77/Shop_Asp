

using Shop_Asp.Domain.Entities;


namespace Shop_Asp.Domain.Repositories.Interfaces
{
    public interface IBrandsRepository
    {
        List<Brand> GetBrands();
        Task<int> Add_Update_BrandAsync(Brand item);
        Task<Brand> GetBrandAsync(int id);
        Task<int> DeleteBrandAsync(int id);
    }
}
