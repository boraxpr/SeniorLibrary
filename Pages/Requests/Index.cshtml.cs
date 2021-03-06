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

namespace SeniorLibrary.Pages.Requests
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly SeniorLibrary.Data.SeniorLibraryContext _context;

        public IndexModel(SeniorLibrary.Data.SeniorLibraryContext context)
        {
            _context = context;
        }

        public IList<Entrying> Entrying { get;set; }

        public async Task OnGetAsync()
        {
            Entrying = await _context.Entrying.ToListAsync();
        }
    }
}
