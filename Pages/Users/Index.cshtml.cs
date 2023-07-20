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
    public class UsersModel : PageModel
    {
        private readonly GamaxApp.Data.GamaxAppContext _context;

        public UsersModel(GamaxApp.Data.GamaxAppContext context)
        {
            _context = context;
        }

        public IList<User> User { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.User != null)
            {
                User = await _context.User.ToListAsync();
            }
        }
    }
}
