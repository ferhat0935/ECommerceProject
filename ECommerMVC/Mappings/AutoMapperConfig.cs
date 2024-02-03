using AutoMapper;
using ECommerce.DtoLayer.DTOS;
using ECommerce.EntityLayer.Concrete;
using ECommerceMVC.DTO.CategoryDto;


namespace ECommerceMVC.Mappings
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ResultCategoryDto,Category>().ReverseMap();
            CreateMap<ProductFilterDto,Product>().ReverseMap();
            CreateMap<ParamaterDefinitionDto,ParameterDefinition>().ReverseMap();
        }
    }
}
