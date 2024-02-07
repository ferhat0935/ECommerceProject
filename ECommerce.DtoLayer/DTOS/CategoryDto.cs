using ECommerce.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DtoLayer.DTOS
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string Description { get; set; }

        public bool Status { get; set; }


        
    }
}
