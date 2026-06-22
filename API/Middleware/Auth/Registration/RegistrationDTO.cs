namespace TesiApi.Api.Middleware;

public class RegistrationDTO
{
  public string AccountEmail { get; set; } = string.Empty;
  public string AccountPassword { get; set; } = string.Empty;
  public string FirstName { get; set; } = string.Empty;
  public string LastName { get; set; } = string.Empty;
  public DateOnly Birthday { get; set; }
  public int Gender { get; set; }
  public string Contacts { get; set; } = string.Empty;
  public string Address { get; set; } = string.Empty;

}