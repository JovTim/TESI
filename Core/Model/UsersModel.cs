using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;

namespace TesiApi.Core.Model;

[Table("users")]
public class Users
{
  [Key]
  [Column("user_id")]
  public int UserID { get; set; }

  [Column("first_name")]
  public string FirstName { get; set; } = string.Empty;

  [Column("last_name")]
  public string LastName { get; set; } = string.Empty;

  [Column("account_id")]
  public int AccountID { get; set; }

  [ForeignKey(nameof(AccountID))]
  public Accounts? Accounts { get; set; }

  [Column("date_of_birth")]
  public DateOnly Birthday { get; set; }

  [Column("gender")]
  public int Gender { get; set; }

  [Column("Address")]
  public string Address { get; set; } = string.Empty;

  [Column("is_seller")]
  public int IsSeller { get; set; }

  [Column("seller_details")]
  public string? SellerDetails { get; set; }

  [Column("is_verified")]
  public int IsVerified { get; set; }

  public ICollection<Apartments>? Apartments { get; set; }

}