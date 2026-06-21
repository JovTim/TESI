using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesiApi.Core.Model;

[Table("bookings")]
public class Bookings
{
  [Key]
  [Column("booking_id")]
  public int BookingID { get; set; }

  [Column("user_id")]
  public int UserID { get; set; }

  [ForeignKey(nameof(UserID))]
  public Users? Users { get; set; }

  [Column("apartment_id")]
  public int ApartmentID { get; set; }

  [ForeignKey(nameof(ApartmentID))]
  public Apartments? Apartments { get; set; }

  [Column("starte_date")]
  public DateTime StartDate { get; set; }

  [Column("end_date")]
  public DateTime EndDate { get; set; }

  [Column("booking_details")]
  public string BookingDetails { get; set; } = string.Empty;

  [Column("booking_status")]
  public int BookingStatus { get; set; }
}