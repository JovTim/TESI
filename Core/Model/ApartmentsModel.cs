using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesiApi.Core.Model;

[Table("apartments")]
public class Apartments
{
  [Key]
  [Column("apartment_id")]
  public int ApartmentID { get; set; }

  [Column("apartment_type_id")]
  public int ApartmentTypeID { get; set; }

  [ForeignKey(nameof(ApartmentTypeID))]
  public RefApartmentTypes? RefApartmentTypes { get; set; }

  [Column("seller_id")]
  public int UserID { get; set; }

  [ForeignKey(nameof(UserID))]
  public Users? Users { get; set; }

  [Column("apartment_no")]
  public string ApartmentNo { get; set; } = string.Empty;


  [Column("bathroom_count")]
  public int BathroomCount { get; set; }


  [Column("bedroom_count")]
  public int BedroomCount { get; set; }

  [Column("apartment_size")]
  public int ApartmentSize { get; set; }

  [Column("rent_price")]
  public Decimal RentPrice { get; set; }

  [Column("apartment_details")]
  public string ApartmentDetails { get; set; } = string.Empty;

  [Column("apt_deleted")]
  public int ApartmentDeleted { get; set; }


  public ICollection<ApartmentFacilities> ApartmentFacilities { get; set; } = new List<ApartmentFacilities>();
  public ICollection<Bookings> Bookings { get; set; } = new List<Bookings>();
}