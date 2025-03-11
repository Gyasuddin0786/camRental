using System.ComponentModel.DataAnnotations;

namespace camRental.Models
{
    public class CardProduct
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Category { get; set; }
        [Required]
        public string Subcategory { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
