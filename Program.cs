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
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // **Database Connection**
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Con")));

            // **Identity Configuration**
            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // **MVC Services**
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // **Create Roles & Admin User on Startup**
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                await CreateRolesAndAdmin(services);
            }

            // **Middleware Setup**
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

            // **Routing Configuration**
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

            app.MapControllerRoute(
                name: "account",
                pattern: "{controller=Account}/{action=Login}/{id?}");


            await app.RunAsync();
        }

        // **📌 Create Roles & Admin User Function**
        private static async Task CreateRolesAndAdmin(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            string[] roles = { "Admin", "User" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // **Check & Create Admin User**
            var adminEmail = "admin@gmail.com";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                var admin = new IdentityUser { UserName = adminEmail, Email = adminEmail };
                var result = await userManager.CreateAsync(admin, "Admin@123");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "Admin");
                }
            }
            // **Check & Create  User**
            var userEmail = "user@gmail.com";
            var userUser = await userManager.FindByEmailAsync(userEmail);

            if (userUser == null)
            {
                var user = new IdentityUser { UserName = userEmail, Email = userEmail };
                var result = await userManager.CreateAsync(user, "User@123");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "User");
                }
            }

        }
    }
}
