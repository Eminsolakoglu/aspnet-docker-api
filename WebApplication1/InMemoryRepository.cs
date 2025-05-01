using WebApplication1.Models;

namespace WebApplication1;

public class InMemoryRepository
{
    private readonly List<User> _users = new List<User>();
    private readonly List<Post> _posts = new List<Post>();
    private readonly List<Comment> _comments = new List<Comment>();

    
    //  User CRUD işlemleri başlangıç 
    public List<User> GetUsers()
    {
        return _users;
    }

    public User GetUserById(int id)
    {
        User tempUser = _users.FirstOrDefault(user => user.Id == id);
        return tempUser;
    }

    public void AddUser(User user)
    {
        _users.Add(user);
    }

    public void UpdateUser(User user)
    {
        var existingUser = GetUserById(user.Id);
        if (existingUser != null)
        {
            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
        }
        //else kısmı ekleyeceğim 
    }

    public void DeleteUser(int id)
    {
        _users.RemoveAll(u=>u.Id==id);
    }
    //  User CRUD işlemleri bitiş
    
    //Post CRUD işlemleri başlangıç
    public List<Post> GetPosts() => _posts;
    public Post GetPostById(int id) => _posts.FirstOrDefault(p => p.Id == id);
    public void AddPost(Post post) => _posts.Add(post);
    public void DeletePost(int id) => _posts.RemoveAll(p => p.Id == id);
    public void UpdatePost(Post post)
    {
        var existingPost = GetPostById(post.Id);
        if (existingPost != null)
        {
            existingPost.Content = post.Content;
            existingPost.Title = post.Title;
        }
    }
    //Post CRUD işlemleri bitişi
    
    
    //Comment CRUD işlemleri başlangıç
    public List<Comment> GetComments() => _comments;
    public Comment GetCommentById(int id) => _comments.FirstOrDefault(c => c.Id == id);
    public void AddComment(Comment comment) => _comments.Add(comment);
    public void DeleteComment(int id) => _comments.RemoveAll(c => c.Id == id);

    public void UpdateComment(Comment comment)
    {
        var existingComment = GetCommentById(comment.Id);
        if (existingComment != null)
        {
            existingComment.Content = comment.Content;
        }
    }
    //Comment CRUD işlemleri bitiş

}