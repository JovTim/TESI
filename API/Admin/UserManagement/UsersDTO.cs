using TesiApi.Core.Model;

namespace TesiApi.Api.Admin;


public class UserDTO
{
  public int UserID { get; set; }
  public string FirstName { get; set; } = string.Empty;
  public string LastName { get; set; } = string.Empty;
  public DateOnly Birthday { get; set; }
  public int Gender { get; set; }
  public string Address { get; set; } = string.Empty;
  public int IsSeller { get; set; }
  public string? SellerDetails { get; set; }
  public int IsVerified { get; set; }
  public string AccountEmail { get; set; } = string.Empty;
  public DateTime AccountCreated { get; set; }
  public DateTime AccountEdited { get; set; }
  public int IsDeleted { get; set; }
}