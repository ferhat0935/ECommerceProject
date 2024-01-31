using ECommerce.BusinessLayer.Abstract;
using ECommerce.Common.Enums;
using ECommerce.DataAccessLayer.Context;
using ECommerce.DtoLayer.DTOS;
using ECommerce.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
     
      private readonly IProductService _productService;

        public DefaultController(IProductService productService)
        {
            _productService = productService;
        }

     
       
        [HttpGet("Filter")]
        public async Task<IEnumerable<ProductFilterDto>> GetAllProducts(Gender? gender, Color? color, Size? size, decimal? startPrice, decimal? endPrice, string name)
        {
            
         
          
            var filteredProducts = await _productService.GetProductFilter(gender, color, size, startPrice, endPrice, name);
            
            return filteredProducts;
        }

       
    }
    
}
