using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace SeniorLibrary.Data
{
    public class ContextSeed
    {
        public enum Roles
        {
            Admin,
            Basic
        }
        public static async Task SeedRolesAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Basic.ToString()));
        }

        public static async Task SeedSuperAdminAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Default User
            var defaultUser = new IdentityUser
            {
                UserName = "ictadmin",
                Email = "ictadmin@gmail.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    // id, password
                    await userManager.CreateAsync(defaultUser, "123Pa$$word.");
                    await userManager.AddToRoleAsync(defaultUser, Roles.Admin.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Roles.Basic.ToString());
                }

            }
        }

        public static async Task AddUserAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            string text = await System.IO.File.ReadAllTextAsync("users.json");
            using JsonDocument doc = JsonDocument.Parse(text);
            JsonElement root = doc.RootElement;
            //var users = new List<IdentityUser>();
            //Seed Users from Json
            foreach (var item in root.EnumerateArray())
            {
                string email = item.GetProperty("email").ToString();
                string password = item.GetProperty("password").ToString();
                var defaultUser = new IdentityUser
                {
                    UserName = email.Split("@")[0],
                    Email = email,
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true
                };
                if (userManager.Users.All(u => u.Id != defaultUser.Id))
                {
                    var user = await userManager.FindByEmailAsync(defaultUser.Email);
                    if (user == null)
                    {
                        // id, password
                        await userManager.CreateAsync(defaultUser, password);
                        await userManager.AddToRoleAsync(defaultUser, Roles.Basic.ToString());
                    }

                }
            }
        }

    }

}
