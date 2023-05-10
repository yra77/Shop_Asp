

using Shop_Asp.Domain.Repositories.Interfaces;


namespace Shop_Asp.Domain
{
    public class DataManager
    {


        public DataManager(IProductsRepository prod,
                           IShopRepository shop,
                           IBrandsRepository brandsRepo,
                           ILoginRepository loginRepo,
                           ICartsRepository cartRepo)
        {
            ProductsRepo = prod;
            ShopRepo = shop;
            BrandsRepo = brandsRepo;
            LoginRepo = loginRepo;
            CartRepo = cartRepo;
        }


        public IProductsRepository ProductsRepo { get; set; }
        public IShopRepository ShopRepo { get; set; }
        public IBrandsRepository BrandsRepo { get; set; }
        public ILoginRepository LoginRepo { get; set; }
        public ICartsRepository CartRepo { get; set; }

    }
}
