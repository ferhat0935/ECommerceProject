﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.EntityLayer.Concrete
{
    public class BaseEntity
    {
        public  int  Id { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
