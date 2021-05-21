using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SeniorLibrary.Models;

namespace SeniorLibrary.Pages.Requests
{
    public class ApproveModel : PageModel
    {
        private readonly SeniorLibrary.Data.SeniorLibraryContext _context;

        public ApproveModel(SeniorLibrary.Data.SeniorLibraryContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Entrying Entrying { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Entrying = await _context.Entrying.FirstOrDefaultAsync(m => m.ID == id);

            if (Entrying == null)
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

            Entrying = await _context.Entrying.FindAsync(id);

            if (Entrying != null)
            {
                Entrying.Downloadable = true;
                _context.Entrying.Update(Entrying);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
