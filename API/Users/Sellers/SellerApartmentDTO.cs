namespace TesiApi.Api.Userss;

public class SellerApartmentDTO
{
  public int ApartmentID { get; set; }
  public string ApartmentType { get; set; } = string.Empty;
  public string ApartmentName { get; set; } = string.Empty;
  public string ApartmentNo { get; set; } = string.Empty;
  public int BathroomCount { get; set; }
  public int BedroomCount { get; set; }
  public int ApartmentSize { get; set; }
  public Decimal RentPrice { get; set; }
  public string ApartmentDetails { get; set; } = string.Empty;
  public string ApartmentCountry { get; set; } = string.Empty;
  public string ApartmentState { get; set; } = string.Empty;
  public string ApartmentCity { get; set; } = string.Empty;
  public string ApartmentZip { get; set; } = string.Empty;
  public string ApartmentAddressDetails { get; set; } = string.Empty;

  public List<string?> Facilities { get; set; } = new();
}