using ECommerce.DtoLayer.DTOS;
using System.Collections.Generic;

namespace ECommerceMVC.Models.ParamaterDefinitionModel
{
    public class ParamaterDefinitionModel
    {
        public List<ParamaterDefinitionDto> ColorList { get; set; }
        public List<ParamaterDefinitionDto> SizeList { get; set; }
    }
}
