using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SeniorLibrary.Models;

namespace SeniorLibrary.Pages.Stats
{
    public class IndexModel : PageModel
    {
        private readonly SeniorLibrary.Data.SeniorLibraryContext _context;
        public IndexModel(SeniorLibrary.Data.SeniorLibraryContext context)
        {
            _context = context;
        }

        public IList<Stat> stats { get; set; }
        public IList<Book> books { get; set; }
        public async Task OnGetAsync()
        {
            stats = await _context.Stat.ToListAsync();
            books = await _context.Book.ToListAsync();
        }
    }
}
