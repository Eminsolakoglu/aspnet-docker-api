namespace WebApplication1.Models;

public class Comment
{
    public int Id { get; set; }
    public int PostId { get; set; }
    public String Content { get; set; }
    public Post Post { get; set; }
    
}