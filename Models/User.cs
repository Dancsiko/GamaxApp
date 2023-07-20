
using System.ComponentModel.DataAnnotations;

namespace GamaxApp.Models
{
    public class User
    {
        public int ID { get; set; }
        [StringLength(50, MinimumLength = 3)]
        [Required]
        public string Name { get; set; } = string.Empty;

        [StringLength(50, MinimumLength = 3)]
        [Required]
        public string Email { get; set; } = string.Empty;

      //  [RegularExpression(@"[a-zA-Z0-9]")]
        [StringLength(50, MinimumLength = 3)]
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
