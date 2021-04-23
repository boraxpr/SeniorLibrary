using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SeniorLibrary.Models;

namespace SeniorLibrary.Pages.Download
{
    [Authorize(Roles = "Admin, Lecturer, Staff")]
    public class IndexModel : PageModel
    {
        private readonly SeniorLibrary.Data.SeniorLibraryContext _context;
        public IndexModel(SeniorLibrary.Data.SeniorLibraryContext context)
        {
            _context = context;
        }

        public IList<Book> books { get; set; }
        public async Task OnGetAsync()
        {
            books = await _context.Book.ToListAsync();
        }

        /*public async Task<IActionResult> AddRole(string roleName)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _roleManager.CreateAsync(new IdentityRole(roleName.Trim()));

            return RedirectToPage("./Index");
        }*/
    }
}
