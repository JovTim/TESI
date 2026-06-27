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

  [Column("apartment_name")]
  public string ApartmentName { get; set; } = string.Empty;

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

  [Column("apartment_country")]
  public string ApartmentCountry { get; set; } = string.Empty;

  [Column("apartment_state")]
  public string ApartmentState { get; set; } = string.Empty;

  [Column("apartment_city")]
  public string ApartmentCity { get; set; } = string.Empty;

  [Column("apartment_zip")]
  public string ApartmentZip { get; set; } = string.Empty;

  [Column("apartment_add_details")]
  public string ApartmentAddressDetails { get; set; } = string.Empty;

  [Column("apt_archive")]
  public int ApartmentArchive { get; set; }

  [Column("apt_deleted")]
  public int ApartmentDeleted { get; set; }


  public ICollection<ApartmentFacilities> ApartmentFacilities { get; set; } = new List<ApartmentFacilities>();
  public ICollection<Bookings> Bookings { get; set; } = new List<Bookings>();
}