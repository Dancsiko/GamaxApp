using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GamaxApp.Data;
using GamaxApp.Models;

namespace GamaxApp.Pages.Users
{
    public class DeleteModel : PageModel
    {
        private readonly GamaxApp.Data.GamaxAppContext _context;
        public bool CanDeleteUsers { get; set; }

        public DeleteModel(GamaxApp.Data.GamaxAppContext context)
        {
            _context = context;
        }

        [BindProperty]
      public User User { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var canDelete= _context.User.FirstOrDefault(u => u.Email == LoggedInUser.LoggedUser).CanDelete;
            if (!canDelete)
            {
                return RedirectToPage("./Index");
            }
            ModelState.AddModelError(string.Empty, "User is not authorized.");
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User.FirstOrDefaultAsync(m => m.ID == id);

            if (user == null)
            {
                return NotFound();
            }
            else 
            {
                User = user;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }
            var user = await _context.User.FindAsync(id);

            if (user != null)
            {
                User = user;
                _context.User.Remove(User);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
