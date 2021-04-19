using Microsoft.AspNetCore.Identity;
using SeniorLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
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

        public static async Task AddBookAsync(SeniorLibraryContext context)
        {
            System.Diagnostics.Debug.WriteLine("Adding Books");
            string currentDir = Directory.GetCurrentDirectory();
            string bookRoot = currentDir + @"/book";
            string addedRoot = bookRoot + @"/Added";
            string[] entries = Directory.GetFiles(bookRoot);
            Console.WriteLine(currentDir);
            foreach (string filePath in entries)
            {
                string fileName = Path.GetFileName(filePath);
                //Prepare tools needed for filereading
                //Console.WriteLine(Path.GetFileName(filePath));
                byte[] fileContent = null;
                FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new System.IO.BinaryReader(fs);
                long byteLength = new FileInfo(filePath).Length;
                fileContent = binaryReader.ReadBytes((Int32)byteLength);
                fs.Close();
                fs.Dispose();
                binaryReader.Close();
                //Create a book object
                var book = new Book();
                book.Name = fileName;
                book.DataFiles = fileContent;
                book.CreatedOn = DateTime.Now;
                //Insert to database
                File.Move(filePath, addedRoot + @"/" + fileName);
                await context.Book.AddAsync(book);
                await context.SaveChangesAsync();
                System.Diagnostics.Debug.WriteLine("Successfully Added"+fileName+"!! to the database");
            }
            System.Diagnostics.Debug.WriteLine("DONE !!!!!!!!!!!!!!");
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
