using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTOs;

public class PostDTO
{
    [Required(ErrorMessage = "Title is required")]
    [StringLength(200, ErrorMessage = "Title can't be longer than 200 characters")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Content is required")]
    public string Content { get; set; }
}