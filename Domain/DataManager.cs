

using Shop_Asp.Domain.Repositories.Interfaces;

namespace Shop_Asp.Domain
{
    public class DataManager
    {


        public IProductsRepository ProductsRepo { get; set; }
        public IShopRepository ShopRepo { get; set; }
        public IBrandsRepository BrandsRepo { get; set; }


        public DataManager(IProductsRepository prod,
                           IShopRepository shop,
                           IBrandsRepository brandsRepo)
        {
            ProductsRepo = prod;
            ShopRepo = shop;
            BrandsRepo = brandsRepo;
        }

    }
}
