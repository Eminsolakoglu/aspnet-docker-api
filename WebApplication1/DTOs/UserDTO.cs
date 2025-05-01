using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTOs;

public class UserDTO
{
    [Required(ErrorMessage = "Name is required")]
    [StringLength(100, ErrorMessage = "Name can't be longer than 100 characters")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string Email { get; set; }
}