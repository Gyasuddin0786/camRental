using System.ComponentModel.DataAnnotations;

namespace camRental.Models
{
    public class TrandingProduct
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Subcategory { get; set; } 

        public decimal Price { get; set; }
    }
}
