using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SeniorLibrary.Data;
using SeniorLibrary.Models;

namespace SeniorLibrary.Pages.Requests
{
    public class EditModel : PageModel
    {
        private readonly SeniorLibrary.Data.SeniorLibraryContext _context;

        public EditModel(SeniorLibrary.Data.SeniorLibraryContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Entrying).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntryingExists(Entrying.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EntryingExists(int id)
        {
            return _context.Entrying.Any(e => e.ID == id);
        }
    }
}
