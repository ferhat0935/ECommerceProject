using AutoMapper;
using ECommerce.DtoLayer.DTOS;
using ECommerce.DtoLayer.DTOS.ProductDtos;
using ECommerce.EntityLayer.Concrete;
using ECommerceMVC.DTO.CategoryDto;
using ECommerceMVC.DTO.ProductDto;


namespace ECommerceMVC.Mappings
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ResultCategoryDto,Category>().ReverseMap();
            CreateMap<UpdateCategoryDto, Category>().ReverseMap();
            CreateMap<CreateCategoryDto, Category>().ReverseMap();
            CreateMap<ProductFilterDto,Product>().ReverseMap();
            CreateMap<UpdateProductDto, Product>().ReverseMap();
            CreateMap<ResultProductDto, Product>().ReverseMap();
            CreateMap<ParamaterDefinitionDto,ParameterDefinition>().ReverseMap();
           
        }
    }
}
