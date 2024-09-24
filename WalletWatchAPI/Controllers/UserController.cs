using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WalletWatchAPI.Data;
using WalletWatchAPI.Models;

namespace WalletWatchAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase {
    private readonly ExpensesContext _context;

    public UserController(ExpensesContext context) {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers() {
        return await _context.Users.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id) {
        var user = await _context.Users.FindAsync(id);

        if (user == null) {
            return NotFound();
        }

        return user;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);

        if (user == null)
        {
            return Unauthorized("Username or password is incorrect");
        }

        bool isPasswordValid = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);

        if (!isPasswordValid)
        {
            return Unauthorized("Username or password is incorrect");
        }
        
        return Ok("Login successful");
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(UserCreateRequest request)
    {
        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

        var user = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            PasswordHash = hashedPassword, 
            CreatedAt = DateTime.UtcNow   
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return Ok("User registered successfully");
    }
}