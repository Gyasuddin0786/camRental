using System.ComponentModel.DataAnnotations;

public class Admin
{
    [Key]
    public int AdminId { get; set; }

    [Required]
    public string FullName { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
