using AutoMapper;
using ECommerce.EntityLayer.Concrete;
using ECommerceMVC.DTO.Category;
using ECommerceMVC.DTO.Product;

namespace ECommerceMVC.Mappings
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<CreateProductDto, ProductView>().ReverseMap();    
            CreateMap<ResultProductDto, ProductView>().ReverseMap();
            CreateMap<ResultCategoryDto,Category>().ReverseMap();
        }
    }
}
