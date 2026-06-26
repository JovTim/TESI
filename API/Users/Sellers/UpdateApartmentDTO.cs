namespace TesiApi.Api.Userss;

public class UpdateApartmentDTO
{
  public int ApartmentID { get; set; }
  public int ApartmentType { get; set; }
  public string ApartmentNo { get; set; } = string.Empty;
  public int BathroomCount { get; set; }
  public int BedroomCount { get; set; }
  public int ApartmentSize { get; set; }
  public Decimal RentPrice { get; set; }
  public string ApartmentDetails { get; set; } = string.Empty;
  public HashSet<int> ApartmentFacilities { get; set; } = new();
}