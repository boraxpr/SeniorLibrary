using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace SeniorLibrary.Pages.Roles
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public IndexModel(UserManager<IdentityUser> userManager
            , RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IList<IdentityUser> users { get; set; }
        public IList<IdentityRole> roles { get; set; }
        public async Task OnGetAsync()
        {
            users = await _userManager.Users.ToListAsync();
            roles = await _roleManager.Roles.ToListAsync();
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
