using ECommerce.Common.Enums;
using ECommerce.EntityLayer.Concrete;
using ECommerceMVC.DTO.CategoryDto;
using System;
using System.Collections.Generic;

namespace ECommerceMVC.DTO.ProductDto
{
    public class UpdateProductDto
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }

        public string ProductName { get; set; }

        public long Price { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; } 

        public int StockQuantity { get; set; }

        public Category Categories { get; set; }

        public string CategoryName { get; set; }

        public Gender Genders { get; set; }
        public int SizeId { get; set; }
        public virtual ParameterDefinition Size { get; set; }

        public int ColorId { get; set; }
        public virtual ParameterDefinition Color { get; set; }

        public bool IsActive { get; set; }

        public List<ResultCategoryDto> Category { get; set; }

      
    }
}
