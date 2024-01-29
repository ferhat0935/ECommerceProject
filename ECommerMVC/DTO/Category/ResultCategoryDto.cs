using ECommerce.EntityLayer.Concrete;

namespace ECommerceMVC.DTO.Category
{
	public class ResultCategoryDto:BaseEntity
	{
		public string CategoryName { get; set; }

		public string Description { get; set; }

		public bool IsActive { get; set; }

		public bool FeatureIsActive { get; set; }
	}
}
