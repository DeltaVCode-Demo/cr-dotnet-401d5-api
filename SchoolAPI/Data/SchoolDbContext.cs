using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolAPI.Models;
using SchoolAPI.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Data
{
  public class SchoolDbContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<Student> Students { get; set; }
    public DbSet<Technology> Technologies { get; set; }
    public DbSet<Course> Courses { get; set; }

    public DbSet<Enrollment> Enrollments { get; set; }

    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<HotelRoom> HotelRooms { get; set; }

    public SchoolDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      // This calls the base method, and IdentityDbContext does interesting stuff
      base.OnModelCreating(modelBuilder);

      // Set up our composite key!
      modelBuilder.Entity<HotelRoom>()
        .HasKey(hr => new { hr.HotelId, hr.RoomNumber });

      modelBuilder.Entity<Hotel>()
        .HasData(
          new Hotel { Id = 10001, Name = "Downtown Cedar Rapids" },
          new Hotel { Id = 10011, Name = "Ped Mall, Iowa City" }
        );

      modelBuilder.Entity<HotelRoom>()
        .HasData(
          new HotelRoom { HotelId = 10001, RoomNumber = 101, Price = 99 },
          new HotelRoom { HotelId = 10001, RoomNumber = 102, Price = 99 },
          new HotelRoom { HotelId = 10001, RoomNumber = 103, Price = 99 },
          new HotelRoom { HotelId = 10001, RoomNumber = 104, Price = 99 },
          new HotelRoom { HotelId = 10001, RoomNumber = 201, Price = 299 },
          new HotelRoom { HotelId = 10001, RoomNumber = 202, Price = 299 },
          new HotelRoom { HotelId = 10011, RoomNumber = 11, Price = 199 },
          new HotelRoom { HotelId = 10011, RoomNumber = 12, Price = 199 },
          new HotelRoom { HotelId = 10011, RoomNumber = 21, Price = 199 },
          new HotelRoom { HotelId = 10011, RoomNumber = 22, Price = 199 }
        );



      modelBuilder.Entity<Student>().HasData(
        new Student { Id = 1, FirstName = "John", LastName = "Cokos" }
      );

      modelBuilder.Entity<Course>().HasData(
        new Course { Id = 1, CourseCode = "seattle-dotnet-401d13", TechnologyId = 3 },
        new Course { Id = 2, CourseCode = "seattle-javascript-401n18", TechnologyId = 1 },
        new Course { Id = 3, CourseCode = "seattle-code-201d73", TechnologyId = 1 }
      );

      modelBuilder.Entity<Technology>().HasData(
        new Technology { Id = 1, Name = "Javascript" },
        new Technology { Id = 2, Name = "Python" },
        new Technology { Id = 3, Name = "C#" },
        new Technology { Id = 4, Name = "Java" }
      );

      modelBuilder.Entity<Enrollment>().HasKey(
        enrollment => new { enrollment.CourseId, enrollment.StudentId }
      );

      SeedRole(modelBuilder, "Administrator");
      SeedRole(modelBuilder, "Editor");
      SeedRole(modelBuilder, "Admissions");
    }

    private void SeedRole(ModelBuilder modelBuilder, string roleName)
    {
      var role = new IdentityRole
      {
        Id = roleName,
        Name = roleName,
        NormalizedName = roleName.ToUpper(),
        ConcurrencyStamp = Guid.Empty.ToString(),
      };
      modelBuilder.Entity<IdentityRole>().HasData(role);
    }
  }

}
