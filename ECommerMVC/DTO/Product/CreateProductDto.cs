using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceMVC.DTO.Product
{
    public class CreateProductDto
    {
        public string ProductName { get; set; }

        public string CategoryName { get; set; }

        public string Description { get; set; }

        public string GenderName { get; set; }

        public long Price { get; set; }

        public int UploadedQuantity { get; set; }

        public int CurrentQuantity { get; set; }

        public int GenderId { get; set; }

        public int CategoryId { get; set; }

        public bool IsActive { get; set; }


    }
}
