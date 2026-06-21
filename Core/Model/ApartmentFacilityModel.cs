using System.ComponentModel.DataAnnotations.Schema;

namespace TesiApi.Core.Model;

[Table("apartment_facilities")]
public class ApartmentFacilities
{
  [Column("apartment_id")]
  public int ApartmentID { get; set; }

  [ForeignKey(nameof(ApartmentID))]
  public Apartments? Apartments { get; set; }

  [Column("facility_type_id")]
  public int FacilityTypeID { get; set; }

  [ForeignKey(nameof(FacilityTypeID))]
  public RefFacilitiyTypes? RefFacilitiyTypes { get; set; }
}