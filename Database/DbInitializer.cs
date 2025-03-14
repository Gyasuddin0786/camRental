using camRental.Models; // User Model ka namespace
using System.Collections.Generic; // List ka namespace
using System.Linq; // For Any() Method

namespace camRental.Database
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            // ✅ Agar Database Already Seeded hai to return
            if (context.Users.Any())
            {
                return; 
            }

            var users = new List<User>
            {
                new User { Id = "1", FullName = "John Doe", Email = "john@example.com", Phone = "123456789", Address = "USA", Role = "Admin" },
                new User { Id = "2", FullName = "Jane Smith", Email = "jane@example.com", Phone = "987654321", Address = "UK", Role = "User" }
            };

            context.Users.AddRange(users);  // ✅ No Error Here
            context.SaveChanges(); // ✅ Save to Database
        }
    }
}
