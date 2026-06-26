using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesiApi.Api.Apartmentss;
using TesiApi.Core.Model;
using TesiApi.Core.Data;

namespace TesiApi.Api.Apartmentss.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ApartmentsController : ControllerBase
{
  private readonly AppDbContext _context;
  public ApartmentsController(AppDbContext context)
  {
    _context = context;
  }

  [HttpGet]
  public async Task<ActionResult<List<ApartmentDTO>>> GetApartments()
  {
    var results = await _context.Apartments
        .Where(a => a.ApartmentDeleted != 1)
        .Select(a => new ApartmentDTO
        {
          ApartmentID = a.ApartmentID,
          ApartmentType = a.RefApartmentTypes!.apartment_type,
          ApartmentNo = a.ApartmentNo,
          BathroomCount = a.BathroomCount,
          BedroomCount = a.BedroomCount,
          ApartmentSize = a.ApartmentSize,
          RentPrice = a.RentPrice,
          ApartmentDetails = a.ApartmentDetails,
          SellerName = string.Concat(a.Users!.FirstName, " ", a.Users!.LastName),
          Facilities = a.ApartmentFacilities
                      .Select(af => af.RefFacilitiyTypes!.FacilityType).ToList()
        }).ToListAsync();

    return Ok(results);
  }
}