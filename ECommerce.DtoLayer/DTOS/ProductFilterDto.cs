using ECommerce.Common.Enums;
using ECommerce.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DtoLayer.DTOS
{
    public class ProductFilterDto
    {
        public int ProductId { get; set; }

     
        public int CategoryId { get; set; }

        public string ProductName { get; set; }

        public long Price { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public int StockQuantity { get; set; }

        public Category Categories { get; set; }

        public string CategoryName { get; set; }

        public Gender Genders { get; set; }

        public Size Sizes { get; set; }

        public Color Colors { get; set; }
    }
}
