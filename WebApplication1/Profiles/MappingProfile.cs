using AutoMapper;
using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Profiles;

public class MappingProfile:Profile
{

    public MappingProfile()
    {
        // User => UserDTO
        CreateMap<User, UserDTO>();

        // Post => PostDTO
        CreateMap<Post, PostDTO>();

        // Comment => CommentDTO
        CreateMap<Comment, CommentDTO>();

        // UserDTO => User
        CreateMap<UserDTO, User>();

        // PostDTO => Post
        CreateMap<PostDTO, Post>();

        // CommentDTO => Comment
        CreateMap<CommentDTO, Comment>();
    }
    
}