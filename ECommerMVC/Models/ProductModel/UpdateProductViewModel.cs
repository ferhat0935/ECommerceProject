using ECommerce.DtoLayer.DTOS;
using ECommerceMVC.DTO.CategoryDto;
using ECommerceMVC.DTO.ProductDto;
using System.Collections.Generic;

namespace ECommerceMVC.Models.ProductModel
{
    public class UpdateProductViewModel
    {
        public UpdateProductDto UpdateProductDto { get; set; }
        public List<ResultCategoryDto> Categories { get; set; }

        public List<ParamaterDefinitionDto> ColorList { get; set; }
        public List<ParamaterDefinitionDto> SizeList { get; set; }
    }
}
