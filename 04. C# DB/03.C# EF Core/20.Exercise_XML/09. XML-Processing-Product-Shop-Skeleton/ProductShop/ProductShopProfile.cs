using AutoMapper;
using ProductShop.Dtos.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<UsersImportModel, User>();
            this.CreateMap<ProductsImportModel, Product>();
            this.CreateMap<CategoriesImportModel, Category>();
            this.CreateMap<CategoriesProductsImportModel, CategoryProduct>();
        }
    }
}
