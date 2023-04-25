

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Shop_Asp.Domain.Entities
{

    public class ShopModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Do Not empty")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Do Not empty")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Do Not empty")]
        [EmailAddress(ErrorMessage = "Incorrect email")]
        public string CompanyEmail { get; set; }

        [Required(ErrorMessage = "Do Not empty")]
        public string CompanyPhone { get; set;}

        [Required(ErrorMessage = "Do Not empty")]
        [Display(Name = "Description about company")]
        public string DescriptionCompany { get; set; }

        [Required(ErrorMessage = "Do Not empty")]
        [Display(Name = "Logotype companys")]
        public string LogoImgPath { get; set; }

        [Required(ErrorMessage = "Do Not empty")]
        [Display(Name = "SEO метатег Title")]
        public string MetaTitle { get; set; }//указывается заголовок страницы

        [Required(ErrorMessage = "Do Not empty")]
        [Display(Name = "SEO метатег Description")]
        public string MetaDescription { get; set; }//описание содержимого страницы

        [Required(ErrorMessage = "Do Not empty")]
        [Display(Name = "SEO метатег Keywords")]
        public string MetaKeywords { get; set; }//список ключевых слов
    }
}
