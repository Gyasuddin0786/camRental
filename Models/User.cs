using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class User
{
    [Key]
    public string UserId { get; set; }

    [Required]
    public string FullName { get; set; }

    [Required]
    public string Email { get; set; }

    public string Phone { get; set; }

    public string Address { get; set; }

    public string Role { get; set; } = "User";  // Default role

    public ICollection<Booking> Bookings { get; set; }
}
