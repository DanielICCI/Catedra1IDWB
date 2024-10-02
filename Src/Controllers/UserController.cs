using Catedra1.Models;
using Catedra1.Repositories;
using Microsoft.AspNetCore.Mvc;

public class UserController : Controller
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpPost("/user")]
    public IActionResult CreateUser([FromBody] User user)
    {
        if (!ModelState.IsValid) return BadRequest();
        _userRepository.AddUser(user);
        _userRepository.Save();
        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    }

    [HttpGet("/user")]
    public IActionResult GetAllUsers() => Ok(_userRepository.GetAllUsers());

    [HttpPut("/user/{id}")]
    public IActionResult UpdateUser(int id, [FromBody] User user)
    {
        var existingUser = _userRepository.GetUserById(id);
        if (existingUser == null) return NotFound();
        _userRepository.UpdateUser(user);
        _userRepository.Save();
        return Ok(user);
    }

    [HttpDelete("/user/{id}")]
    public IActionResult DeleteUser(int id)
    {
        _userRepository.DeleteUser(id);
        _userRepository.Save();
        return Ok();
    }
}