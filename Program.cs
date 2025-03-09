using camRental.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace camRental
{
    public class Program
    {
        public static async Task Main(string[] args)  // 👈 `async` method banaya
        {
            var builder = WebApplication.CreateBuilder(args);

            // Database Connection Setup
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Con")));

            // Identity Setup
            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add MVC Services
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                await CreateRoles(services);  // 👈 Roles aur Admin User Create Karne Ka Method
            }

            // Configure Middleware
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            // Routes Setup
            app.MapControllerRoute(
                name: "admin",
                pattern: "admin",
                defaults: new { controller = "Admin", action = "Dashboard" });

            app.MapControllerRoute(
                name: "user",
                pattern: "user",
                defaults: new { controller = "User", action = "Dashboard" });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            await app.RunAsync(); // 👈 `await` ka use kiya
        }

        // 📌 **Role Aur Admin User Create Karne Ka Function**
        private static async Task CreateRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            string[] roleNames = { "Admin", "User" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // **Default Admin User Create Karna**
            var adminUser = await userManager.FindByEmailAsync("admin@gmail.com");
            if (adminUser == null)
            {
                var admin = new IdentityUser { UserName = "admin@camrental.com", Email = "admin@gmail.com" };
                var createAdmin = await userManager.CreateAsync(admin, "admin123");

                if (createAdmin.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "Admin");
                }
            }
        }
    }
}
