using Microsoft.EntityFrameworkCore;
using TesiApi.Core.Model;

namespace TesiApi.Core.Data;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
  {
  }

  public DbSet<Apartments> Apartments { get; set; }
  public DbSet<RefApartmentTypes> RefApartmentTypes { get; set; }
  public DbSet<Users> Users { get; set; }
  public DbSet<Accounts> Accounts { get; set; }
}