using System.ComponentModel.DataAnnotations;

namespace ECommerceMVC.DTO.CategoryDto
{
    public class UpdateCategoryDto
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage ="Kategori İsmi Giriniz")]
        [StringLength(100, ErrorMessage = "En fazla 100 karakter giriniz!")]
        public string CategoryName { get; set; }

        [Required(ErrorMessage ="Kategori Açıklaması Giriniz")]
        [StringLength(100, ErrorMessage = "En fazla 100 karakter giriniz!")]
        public string Description { get; set; }

        public bool Status { get; set; }
    }
}
