using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.EntityLayer.Concrete
{
    public class Product:BaseEntity
    {

        public int CategoryId { get; set; }

        public string ProductName { get; set; }

        public long Price { get; set; }

        public string Description { get; set; }

        public int UploadedQuantity { get; set; }

        public int CurrentQuantity { get; set; }

        public bool IsActive { get; set; }
    }
}
