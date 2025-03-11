using camRental.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Booking
{
    [Key]
    public int BookingId { get; set; }

    [Required]
    [ForeignKey("User")]
    public string UserId { get; set; }

    [Required]
    [ForeignKey("Camera")]
    public int CameraId { get; set; }

    public DateTime BookingDate { get; set; }

    public DateTime ReturnDate { get; set; }

    public decimal TotalPrice { get; set; }

    public bool IsPaid { get; set; }

    public virtual User User { get; set; }
    public virtual Camera Camera { get; set; }
}
