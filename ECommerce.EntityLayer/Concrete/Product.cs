using ECommerce.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.EntityLayer.Concrete
{
    public class Product
    {
        public int ProductId { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        public string ProductName { get; set; }

        public long  Price { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }=DateTime.Now;

        public int StockQuantity { get; set; }

        public virtual Category Categories { get; set; }

        public Gender Genders { get; set; }

        public int SizeId { get; set; }
        public virtual ParameterDefinition Size { get; set; }

        public int ColorId { get; set; }
		public virtual ParameterDefinition Color { get; set; }

        public bool IsActive { get; set; }




    }
}
