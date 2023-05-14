

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;


namespace Shop_Asp.Models
{
    public class Login 
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        public string PhoneNumber { get; set; } = "+0000000000";
        public string Address { get; set; }
        public int CartStatus { get; set; } = 0;
        public string FavoriteList { get; set; } = "";
        public string ImageAccount { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    }
}
