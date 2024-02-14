using ECommerce.DtoLayer.DTOS;
using System.Collections.Generic;

namespace ECommerceMVC.DTO.ParameterDefinitionDto
{
    public class ResultParameterDefinitionDto
    {
        public List<ParamaterDefinitionDto> ColorList { get; set; }
        public List<ParamaterDefinitionDto> SizeList { get; set; }
      
    }
}
