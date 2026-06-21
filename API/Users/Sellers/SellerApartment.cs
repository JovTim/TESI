using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesiApi.Api.Apartments;
using TesiApi.Core.Model;
using TesiApi.Core.Data;

namespace TesiApi.Api.Users.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SellerApartmentsController : ControllerBase
{
  private readonly AppDbContext _context;
  public SellerApartmentsController(AppDbContext context)
  {
    _context = context;
  }

  [HttpGet("seller/{sellerID:int}")]
  public async Task<ActionResult<List<SellerApartmentDTO>>> GetSellerByID(int sellerID)
  {
    var results = await _context.Apartments
        .Where(a => a.Users!.IsSeller == 1 && a.Users.UserID == sellerID)
        .Select(a => new SellerApartmentDTO
        {
          ApartmentID = a.ApartmentID,
          ApartmentType = a.RefApartmentTypes!.apartment_type,
          ApartmentNo = a.ApartmentNo,
          BathroomCount = a.BathroomCount,
          BedroomCount = a.BedroomCount,
          ApartmentSize = a.ApartmentSize,
          RentPrice = a.RentPrice,
          ApartmentDetails = a.ApartmentDetails,
          Facilities = a.ApartmentFacilities
                      .Select(af => af.RefFacilitiyTypes!.FacilityType).ToList()
        }).ToListAsync();

    return Ok(results);
  }
}