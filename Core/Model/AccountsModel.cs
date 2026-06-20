using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesiApi.Core.Model;

[Table("accounts")]
public class Accounts
{
  [Key]
  [Column("account_id")]
  public int AccountID { get; set; }

  [Column("account_email")]
  public string AccountEmail { get; set; } = string.Empty;

  [Column("password_hash")]
  public string AccountPassword { get; set; } = string.Empty;

  [Column("account_created")]
  public DateTime AccountCreated { get; set; }

  [Column("account_edited")]
  public DateTime AccountEdited { get; set; }

  [Column("is_deleted")]
  public int IsDeleted { get; set; }

  public ICollection<Users>? Users { get; set; }
}