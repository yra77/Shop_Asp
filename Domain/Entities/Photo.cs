

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Shop_Asp.Domain.Entities
{
    public class Photo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Image { get; set; } = null!;
        [Required]
        public int ProductId { get; set; }
    }
}
