

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace Shop_Asp.Models
{
    public class LoginAdminViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [UIHint("password")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
