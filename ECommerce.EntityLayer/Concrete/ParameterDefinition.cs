﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.EntityLayer.Concrete
{
	public class ParameterDefinition
	{
        public int Id { get; set; }
        public string ParameterGroupName { get; set; } // colors,size
        public string ParameterName { get; set; } // black,small
        public string ColorCode { get; set; }
        public string ParameterValue { get; set; } // siyah
        public DateTime RecordTime { get; set; }
        public bool IsActive { get; set; }

	}

    public class Model
    {
        public List<Color> Colors  { get; set; }
        public List<Size> Size { get; set; }
    }
}
