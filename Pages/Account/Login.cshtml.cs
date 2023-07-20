using GamaxApp.Data;
using GamaxApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace GamaxApp.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly GamaxAppContext _context;
        public LoginModel(GamaxAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User Input { get; set; }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}
            // Validate the user credentials
            var user = _context.User.FirstOrDefault(u => u.Email == Input.Email);

            if (user == null || !VerifyPassword(user.Password, Input.Password))
            {
                ModelState.AddModelError(string.Empty, "Invalid username or password.");
                return Page();
            }
            // Validate the user credentials here
            // You can check against a database or any other authentication mechanism

            // If the credentials are valid, redirect the user to the home page
            return RedirectToPage("/Users/Index");
        }
        private bool VerifyPassword(string hashedPassword, string enteredPassword)
        {
            // Implement your password verification logic here
            // This can involve comparing hashed passwords or using a password hashing library like BCrypt

            // Example using simple string comparison (not recommended for production)
            return hashedPassword == enteredPassword;
        }

    }
}
