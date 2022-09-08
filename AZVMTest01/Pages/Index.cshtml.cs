using AZVMTest01.Models;
using AZVMTest01.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AZVMTest01.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public List<Product> Products { get; set; }

        public void OnGet()
        {
            //ProductService productService = new ProductService(); 
            //Products = productService.GetProducts();
        }
    }
}