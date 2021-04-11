using Microsoft.AspNetCore.Identity;
using SeniorLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace SeniorLibrary.Data
{
    public class ContextSeed
    {
        public static async Task SeedBookAsync(SeniorLibrary.Data.SeniorLibraryContext _context)
        {
            Book book = new();
            _context.Book.Add(book);
            await _context.SaveChangesAsync();
        }
        public enum Roles
        {
            Admin,
            Student,
            Staff,
            Lecturer
        }
        public static async Task SeedRolesAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Student.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Staff.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Lecturer.ToString()));
        }

        public static async Task SeedSuperAdminAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Default User
            var defaultUser = new ApplicationUser
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
                }

            }
        }

        public static async Task AddUserAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            string text = await System.IO.File.ReadAllTextAsync("users.json");
            using JsonDocument doc = JsonDocument.Parse(text);
            JsonElement root = doc.RootElement;
            //Seed Users from Json
            foreach (var item in root.EnumerateArray())
            {
                string email = item.GetProperty("email").ToString();
                string password = item.GetProperty("password").ToString();
                string firstName = item.GetProperty("firstname").ToString();
                string lastName = item.GetProperty("lastname").ToString();
                int studentID = int.Parse(item.GetProperty("studentid").ToString());
                string role = item.GetProperty("role").ToString();
                var defaultUser = new ApplicationUser
                {
                    UserName = email.Split("@")[0],
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName,
                    StudentID = studentID,
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true
                };
                if (userManager.Users.All(u => u.Id != defaultUser.Id))
                {
                    var user = await userManager.FindByEmailAsync(defaultUser.Email);
                    if (user == null)
                    {
                        // id, password
                        if (Enum.IsDefined(typeof(Roles), role))
                        {
                            await userManager.CreateAsync(defaultUser, password);
                            await userManager.AddToRoleAsync(defaultUser, role);
                        }
                    }

                }
            }
        }

    }

}
