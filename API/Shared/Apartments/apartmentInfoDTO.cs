namespace TesiApi.Api.Apartments;

public class ApartmentDTO
{
  public int ApartmentID { get; set; }
  public string ApartmentType { get; set; } = string.Empty;
  public string ApartmentNo { get; set; } = string.Empty;
  public int BathroomCount { get; set; }
  public int BedroomCount { get; set; }
  public int ApartmentSize { get; set; }
  public Decimal RentPrice { get; set; }
  public string ApartmentDetails { get; set; } = string.Empty;
  public string SellerName { get; set; } = string.Empty;

}