using Microsoft.EntityFrameworkCore;
using PharmacyApi.Domain.Entities;

namespace PharmacyApi.Infrastructure.Repositories.PharmacyRepository;

public class PharmacyContext : DbContext
{
    public PharmacyContext(DbContextOptions options) : base(options) { }

    public DbSet<Pharmacy> Pharmacies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pharmacy>().HasData(new Pharmacy
        {
            PharmacyId = 1,
            Name = "CVS Pharmacy",
            Address = "150 E Stacy Rd Suite 2400",
            City = "Allen",
            State = "TX",
            Zip = "75002",
            NumberOfFilledPrescriptions = 0,
            CreatedDate = DateTime.Now,
            UpdatedDate = DateTime.Now
        }, new Pharmacy
        {
            PharmacyId = 2,
            Name = "H-E-B Pharmacy",
            Address = "575 E Exchange Pkwy",
            City = "Allen",
            State = "TX",
            Zip = "75002",
            NumberOfFilledPrescriptions = 0,
            CreatedDate = DateTime.Now,
            UpdatedDate = DateTime.Now
        }, new Pharmacy
        {
            PharmacyId = 3,
            Name = "Walmart Pharmacy",
            Address = "730 W Exchange Pkwy",
            City = "Allen",
            State = "TX",
            Zip = "75013",
            NumberOfFilledPrescriptions = 0,
            CreatedDate = DateTime.Now,
            UpdatedDate = DateTime.Now
        }, new Pharmacy
        {
            PharmacyId = 4,
            Name = "Walgreens Pharmacy",
            Address = "500 E Stacy Rd",
            City = "Allen",
            State = "TX",
            Zip = "75002",
            NumberOfFilledPrescriptions = 0,
            CreatedDate = DateTime.Now,
            UpdatedDate = DateTime.Now
        }, new Pharmacy
        {
            PharmacyId = 5,
            Name = "Kroger Pharmacy",
            Address = "1210 N Greenville Ave",
            City = "Allen",
            State = "TX",
            Zip = "75002",
            NumberOfFilledPrescriptions = 0,
            CreatedDate = DateTime.Now,
            UpdatedDate = DateTime.Now
        });
    }
}
