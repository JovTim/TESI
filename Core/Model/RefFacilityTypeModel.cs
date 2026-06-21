using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TesiApi.Core.Model;

[Table("ref_facility_types")]
public class RefFacilitiyTypes
{
  [Key]
  [Column("facility_type_id")]
  public int FacilityTypeID { get; set; }

  [Column("facility_type")]
  public string? FacilityType { get; set; }

  public ICollection<ApartmentFacilities> ApartmentFacilities { get; set; } = new List<ApartmentFacilities>();

}