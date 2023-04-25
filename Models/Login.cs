

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;


namespace Shop_Asp.Models
{
    public class Login : IdentityUser
    {
        [Key]
        public new int Id { get; set; }

        [Required]
        public new string UserName { get; set; }

        [Required]
        public new string Email { get; set; }

        [Required]
        public string Password { get; set; }
        //  public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int CartStatus { get; set; } = 0;
        public string FavoriteList { get; set; } = "";
        public byte[] ImageAccount { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    }
}
