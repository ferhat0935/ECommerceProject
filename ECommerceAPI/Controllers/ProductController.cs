using ECommerce.BusinessLayer.Abstract;
using ECommerce.Common.Enums;
using ECommerce.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using ECommerce.Common;
using System.Diagnostics.Contracts;
using ECommerce.DtoLayer.DTOS.ProductDtos;
using Microsoft.AspNetCore.Components.Forms;

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
      

        public ProductController(IProductService productService)
        {
            _productService = productService;
          
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] string gender, [FromQuery] int? categoryId, [FromQuery] int? colorId, [FromQuery] int? sizeId, [FromQuery] int? productId)
        {
           


            var filteredProducts = await _productService.GetProductFilter(null, null, null, null, null, null, null, null);

            return Ok(filteredProducts);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var values = await _productService.TGetByIdAsync(id);
            _productService.TDelete(values);
            return Ok(values);
             
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var filteredProducts = await _productService.GetProduct(id);
            return Ok(filteredProducts);
        }


        [HttpPut("UpdateProduct")]
        public IActionResult UpdateCategory(Product product)
        {
            _productService.TUpdate(product);
            return Ok();
        }


    }
}
