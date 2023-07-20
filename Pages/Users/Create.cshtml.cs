﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GamaxApp.Data;
using GamaxApp.Models;

namespace GamaxApp.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly GamaxApp.Data.GamaxAppContext _context;

        public CreateModel(GamaxApp.Data.GamaxAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var canAdd = _context.User.FirstOrDefault(u => u.Email == LoggedInUser.LoggedUser).CanAdd;
            if (!canAdd)
            {
                return RedirectToPage("./Index");
            }
            //ModelState.AddModelError(string.Empty, "User is not authorized.");
            return Page();


        }

        [BindProperty]
        public User User { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.User == null || User == null)
            {
                return Page();
            }

            _context.User.Add(User);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
