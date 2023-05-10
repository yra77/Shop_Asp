namespace Shop_Asp.Models.CartCheckOutModel
{
    public class AjaxCheckoutCart
    {
        public int TotalSum { get; set; }
        public List<AA> Quantity_Id { get; set; }
    }
    public class AA
    {
        public int quantity { get; set; }
        public int id { get; set; }
    }
}
