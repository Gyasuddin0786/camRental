using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using camRental.Models;

namespace camRental.Database
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Camera> Cameras { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Seed Roles
            builder.Entity<Microsoft.AspNetCore.Identity.IdentityRole>().HasData(
                new Microsoft.AspNetCore.Identity.IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
                new Microsoft.AspNetCore.Identity.IdentityRole { Name = "User", NormalizedName = "USER" }
            );

            // Seed Default Users
            builder.Entity<User>().HasData(
                new User { Id = "1", FullName = "John Doe", Email = "john@example.com",Phone = "9263605357",Address = "Rajkot", Role = "User" },
                new User { Id = "2", FullName = "Admin User", Email = "admin@camrental.com", Phone = "9263605357", Address = "Rajkot", Role = "Admin" }
            );
        }
    }
}
