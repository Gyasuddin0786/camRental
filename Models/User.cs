using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace camRental.Models
{
    public class User
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string Role { get; set; } = "User";  // Default Role

        public ICollection<Booking> Bookings { get; set; }
    }
}
