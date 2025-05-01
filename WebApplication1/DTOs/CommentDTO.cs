using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTOs;

public class CommentDTO
{
    [Required(ErrorMessage = "Content is required")]
    public string Content { get; set; }
}