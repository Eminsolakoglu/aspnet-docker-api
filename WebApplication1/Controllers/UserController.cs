using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController:ControllerBase
{
    private readonly ApplicationDbContext _context;
   // private readonly InMemoryRepository _repository;
    private readonly IMapper _mapper;  // AutoMapper'ı alıyoruz

    public UserController(ApplicationDbContext context,IMapper mapper)
    {
        _mapper = mapper;
        //_repository = repository;
        _context = context;
    }
    
    //GET api/users
    [HttpGet]
    public ActionResult<IEnumerable<UserDTO>> GetUsers()
    {
        var users = _context.Users.ToList();
        // User listesine dönüştürme işlemi
        var userDTOs = _mapper.Map<List<UserDTO>>(users);
        return Ok(userDTOs);
    }
    
    //GET api/users/1
    [HttpGet("{id}")]
    public ActionResult<UserDTO> GetUser(int id)
    {
        var user=_context.Users.Find(id);
        if(user==null)
        {
            return NotFound();
        }
        var userDTO=_mapper.Map<UserDTO>(user);
        return Ok(userDTO);
    }

    //POST api/users
    [HttpPost]
    public ActionResult<UserDTO> CreateUser([FromBody] UserDTO userDto)
    {
        var user=_mapper.Map<User>(userDto);
        _context.Users.Add(user);
        _context.SaveChanges();

        var resultDto=_mapper.Map<UserDTO>(user);

        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, resultDto);
    }
    
    //PUT api/users/1
    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, [FromBody] UserDTO userDto)
    {
       var existingUser = _context.Users.Find(id);
        if (existingUser == null)
        {
            return NotFound();
        }

        // DTO'dan gelen verileri mevcut user üzerine uygula
        _mapper.Map(userDto, existingUser);

        _context.SaveChanges();
        return NoContent();
    }
    //DELETE api/users/1
    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        
        var user = _context.Users.Find(id);
        if(user==null){
            return NotFound();
        }
        _context.Users.Remove(user);
        _context.SaveChanges();

        return NoContent();
    }
}