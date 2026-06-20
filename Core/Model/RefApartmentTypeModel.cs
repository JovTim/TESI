using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesiApi.Core.Model;

[Table("ref_apartment_types")]
public class RefApartmentTypes
{

  [Key]
  [Column("apartment_type_id")]
  public int ApartmentTypeID { get; set; }

  [Column("apartment_type")]
  public string apartment_type { get; set; } = string.Empty;

  public ICollection<Apartments>? Apartments { get; set; }
}