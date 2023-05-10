

using Shop_Asp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;


namespace Shop_Asp.Views.Shared.CustomActionResults
{
    public class SelectOrderResult : IActionResult
    {


        private readonly Product _product;


        public SelectOrderResult(Product product)
        {
            _product = product;
        }


        public async Task ExecuteResultAsync(ActionContext context)
        {

            string[] colors = _product.Colors.Split(' ');

            string fullHtmlCode = string.Format("<input id=\"hiddenInput\" value=\"{0}\" hidden/><h5 class=\"text-center mb-3\">Choose color, size and quantity</h5><p id=\"errorText\" class=\"text-center text-danger mb-3\"></p><label class=\"d-block text-secondary\">Select color:</label>", _product.Id);
            foreach (var color in colors)
            {
                fullHtmlCode += string.Format("<button style=\"background-color:{0}; margin-left:0.5em; height:35px; width:35px;\" class=\"btn btn-outline-info rounded-circle shadow-none\" onclick=\"SelectColorBtn(event)\" ></button>", color);
            }

            fullHtmlCode += "<label class=\"d-block mt-3 text-secondary\">Select size:</label>";

            var sizes = _product.Sizes.Split(' ');
            foreach (var size in sizes)
            {
                fullHtmlCode += string.Format("<button class=\"btn btn-outline-info me-2 rounded shadow-none\" onclick=\"SelectSizeBtn(event,{0})\">" + size + "</button>", size);
            }

            fullHtmlCode += string.Format("<label class=\"d-block mt-3 text-secondary\">Select count:</label>");

            fullHtmlCode += string.Format("<select class=\"form-select border border-info shadow-none\" id=\"countSelect\" onchange=\"SelectCount(event)\"> <option value=\"\">Select count</option>");

            for (int i = 1; i <= _product.Count; i++)
            {
                fullHtmlCode += string.Format("<option value = \"{0}\" >" + i + "</option>", i);
            }
            fullHtmlCode += string.Format("</select>");

            await context.HttpContext.Response.WriteAsync(fullHtmlCode);
        }
    }

}
