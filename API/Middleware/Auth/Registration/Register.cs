using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesiApi.Core.Model;
using TesiApi.Core.Data;
using BCrypt.Net;

namespace TesiApi.Api.Middleware;

[ApiController]
[Route("api/[controller]")]
public class RegistrationController : ControllerBase
{
  private readonly AppDbContext _context;
  public RegistrationController(AppDbContext context)
  {
    _context = context;
  }

  [HttpPost("register")]
  public async Task<IActionResult> Register([FromBody] RegistrationDTO model)
  {
    var emailExist = await _context.Accounts.AnyAsync(a => a.AccountEmail == model.AccountEmail);

    if (emailExist)
    {
      return BadRequest("Email already exist!");
    }

    using var transaction = await _context.Database.BeginTransactionAsync();
    try
    {
      var newAccount = new Accounts
      {
        AccountEmail = model.AccountEmail,
        AccountPassword = BCrypt.Net.BCrypt.HashPassword(model.AccountPassword),
        AccountCreated = DateTime.UtcNow,
        AccountEdited = DateTime.UtcNow,
        IsDeleted = 0
      };
      var newUser = new Users
      {
        FirstName = model.FirstName,
        LastName = model.LastName,
        Accounts = newAccount,
        Birthday = model.Birthday,
        Contacts = model.Contacts,
        Address = model.Address,
        IsSeller = 0,
        SellerDetails = null,
        IsVerified = 0
      };

      _context.Users.Add(newUser);
      await _context.SaveChangesAsync();

      await transaction.CommitAsync();

      return Ok("Registration Success!");
    }
    catch (Exception)
    {
      await transaction.RollbackAsync();
      return StatusCode(500);
    }
  }
}