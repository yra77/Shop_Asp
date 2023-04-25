

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Shop_Asp.Domain.Entities
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int BuyCount { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public string Size { get; set; }
        public int Status { get; set; } = 0;// 0 - default, 1 - complete, 2 - sending
        public DateTime Date { get; set; } = DateTime.UtcNow;
    }
}
