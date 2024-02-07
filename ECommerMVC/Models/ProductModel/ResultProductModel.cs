using ECommerce.DtoLayer.DTOS;
using ECommerceMVC.DTO.CategoryDto;
using System.Collections.Generic;

namespace ECommerceMVC.Models.ProductModel
{
    public class ResultProductModel
    {
        public List<ProductFilterDto> ProductFilters { get; set; }
        public List<CategoryDto> Categories { get; set; }
        public List<ParamaterDefinitionDto> ParamaterDefinitions { get; set; }
    }
}
