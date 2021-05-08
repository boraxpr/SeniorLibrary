using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SeniorLibrary.Data;
using SeniorLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace SeniorLibrary.Pages.Download 
{ 
    public class DownloadModel : PageModel
    {
        private readonly SeniorLibrary.Data.SeniorLibraryContext _context;
        private UserManager<ApplicationUser> _userManager;

        public DownloadModel(UserManager<ApplicationUser> userManager
            , SeniorLibrary.Data.SeniorLibraryContext context)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public Book Book { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = await _context.Book.FirstOrDefaultAsync(m => m.ID == id);

            if (Book == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = await _context.Book.FindAsync(id);

            if (Book != null)
            {
                byte[] contents = Book.DataFiles;

                string username = User.Identity.Name;
                
                var Stat = await _context.Stat.FirstOrDefaultAsync(stat => stat.userName == username);
                if (Stat == null)
                {
                    var stat = new Stat();
                    stat.userName = User.Identity.Name;
                    stat.DownloadedBooks = Book.Name;
                    await _context.Stat.AddAsync(stat);
                }
                else
                {
                    if (!Stat.DownloadedBooks.Contains(Book.Name)) 
                    {
                        Stat.DownloadedBooks += "," + Book.Name;
                    }
                    
                }
                await _context.SaveChangesAsync();
                return File(contents, "application/pdf");
            }

            return RedirectToPage("./Index");
        }
    }
}
