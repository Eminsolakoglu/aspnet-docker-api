namespace WebApplication1.Models;

public class Post
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public String Title { get; set; }
    public String Content { get; set; }
    public User User { get; set; }
}