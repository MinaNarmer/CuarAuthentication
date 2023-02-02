﻿using CuarAuthentication.Domain.Constants;
using CuarAuthentication.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CuarAuthentication.Domain.Context;

namespace CuarAuthentication.Domain.Seeds
{
    public class SeedApplicationDB
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<CuraAuthDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

            context.Database.Migrate(); // apply all migrations 
            context.Database.EnsureCreated();
            if (!context.Roles.Any())
            {
                await roleManager.CreateAsync(new ApplicationRole { Name = RolesNames.Admin, NormalizedName = RolesNames.Admin });
                await roleManager.CreateAsync(new ApplicationRole { Name = RolesNames.Player, NormalizedName = RolesNames.Player });
            }
            if (!context.Users.Any())
            {
                var adminUser = new ApplicationUser()
                {
                    Email = "superadmin@cura.com",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "superadmin",
                    IsActive = true,
                };

                await userManager.CreateAsync(adminUser, "P@$$w0rd");
                await userManager.AddToRoleAsync(adminUser, RolesNames.Admin);

                var player = new ApplicationUser()
                {
                    Email = "player@cura.com",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "player",
                    IsActive = true,
                };

                await userManager.CreateAsync(player, "P@$$w0rd");
                await userManager.AddToRoleAsync(player, RolesNames.Player);
            }
        }
    }
}
