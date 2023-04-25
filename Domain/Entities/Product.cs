

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Shop_Asp.Domain.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Do Not empty")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Do Not empty")]
        public int Price { get; set; }
        
        [Required(ErrorMessage = "Do Not empty")]
        public string Brand { get; set; }

        [ForeignKey("ProductId")]
        public List<Photo> Photos_Large { get; set; } = new List<Photo>();
        
        [Required(ErrorMessage = "Do Not empty")]
        public string Sizes { get; set; }
        
        [Required(ErrorMessage = "Do Not empty")]
        public string Colors { get; set; }
        
        [Required(ErrorMessage = "Do Not empty")]
        public int Count { get; set; }
        
        [Required(ErrorMessage = "Do Not empty")]
        public string Gender { get; set; }
        public bool IsNew { get; set; } = false;

        public bool IsBestSeller { get; set; } = false;
        
        [Required(ErrorMessage = "Do Not empty")]
        public string DescriptionEn { get; set; }

        [Required(ErrorMessage = "Do Not empty")]
        public string DescriptionUa { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; } = DateTime.UtcNow;
    }
}
