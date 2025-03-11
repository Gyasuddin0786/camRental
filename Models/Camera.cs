using System.ComponentModel.DataAnnotations;

public class Camera
{
    [Key]
    public int CameraId { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Brand { get; set; }

    public string Description { get; set; }

    public decimal PricePerDay { get; set; }

    public bool IsAvailable { get; set; }

    public ICollection<Booking> Bookings { get; set; }
}
