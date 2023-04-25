

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Shop_Asp.Domain.Entities
{
    public class Brand
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string NameBrand { get; set; }
        public string LogoBrands { get; set; }
    }
}
