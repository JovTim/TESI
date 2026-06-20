using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesiApi.Core.Model;
using TesiApi.Core.Data;
using System.Linq;

namespace TesiApi.Api.Admin;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
  private readonly AppDbContext _context;
  public UsersController(AppDbContext context)
  {
    _context = context;
  }

  [HttpGet]
  public async Task<ActionResult<List<UserDTO>>> GetUsers()
  {
    var results = await _context.Users
        .Select(a => new UserDTO
        {
          UserID = a.UserID,
          FirstName = a.FirstName,
          LastName = a.LastName,
          Birthday = a.Birthday,
          Gender = a.Gender,
          Address = a.Address,
          IsSeller = a.IsSeller,
          SellerDetails = a.SellerDetails,
          AccountEmail = a.Accounts!.AccountEmail,
          AccountCreated = a.Accounts!.AccountCreated,
          AccountEdited = a.Accounts!.AccountEdited,
          IsDeleted = a.Accounts!.IsDeleted
        }).ToListAsync();

    return Ok(results);
  }

  [HttpGet("Sellers")]
  public async Task<ActionResult<List<UserDTO>>> GetSellers()
  {
    var results = await _context.Users
        .Where(a => a.IsSeller == 1)
        .Select(a => new UserDTO
        {
          UserID = a.UserID,
          FirstName = a.FirstName,
          LastName = a.LastName,
          Birthday = a.Birthday,
          Gender = a.Gender,
          Address = a.Address,
          IsSeller = a.IsSeller,
          SellerDetails = a.SellerDetails,
          AccountEmail = a.Accounts!.AccountEmail,
          AccountCreated = a.Accounts!.AccountCreated,
          AccountEdited = a.Accounts!.AccountEdited,
          IsDeleted = a.Accounts!.IsDeleted
        }).ToListAsync();

    return Ok(results);
  }
}