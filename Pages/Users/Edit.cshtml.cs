﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GamaxApp.Data;
using GamaxApp.Models;

namespace GamaxApp.Pages.Users
{
    public class EditModel : PageModel
    {
        private readonly GamaxApp.Data.GamaxAppContext _context;

        public EditModel(GamaxApp.Data.GamaxAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User User { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            string loggedInUserEmail = LoggedInUser.LoggedUser;

            bool userCanEdit = _context.User.Any(u => u.Email == loggedInUserEmail && u.CanEdit);

            if (!userCanEdit)
            {
                ModelState.AddModelError(string.Empty, "User is not authorized.");
                return RedirectToPage("./Index");
            }

            var user = await _context.User.FirstOrDefaultAsync(m => m.ID == id);
            if (user == null)
            {
                return NotFound();
            }
            User = user;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(User).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(User.ID))
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

        private bool UserExists(int id)
        {
            return (_context.User?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
