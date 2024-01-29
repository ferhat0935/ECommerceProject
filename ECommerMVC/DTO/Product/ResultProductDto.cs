namespace ECommerceMVC.DTO.Product
{
    public class ResultProductDto
    {
        public int Id { get; set; }

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
