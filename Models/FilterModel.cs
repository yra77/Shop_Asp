

namespace Shop_Asp.Models
{
    public class FilterModel
    {
        public string SearchStr { get; set; }
        public List<string> Genders { get; set; }
        public List<string> Brands { get; set; }
        public List<string> Sizes { get; set; }
        public List<string> MinMaxPrice { get; set; }
    }
}
