using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.EntityLayer.Concrete
{
    public class ProductCategory
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public string ProductName { get; set; }

        public DateTime CreatedDate { get; set; }

        public long Price { get; set; }
    }
}
