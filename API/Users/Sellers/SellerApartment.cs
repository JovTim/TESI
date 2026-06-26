using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesiApi.Api.Apartmentss;
using TesiApi.Core.Model;
using TesiApi.Core.Data;

namespace TesiApi.Api.Userss.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SellerApartmentsController : ControllerBase
{
  private readonly AppDbContext _context;
  public SellerApartmentsController(AppDbContext context)
  {
    _context = context;
  }
  // might adjust this if auth is added, this is just for testing!!
  [HttpGet("seller/{sellerID:int}")]
  public async Task<ActionResult<List<SellerApartmentDTO>>> GetSellerByID(int sellerID)
  {
    var results = await _context.Apartments
        .Where(a => a.Users!.IsSeller == 1 && a.Users.UserID == sellerID && a.ApartmentDeleted != 1)
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

  [HttpPost("seller/{sellerID:int}")]
  public async Task<IActionResult> AddApartment([FromBody] AddApartmentDTO apartment, int sellerID)
  {
    using var transaction = await _context.Database.BeginTransactionAsync();
    try
    {
      var newApartment = new Apartments
      {
        ApartmentTypeID = apartment.ApartmentType,
        UserID = sellerID,
        ApartmentNo = apartment.ApartmentNo,
        BathroomCount = apartment.BathroomCount,
        BedroomCount = apartment.BedroomCount,
        ApartmentSize = apartment.ApartmentSize,
        RentPrice = apartment.RentPrice,
        ApartmentDetails = apartment.ApartmentDetails,
        ApartmentDeleted = 0
      };

      foreach (var facilityID in apartment.ApartmentFacilities)
      {
        newApartment.ApartmentFacilities.Add(new ApartmentFacilities
        {
          FacilityTypeID = facilityID
        });
      }

      _context.Apartments.Add(newApartment);
      await _context.SaveChangesAsync();

      await transaction.CommitAsync();

      return Ok("Apartment Added!");

    }
    catch (Exception)
    {
      await transaction.RollbackAsync();
      return StatusCode(500);
    }
  }

  // this is just for testing
  [HttpPut("seller/{sellerID:int}")]
  public async Task<IActionResult> EditApartment([FromBody] UpdateApartmentDTO dto, int sellerID)
  {
    using var transaction = await _context.Database.BeginTransactionAsync();
    try
    {
      var apartment = await _context.Apartments
                    .Include(a => a.ApartmentFacilities)
                    .FirstOrDefaultAsync(a => a.ApartmentID == dto.ApartmentID);

      if (apartment == null)
      {
        return NotFound("Not found!");
      }

      apartment.ApartmentTypeID = dto.ApartmentType;
      apartment.ApartmentNo = dto.ApartmentNo;
      apartment.BathroomCount = dto.BathroomCount;
      apartment.BedroomCount = dto.BedroomCount;
      apartment.ApartmentSize = dto.ApartmentSize;
      apartment.RentPrice = dto.RentPrice;
      apartment.ApartmentDetails = dto.ApartmentDetails;

      var facilitiesToRemove = apartment.ApartmentFacilities
                               .Where(ap => !dto.ApartmentFacilities.Contains(ap.FacilityTypeID)).ToList();

      foreach (var facility in facilitiesToRemove)
      {
        apartment.ApartmentFacilities.Remove(facility);
      }

      foreach (var facilityID in dto.ApartmentFacilities)
      {
        if (!apartment.ApartmentFacilities.Any(ap => ap.FacilityTypeID == facilityID))
        {
          apartment.ApartmentFacilities.Add(new ApartmentFacilities
          {
            ApartmentID = apartment.ApartmentID,
            FacilityTypeID = facilityID
          });
        }
      }

      await _context.SaveChangesAsync();

      await transaction.CommitAsync();

      return Ok("Apartment Updated!");
    }
    catch (Exception)
    {
      await transaction.RollbackAsync();
      return StatusCode(500);
    }

  }
}