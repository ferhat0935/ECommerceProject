using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DtoLayer.DTOS
{
	public class ParamaterDefinitionDto
	{
		public int Id { get; set; }
		public string ParameterGroupName { get; set; } // colors
		public string ParameterName { get; set; } // black
		public string ColorCode { get; set; }
		public string ParameterValue { get; set; } // siyah
		public DateTime RecordTime { get; set; }
		public bool IsActive { get; set; }
	}
}
