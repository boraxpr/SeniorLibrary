using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SeniorLibrary.Models;

namespace SeniorLibrary.Pages.Upload
{
    public class IndexModel : PageModel
    {
        private readonly SeniorLibrary.Data.SeniorLibraryContext _context;
        public IndexModel(SeniorLibrary.Data.SeniorLibraryContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Book Book { get; set; }
        public IList<Book> books { get; set; }
        public IActionResult Index()
        {
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(IFormFile files)
        {
            if (files != null)
            {
                if (files.Length > 0)
                {
                    //Getting FileName
                    var fileName = Path.GetFileName(files.FileName);
                    if (Path.GetExtension(fileName) != ".pdf")
                    {
                        return Page();
                    }
                    var book = new Book();
                    book.Name = fileName;
                    book.CreatedOn = DateTime.Now;
                    book.Advisor = Book.Advisor;
                    using (var target = new MemoryStream())
                    {
                        files.CopyTo(target);
                        book.DataFiles = target.ToArray();
                    }

                    await _context.Book.AddAsync(book);
                    await _context.SaveChangesAsync();

                }
            }
            return Redirect("/Download");
        }
        public async Task<IActionResult> OnGetAsync()
        {
            books = await _context.Book.ToListAsync();
            return Page();
        }
    }
}
