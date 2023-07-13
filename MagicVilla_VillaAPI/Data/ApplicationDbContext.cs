using System;
using MagicVilla_VillaAPI.Model;
using MagicVilla_VillaAPI.Model.Dto;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_VillaAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Villa> Villas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Villa>().HasData(
                new Villa()
                {
                    Id = 1,
                    Name = "Pool View",
                    Sqft = 100,
                    Occupancy = 4,
                    Rate = 200,
                    Details = "Fusce 11 tincidunt maximus leo, sed scelerisque",
                    ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villas3.jpg",
                    Amenity = "",
                    CreatedDate = DateTime.Now
                },
                new Villa()
                {
                    Id = 2,
                    Name = "Lake View",
                    Sqft = 140,
                    Occupancy = 5,
                    Rate = 600,
                    Details = "Fusce 11 tincidunt maximus leo, sed scelerisque",
                    ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villas3.jpg",
                    Amenity = "",
                    CreatedDate = DateTime.Now
                },
                new Villa()
                {
                    Id = 3,
                    Name = "Lake View",
                    Sqft = 140,
                    Occupancy = 5,
                    Rate = 600,
                    Details = "Fusce 11 tincidunt maximus leo, sed scelerisque",
                    ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villas3.jpg",
                    Amenity = "",
                    CreatedDate = DateTime.Now
                },
                new Villa()
                {
                    Id = 4,
                    Name = "Lake View",
                    Sqft = 140,
                    Occupancy = 5,
                    Rate = 600,
                    Details = "Fusce 11 tincidunt maximus leo, sed scelerisque",
                    ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villas3.jpg",
                    Amenity = "",
                    CreatedDate = DateTime.Now
                },
                new Villa()
                {
                    Id = 5,
                    Name = "Lake View",
                    Sqft = 140,
                    Occupancy = 5,
                    Rate = 600,
                    Details = "Fusce 11 tincidunt maximus leo, sed scelerisque",
                    ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villas3.jpg",
                    Amenity = "",
                    CreatedDate = DateTime.Now
                }
            );
        }
    }
}
