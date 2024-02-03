using ECommerce.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Common.Helpers
{
	public static class EnumHelper
	{
		public static string GetColorDisplayName(Color color)
		{
			switch (color)
			{
				case Color.Black:
					return "Black";
				case Color.White:
					return "White";
				case Color.Blue:
					return "Blue";
				case Color.Green:
					return "Green";
				case Color.Gray:
					return "Gray";
				case Color.Red:
					return "Red";
				default:
					return color.ToString();
			}
		}

		public static string GetAllColorDisplayNames(Color[] colors)
		{
			// Dizi içindeki her bir enum değeri için GetColorDisplayName metodunu çağır
			var displayNames = Array.ConvertAll(colors, c => GetColorDisplayName(c));

			// Enum değerlerini bir dize olarak birleştir
			return string.Join(", ", displayNames);
		}
	}
}
