using LibraryManagementSystem.Core.Utilities.Roles;
using LibraryManagementSystem.Entities.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.DataAccess.Concrete
{
	public class Seed
	{
		public static async Task SeedAdminAndRoleAsync(IApplicationBuilder applicationBuilder)
		{
			using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
			{
				//Roles
				var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

				if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
					await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
				if (!await roleManager.RoleExistsAsync(UserRoles.User))
					await roleManager.CreateAsync(new IdentityRole(UserRoles.User));
				if (!await roleManager.RoleExistsAsync(UserRoles.Moderator))
					await roleManager.CreateAsync(new IdentityRole(UserRoles.Moderator));

				//Users
				var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
				string adminUsername = "admin";

				var adminUser = await userManager.FindByNameAsync(adminUsername);
				if (adminUser == null)
				{
					var newAdminUser = new AppUser()
					{
						Name = "admin",
						Surname = "admin",
						Email = "admin@admin",
						UserName = "admin",
						Password = "Admin12345Admin*",
						BirthYear = "1885",
						Gender = "Male",
						IdentityNumber = "11111111111",
						PhoneNumber = "11122233344",
						Debt = 0,
						BorrowedBookNumber= 0,
						UserRole = "admin",
						EmailConfirmed = true,
						IsActive = true,
						CreatedDate = DateTime.Now,
						ExpirationDate = DateTime.Now.AddYears(1)
					};
					await userManager.CreateAsync(newAdminUser, "Admin12345Admin*");
					await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
				}
			}
		}
	}
}
